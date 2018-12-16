'use strict';

const aws = require('aws-sdk');
const uuidv4 = require('uuid/v4');

var rekognition = new aws.Rekognition({ apiVersion: '2016-06-27' });
var dynamodb = new aws.DynamoDB.DocumentClient();

exports.main = (event, context, callback) => {
    
    var key = event.Records[0].s3.object.key;
    var bucket = event.Records[0].s3.bucket.name;

    var params = {
        Image: {
            S3Object: {
                Bucket: bucket,
                Name: key
            }
        },
        Attributes: [
            'ALL'
            /* more items */
        ]

    };

    rekognition.detectFaces(params, function (err, data) {
        if (err) {
            console.log(err, err.stack); // an error occurred
            callback(err, data);
        }
        else {
            console.log(JSON.stringify(data, null, 4));
            var faces = [];
            for (var i = 0; i < data.FaceDetails.length; i++) {

                var face = mapFaceInfo(data.FaceDetails[i]);             
                var created = new Date();

                var sourceFace = {
                    Id: uuidv4(),
                    Created: created.toISOString(),
                    Mood: face
                }

                var params2 = {
                    Item: sourceFace,
                    TableName: "MoodDb"
                };

                dynamodb.put(params2, function (err, data) {
                    if (err) console.log(err, err.stack); // an error occurred
                    else {
                        console.log("put to dynamo");

                        console.log(data);           // successful response
                        callback(null, data);
                    }
                });
            }
        }

    });

};

function mapFaceInfo(info) {

    var sadVal = -1;
    var happyVal = -1;

    info.Emotions.forEach(element => {
        if (element.Type == "SAD") {
            sadVal = element.Confidence
        }

        if (element.Type == "HAPPY") {
            happyVal = element.Confidence
        }



    });

    if (sadVal > happyVal) {
        return { Mood: 'SAD', Value: sadVal }
    }

    return { Mood: 'HAPPY', Value: happyVal } ;
}