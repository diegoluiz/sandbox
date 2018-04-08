!#/bin/bash

[ ! -f /vagrant/janusgraph-0.2.0-hadoop2.zip ] && wget https://github.com/JanusGraph/janusgraph/releases/download/v0.2.0/janusgraph-0.2.0-hadoop2.zip -P /vagrant/

sudo mkdir -p /opt/janusgraph
sudo chmod 777 -R /opt/janusgraph

unzip /vagrant/janusgraph-0.2.0-hadoop2.zip -d /opt/janusgraph/

#/opt/janusgraph/janusgraph-0.2.0-hadoop2/bin/janusgraph.sh start
