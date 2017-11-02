server {
    listen 80;
    location /api {
        proxy_pass http://server:5000/api;
        proxy_http_version 1.1;
        proxy_set_header Upgrade $http_upgrade;
        proxy_set_header Connection keep-alive;
        proxy_set_header Host $host;
        proxy_cache_bypass $http_upgrade;
    }

    location / {
        root /app;
        try_files $uri /index.html;
    }
}



# Getting Started

## Prerequisites

### Virtual Machine (VirtualBox)

Install VirtualBox from https://www.virtualbox.org/wiki/Downloads

> Other hypervisors such as VMware and Hyper-V can be used but is not recommended. Vagrant's VMWare integration is not free and Hyper-V's setup is not as strightforward as VirtualBox.


### Virtual Machine Manager (Vagrant)

1) Install Vagrant from https://www.vagrantup.com/downloads.html

2) After installation, open a shell (Command Prompt / Terminal) and run the following command to install the Vagrant VirtualBox Guest Additions plugin:

```
vagrant plugin install vagrant-vbguest
```

3) For Windows users, you will also need to install the Windows Network File System plugin:
```
vagrant plugin install vagrant-winnfsd
```

### Server Development

Choose from one of the three following options. You are highly recommended to use option 1.

#### Option 1: Visual Studio 2017 (Highly Recommended)

1) Install Visual Studio 2017 from https://www.visualstudio.com/downloads/

2) When installing, ensure that you install the ".NET Core cross-platform development" workload.

> Visual Studio 2015 and before is not supported.

> If you already have Visual Studio 2017 installed, ensure that it is updated to version 15.4 or later. Also ensure that you have have the "ASP.NET and web development" or ".NET Core cross-platform development" workload installed.

#### Option 2: Text Editor with .NET Core SDK

1) Install a text editor such as:
    - Visual Studio Code https://code.visualstudio.com/
    - Sublime Test https://www.sublimetext.com/
    - Atom https://atom.io/

2) Install a C# plugin or extension for your text editor:
    - Visual Studio Code https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp
    - Sublime Text comes preinstalled with C# support
    - Atom https://atom.io/packages/language-csharp

3) Install the .NET Core SDK from https://www.microsoft.com/net/download/

#### Option 3: Text Editor with .NET Core SDK in Vagrant

Follow steps 1 and 2 from option 2.

### Server Testing (Postman)

Install Postman from  https://www.getpostman.com/

### Client Development

1) Install a text editor such as:
    - Visual Studio Code https://code.visualstudio.com/
    - Sublime Test https://www.sublimetext.com/
    - Atom https://atom.io/

1) Install a Babel JSX plugin or extension:
    - Visual Studio Code comes preinstalled with Babel JSX support
    - Sublime Test https://github.com/babel/babel-sublime
    - Atom https://atom.io/packages/language-babel

### Web Browser

Choose from one of the following two options:

#### Option 1: Google Chrome

1) Install Google Chrome from https://www.google.com/chrome/

> You can also use the Portable version of Google Chrome from https://portableapps.com/apps/internet/google_chrome_portable

2) Install React Developer Tools for Google Chrome from https://chrome.google.com/webstore/detail/react-developer-tools/fmkadmapgofadopljbjfkapdkoienihi

#### Option 2: Mozilla Firefox

1) Install Mozilla Firefox from https://www.mozilla.org/en-US/firefox/new/

> You can also use the Portable version of Mozilla Firefox from https://portableapps.com/apps/internet/firefox_portable

2) Install React Developer Tools for Mozilla Firefox from https://addons.mozilla.org/en-US/firefox/addon/react-devtools/

## Provisioning

Start a shell (Command Prompt / Terminal) and run the following commands to provision and setup the virtual machine:

``` sh
# Change directory to our project folder
cd /path/to/folder

# Start the virtual machine
vagrant up

# It will start running commands to setup the virtual machine

# After setup, restart the virtual machine
vagrant reload
```

## First Run

During our first run, we need to do the following:

1) Set our database password.
2) Create the database server.
3) Install project dependencies.

