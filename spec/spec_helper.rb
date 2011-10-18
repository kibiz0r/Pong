require "rspec"
require "bin/Debug/Pong.exe"
require "System.Core"
require "rr"

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

module AssumptionHelpers
  def assume(mod, *ivars)
    ivars << nil if ivars.empty?
    @assumptions ||= {}

    @assumptions[mod] ||= Class.new do
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
      @assumptions[mod].new.tap do |assumption|
        if ivar
          assumption.assumed_ivar = "@#{ivar}"
          instance_variable_set "@#{ivar}", assumption
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
      before do
        @dependencies ||= []
        deps.each do |dep|
          mod = "I#{dep.to_s.camelize}".constantize
          assume mod, dep
          @dependencies << dep
        end
      end

      subject do
        @dependencies ||= []
        described_class.new.tap do |subj|
          @dependencies.each do |dep|
            subj.send :"#{dep}=", instance_variable_get("@#{dep}")
          end
        end
      end
    end
  end

  def dependency(dep)
    @dependencies ||= []
    ivar, value = dep.first
    instance_variable_set "@#{ivar}", value
    @dependencies << ivar
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
