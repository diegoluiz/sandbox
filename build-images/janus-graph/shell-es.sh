!#/bin/bash

[ ! -f /vagrant/elasticsearch-6.2.3.deb ] && wget https://artifacts.elastic.co/downloads/elasticsearch/elasticsearch-6.2.3.deb -P /vagrant

sudo dpkg -i /vagrant/elasticsearch-6.2.3.deb

sudo service elasticsearch restart