``` sh
# Logon to the virtual machine
vagrant ssh

# Change directory to our project folder
cd /vagrant

# Set our database password
# NOTE: The database password is stored in plain text
sh run gen-secrets

# Create the database server and install project dependencies
sh run install
```

You are now ready to start development.

## Testing

We need to use two shells to test the server. In the first shell:

``` sh
# Start the database server
cd mariadb
sh run start

# Start the backend server
cd ../server
sh run dev
```

Start another shell (Command Prompt / Terminal):

``` sh
# Change directory to our project folder
cd /path/to/project

# Logon to our VM
vagrant ssh

# Start the frontend server
cd /vagrant/client
yarn run dev
```

Open your web browser and navigate to 192.168.88.88:8080

You should be able to see the application.

# Folder Structure

``` sh
├── .git                        # Folder Git uses to track changes
├── .vagrant                    # Folder Vagrant uses to store VM info
├── client                      # Folder containing frontend source code and tests
├── mariadb                     # Folder containing database config for development use
├── nginx                       # Folder containing Nginx config for production use
├── server                      # Folder containing server source code and tests
├── .gitignore                  # Git ignores all files and folders in this file
├── .gitlab-ci.yml              # GitLab Continuous Integration configuration file
├── compose                     # Utlity script to run production servers in Docker
├── docker-compose.yml          # Dokcer Compose configuration file
├── gen-secrets                 # Utlity script to generate development and production secrets
├── README.md                   # This readme file
├── run                         # Utlity script to run various commands
├── vagrant.sh                  # Setup script to provision the VM
├── Vagrantfile                 # VM configuration file
└── Vagrantfile.local.sample    # Sample file to overwrite VM configuration
```

# Vagrant

## Configuration

The VM is configured by default run on a static IP address: 192.168.88.88

The VM is setup and provisioned using the script: vagrant.sh

The synced folder uses Network File System (NFS) by default.

Instructions to overwrite settings can be found in Vagrantfile.local.sample

## Commands

Here are some essential Vagrant commands

``` sh
# Starts the VM
vagrant up

# Stops the VM
vagrant halt

# Restarts the VM
vagrant reload

# Logon to the VM
vagrant ssh

# Suspends the VM (useful for slower machines)
vagrant suspend

# Resume the VM (useful for slower machines)
vagrant resume

# Reprovision the VM
vagrant reload --provision

# Stops the VM and destroys the VM
vagrant destroy
```

# Secrets

Secrets can be generated using the following commands:

``` sh
# Generate secrets for development
sh run gen-secrets dev

# Generate secrets for production
sh run gen-secrets prod
```

Three types of secrets will be generated:
1) Database password
2) Database host
3) Backend server host

``` sh
├── mariadb
│   ├── secrets.env                 # Generated file containing database password
│   └── secrets.env.sample          # Template file. Do not edit.
├── server
│   └── server
│       ├── secrets.json            # Generated file containing database password and host
│       └── secrets.json.sample     # Template file. Do not edit.
└── client
    ├── secrets.json                # Generated file containing server host
    └── secrets.json.sample         # Template file. Do not edit.
```

Secrets can be overwritten by setting an environment variable:

``` sh
$DATABASE_SECRET    # Base64 encoded string of the database password
$DATABASE_HOST      # Database host
$SERVER_HOST         # Backend server host
```

# Production

Ensure that you have set the production environment variables. Then generate the application secrets:

``` sh
sh run gen-secrets prod
```

Build all projects in production mode and start them using docker-compose:

``` sh
sh run compose-up
```

Stop and destroy all production servers using docker-compose without deleting database data:

``` sh
sh run compose-down
```

Delete the production database data:

``` sh
sh run compose-delete-data
```

# Commands

Generate secrets:
``` sh
# Development 
sh run gen-secrets dev

# Production
sh run gen-secrets prod
```

Create database and install project dependencies:
```
sh run install
```

Remove the unused Docker containers and images:
```
sh run docker-clean
```

Build all projects in production mode and start them usign docker-compose:
```
sh run compose-up
```

Stop and destroy all production servers using docker-compose without deleting database data:
```
sh run compose-down
```

Delete the production database data:
```
sh run compose-delete-data
```