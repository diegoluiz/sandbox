FROM debian:8.8

MAINTAINER Diego Luiz

RUN \
  apt-get update && \
  apt-get install -y build-essential && \
  apt-get install -y software-properties-common && \
  apt-get install -y byobu curl git htop man unzip vim wget sudo

CMD ["/bin/bash"]

