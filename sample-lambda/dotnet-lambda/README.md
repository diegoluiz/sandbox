# Build and deploy
```
./build.sh
```

# Configure the Custom Domain Name in the API gateway
[https://console.aws.amazon.com/apigateway/home?region=us-east-1#/custom-domain-names](https://console.aws.amazon.com/apigateway/home?region=us-east-1#/custom-domain-names)

# Run performance test
```
ab -n 3000 -c 2 {your custom domain}
```
