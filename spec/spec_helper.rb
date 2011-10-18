require "rspec"
require "rr"
require "System.Core"
require "bin/Debug/AllegroSharp.dll"
require "bin/Debug/Pong.exe"

include AllegroSharp
include Pong

class String
  def underscore
    self.gsub(/::/, '/').
    gsub(/([A-Z]+)([A-Z][a-z])/,'\1_\2').
    gsub(/([a-z\d])([A-Z])/,'\1_\2').
    tr("-", "_").
    downcase
  end

  def camelize
    self.gsub(/\/(.?)/) { "::#{$1.upcase}" }.gsub(/(?:^|_)(.)/) { $1.upcase }
  end

  def constantize
    unless /\A(?:::)?([A-Z]\w*(?:::[A-Z]\w*)*)\z/ =~ self
      raise NameError, "#{self.inspect} is not a valid constant name!"
    end

    Object.module_eval("::#{$1}", __FILE__, __LINE__)
  end
end

class RSpec::Matchers::BePredicate
  def predicate
    "#{@expected}".to_sym
  end
end

class RSpec::Matchers::Has
  def predicate(sym)
    "#{sym.to_s.sub("have_","has_")}".to_sym
  end
end

module AssumptionHelpers
  def assumed_modules
    @assumed_modules ||= {}
  end

  def assume(mod, *ivars)
    ivars << nil if ivars.empty?

    assumed_modules[mod] ||= Class.new do
      include mod
      attr_accessor :assumed_ivar

      define_method :assumed_module do
        mod
      end

      def inspect
        if assumed_ivar
          assumed_ivar
        else
          "Assumed[#{assumed_module}]"
        end
      end
    end

    assumptions = ivars.map do |ivar|
      if ivar.is_a? Hash
        ivar.map do |ivar, properties|
          assumed_module = assume mod, ivar
          properties.each do |key, value|
            instance_variable_set "@#{key}", value
            stub(assumed_module, key).returns value
          end
        end
      else
        assumed_modules[mod].new.tap do |assumption|
          if ivar
            assumption.assumed_ivar = "@#{ivar}"
            instance_variable_set "@#{ivar}", assumption
          end
        end
      end
    end
    if assumptions.size == 1
      assumptions[0]
    else
      assumptions
    end
  end
end

module DependencyHelpers
  module ClassMethods
    def dependencies(*deps)
      deps.each do |dep|
        dependency dep
      end
    end

    def dependency(dep)
      before do
        dependency_list << track_ivar(dep)
      end

      subject do
        described_class.new(*dependency_list.map { |dep|
          instance_variable_get "@#{dep}"
        }).tap do |subj|
          property_list.each do |prop|
            subj.send :"#{prop}=", instance_variable_get("@#{prop}")
          end
        end
      end
    end
  end

  def dependency_list
    @dependency_list ||= []
  end

  def track_ivars(*ivars)
    ivars.each do |ivar|
      track_ivar ivar
    end
  end

  def track_ivar(ivar)
    key, value = if ivar.is_a? Hash
                   ivar.first
                 elsif ivar.is_a? Symbol
                   [ivar, "I#{ivar.to_s.camelize}".constantize]
                 else
                   raise "wtf is this? #{ivar.inspect}"
                 end
    if value.is_a? Module
      value = assume value, key
    end
    instance_variable_set "@#{key}", value
    key
  end

  def property(prop)
    property_list << track_ivar(prop)
  end

  def property_list
    @property_list ||= []
  end
end

class Array
  def of_type(type)
    System::Linq::Enumerable.to_array(System::Linq::Enumerable.method(:of_type).of(type)[self])
  end
end

RSpec.configure do |config|
  config.mock_with :rr
  config.include AssumptionHelpers
  config.include DependencyHelpers
  config.extend DependencyHelpers::ClassMethods
end
