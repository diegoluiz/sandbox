'use strict';

var req = require('request')

var slackUrl = 'http://slackurl'

module.exports.github = (event, context, callback) => {
  var body = event.body.trim().replace('payload=', '')
  body = JSON.parse(body)
  var text = body.text
  var channel = (event.queryStringParameters && event.queryStringParameters.channel) || body.channel

  if (channel[0] != '@' && channel[0] != '#') {
    channel = '#' + channel
  }

  var payload = {
    payload: {
      channel,
      text
    }
  }

  console.log('Posting: [' + JSON.stringify(payload) + ']')

  var options = {
    url: slackUrl,
    method: 'POST',
    body: payload,
    headers: {
      'Content-Type': 'application/json'
    }
  };

  req(options, (err, res) => {
    if (err) {
      console.log(err)
      callback(null, { statusCode: 500, body: JSON.stringify({ message: err, input: event }) });
      return
    }

    callback(null, {
      statusCode: 200,
      body: JSON.stringify({
        message: 'Posted',
        input: event,
      }),
    });
  })
};
