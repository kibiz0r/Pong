def mono(command)
  sh "mono --debug --runtime=v4.0.30319 #{command}"
end

task :bootstrap_ironruby do
  sh "patch IronLanguages/Languages/Ruby/StdLib/ruby/1.9.1/rubygems/requirement.rb vendor/ironruby_requirement.patch"
end

task :build_ironruby do
  sh "xbuild /p:Configuration=Release IronLanguages/Solutions/Ruby.sln"
end

task :vendor_gems do
  {
    "rspec" => "2.7.0",
    "rr" => "1.0.4"
  }.each do |gem, version|
    sh "gem install --install-dir=vendor/ruby #{gem} --version #{version}"
  end
end

task :spec do
  sh "rspec spec/*_spec.rb"
end

task :test do
  mono "Pong.Test/NUnit-2.5.10.11092/bin/net-2.0/nunit-console.exe Pong.Test/bin/Debug/Pong.Test.dll"
end

task :run do
  mono "bin/Debug/Pong.exe"
end

task :default => :test
