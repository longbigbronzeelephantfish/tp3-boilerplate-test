Vagrant.configure("2") do |config|
  config.vm.box = "centos/7"
  config.vm.provision :shell, path: "vagrant.sh"
  config.vm.network "private_network", ip: "192.168.88.88"

  config.vm.synced_folder ".", "/vagrant", type: "nfs"
  # config.vm.synced_folder ".", "/vagrant", type: "rsync"
  # config.vm.synced_folder ".", "/vagrant", type: "virtualbox"

  config.vm.post_up_message = "hello"

  config.vm.provider "virtualbox" do |v|
    v.cpus = 2
    v.name = "project"
    v.memory = 2048
  end

  # If a Vagrantfile.local file exists, import it
  if File.exist? "Vagrantfile.local"
    instance_eval File.read("Vagrantfile.local"), "Vagrantfile.local"
  end
end