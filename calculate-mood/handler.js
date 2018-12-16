'use strict';

const aws = require('aws-sdk');
const uuidv4 = require('uuid/v4');

var dynamodb = new aws.DynamoDB.DocumentClient();

exports.main = function (event, context, callback) {

  var params = {
    TableName: 'MoodDb',
    FilterExpression: 'Created > :created',
    ExpressionAttributeValues: { ':created': '2018-12-13' }
  };

  dynamodb.scan(params, function (err, data) {
    if (err) {
      console.log(err);
    }
    else {

      var sadCount = 0;
      var happyCount = 0;

      data.Items.forEach(element => {
       
        if (element.Mood.Mood == "SAD") {
          sadCount = sadCount + 1;

        }
        else {
          happyCount = happyCount + 1;
        }       

      });


      var result = {
        happyCount: happyCount,
        sadCount: sadCount

      }

      callback(null, result);

    }

  });

};