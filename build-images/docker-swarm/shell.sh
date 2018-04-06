!#/bin/bash

sudo su -
apt update
apt upgrade -y

apt-get -y install \
  apt-transport-https \
  ca-certificates \
  curl


add-apt-repository \
       "deb [arch=amd64] https://download.docker.com/linux/ubuntu \
       $(lsb_release -cs) \
       stable"

curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo apt-key add -

apt-get update

apt-get -y install docker-ce

