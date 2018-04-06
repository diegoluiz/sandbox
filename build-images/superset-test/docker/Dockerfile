FROM ubuntu:16.04

MAINTAINER Diego Luiz

ADD ./install.sh /tmp/install.sh
ADD ./start.sh /tmp/start.sh
ADD ./sakila-db/sakila-data.sql /tmp/sakila-data.sql
ADD ./sakila-db/sakila.mwb /tmp/sakila.mwb
ADD ./sakila-db/sakila-schema.sql /tmp/sakila-schema.sql

RUN /bin/bash /tmp/install.sh 

# Adding this will expose mysql on a random host port. It's recommended to avoid this. Other containers on the same 
# host can use the service without it.
EXPOSE 8088

CMD ["/bin/sh"]
