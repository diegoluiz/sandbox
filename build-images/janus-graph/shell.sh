!#/bin/bash

sudo su -

sudo add-apt-repository ppa:webupd8team/java -y

apt update

echo "oracle-java8-installer shared/accepted-oracle-license-v1-1 select true" | debconf-set-selections
echo "oracle-java8-installer shared/accepted-oracle-license-v1-1 seen true" | debconf-set-selections

apt-get -y install curl unzip oracle-java8-installer
