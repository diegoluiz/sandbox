const AWS = require('aws-sdk')

const s3 = new AWS.S3()

const get = (bucketName, item) => {
  const s3 = new AWS.S3(this.options)
  return s3.getObject({
    Bucket: bucketName,
    Key: item
  }).promise().then((response) => {
    return {
      ContentLength: response.ContentLength,
      body: JSON.parse(new Buffer(response.Body, 'base64').toString('utf8'))
    }
  })
}

const displayMemoryUsage = () => {
  console.log(`Memory usage ${JSON.stringify(process.memoryUsage())}`)
}

module.exports.getAll = (event, context, callback) => {
  const bucketName = process.env.bucketName

  console.log('reading from ' + bucketName)

  displayMemoryUsage()
  return s3.listObjects({
    Bucket: bucketName,
    MaxKeys: 1000
  }).promise()
    .then((result) => {
      return result.Contents
    })
    .then(docs => {
      console.log('marker ',docs[docs.length - 1].Key)
      return s3.listObjects({
        Bucket: bucketName,
        Marker: docs[docs.length - 1].Key,
        MaxKeys: 1000
      }).promise()
        .then((result) => {
          return result.Contents
        })
        .then(result => {
          return docs.concat(result)
        })
    })
    .then(docs => {
      const totalSizeExpected = docs.map(item => item.Size).reduce((x, y) => x + y)
      let totalSize = 0
      let totalLoadedItems = 0

      displayMemoryUsage()

      return Promise.all(docs.map(doc => {
        return get(bucketName, doc.Key)
          .then((item) => {
            if (totalLoadedItems % 100 == 0) {
              displayMemoryUsage()
            }

            totalSize += item.ContentLength
            totalLoadedItems++
          })
      }))
        .then(() => {
          return Promise.resolve({
            statusCode: 200,
            body: { totalSizeExpected, totalSize, totalLoadedItems, totalFoundItems: docs.length }
          })
        })
    })
    .then((response) => {
      callback(null, response)
    })
};
