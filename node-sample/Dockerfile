FROM debian

LABEL Description="This is my Node CD Test" Vendor="Diego Luiz" Version="0.2"

RUN mkdir -p /opt/node-sample
ADD * /opt/node-sample/

RUN apt-get update && apt-get install -y curl && curl -sL https://deb.nodesource.com/setup_4.x | bash - && apt-get install -y nodejs && cd /opt/node-sample && npm install

CMD ["node", "/opt/node-sample/app.js"]

EXPOSE 3000