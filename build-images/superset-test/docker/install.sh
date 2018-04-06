#!/bin/bash

export DEBIAN_FRONTEND=noninteractive
apt update
apt install -q -y build-essential libssl-dev libffi-dev python-dev python-pip libsasl2-dev libldap2-dev mysql-server libmysqlclient-dev
pip install --upgrade setuptools pip
pip install superset mysqlclient
service mysql start
mysqladmin -u root password diego
mysql -uroot -pdiegomysql -uroot -pdiego < /tmp/sakila-schema.sql
mysql -uroot -pdiegomysql -uroot -pdiego < /tmp/sakila-data.sql
fabmanager create-admin --app superset --username diego --firstname diego --lastname luiz --email diego@diegoluiz.com --password diego
superset db upgrade
superset load_examples
superset init
#nohup superset runserver -w 1 &

