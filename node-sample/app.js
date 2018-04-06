'use strict';

var express = require('express');
var bodyParser = require('body-parser');

var app = express();

var dbHost = process.env.databaseHost || '';
var port = process.env.port || 3000;

app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

app.get('/', function (req, res) {
    var name = req.query.name || '[Not defined]';
    res.send({
        name: 'Your name is ' + name + '. :)',
        host: dbHost
    });
});

console.log('Host ' + dbHost);
console.log('Listening....');

app.listen(port);
