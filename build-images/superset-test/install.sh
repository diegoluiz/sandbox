#!/bin/bash

export DEBIAN_FRONTEND=noninteractive

echo "Installing dependencies"
apt update
apt install -q -y build-essential libssl-dev libffi-dev python-dev python-pip libsasl2-dev libldap2-dev mysql-server libmysqlclient-dev vim
pip install --upgrade setuptools pip
pip install superset mysqlclient

echo "Configuring MySQL"
service mysql start
mysqladmin -u root password diego

echo "Loading Sakila"
mysql -uroot -pdiegomysql -uroot -pdiego < /sakila/sakila-schema.sql
mysql -uroot -pdiegomysql -uroot -pdiego < /sakila/sakila-data.sql

echo "Configuring Superset"
fabmanager create-admin --app superset --username diego --firstname diego --lastname luiz --email diego@diegoluiz.com --password diego
superset db upgrade
superset load_examples
superset init

service mysql restart

echo "service mysql start" > /etc/rc.local
echo "exit 0" >> /etc/rc.local
