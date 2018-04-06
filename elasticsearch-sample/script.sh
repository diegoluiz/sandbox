sudo su -

yum install -y epel-release
yum install -y wget vim unzip python34 python34-setuptools
easy_install-3.4 pip
pip3 install requests elasticsearch munch

cd /opt

wget --no-cookies --no-check-certificate --header "Cookie: gpw_e24=http%3A%2F%2Fwww.oracle.com%2F; oraclelicense=accept-securebackup-cookie" "http://download.oracle.com/otn-pub/java/jdk/8u131-b11/d54c1d3a095b4ff2b6607d096fa80163/jdk-8u131-linux-x64.tar.gz"
tar xzvf jdk-8u131-linux-x64.tar.gz
alternatives --install /usr/bin/java java /opt/jdk1.8.0_131/bin/java 2
alternatives --install /usr/bin/jar jar /opt/jdk1.8.0_131/bin/jar 2
alternatives --install /usr/bin/javac javac /opt/jdk1.8.0_131/bin/javac 2
alternatives --set jar /opt/jdk1.8.0_131/bin/jar
alternatives --set javac /opt/jdk1.8.0_131/bin/javac
export JAVA_HOME=/opt/jdk1.8.0_131 >> /etc/profile.d/javavars.sh
export JRE_HOME=/opt/jdk1.8.0_131/jre >> /etc/profile.d/javavars.sh
export PATH=$PATH:/opt/jdk1.8.0_131/bin:/opt/jdk1.8.0_131/jre/bin >> /etc/profile.d/javavars.sh
chmod +x /etc/profile.d/javavars.sh
. /etc/profile.d/javavars.sh

wget https://artifacts.elastic.co/downloads/elasticsearch/elasticsearch-5.5.0.rpm
rpm -i elasticsearch-5.5.0.rpm
echo network.host: 0.0.0.0 >> /etc/elasticsearch/elasticsearch.yml
service elasticsearch start

wget https://codeload.github.com/abrahamduran/bigdesk/zip/master
/usr/share/elasticsearch/bin/elasticsearch-plugin install file:///opt/master
rm -f /opt/master

wget https://artifacts.elastic.co/downloads/kibana/kibana-5.5.0-x86_64.rpm
rpm -i kibana-5.5.0-x86_64.rpm
echo server.port: 5601 >> /etc/kibana/kibana.yml 
echo server.host: 0.0.0.0 >> /etc/kibana/kibana.yml 
echo elasticsearch.url: "http://localhost:9200" >> /etc/kibana/kibana.yml 
service kibana restart

unzip /vagrant/imdb-5000-movie-dataset.zip -d /opt/
cp /vagrant/importer.py /opt/

python3 /opt/importer.py 
