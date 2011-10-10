def mono(command)
  sh "mono --debug --runtime=v4.0.30319 #{command}"
end

task :test do
  mono "Pong.Test/NUnit-2.5.10.11092/bin/net-2.0/nunit-console.exe Pong.Test/bin/Debug/Pong.Test.dll"
end

task :run do
  mono "bin/Debug/Pong.exe"
end

task :default => :test
