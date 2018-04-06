FROM diegoluiz/debian:8.8

MAINTAINER Diego Luiz

WORKDIR /
RUN wget https://github.com/nats-io/gnatsd/releases/download/v0.9.6/gnatsd-v0.9.6-linux-amd64.zip && \
unzip gnatsd-v0.9.6-linux-amd64.zip && \
mkdir /nats && \
mv /gnatsd-v0.9.6-linux-amd64/gnatsd /nats/ && \
rm -Rf /gnatsd-v0.9.6-linux-amd64 gnatsd-v0.9.6-linux-amd64.zip 

EXPOSE 4222 6222 8222 

CMD ["/nats/gnatsd"]

