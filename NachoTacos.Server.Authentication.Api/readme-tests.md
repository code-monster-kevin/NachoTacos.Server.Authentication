# Test API Authorization
Steps to test the project

1. Configure the solution to startup multiple startup projects (Api and IdSvr)

## Get tokens
1. Open Postman, set the url to "https://localhost:51454/connect/token"

2. Configure the header Content-Type : application/x-www-form-urlencoded
![Postman Header](https://github.com/code-monster-kevin/NachoTacos.Server.Authentication/blob/master/assets/001_PostmanHead_test1.png?raw=true)

3. Configure resource owner password flow
![Resource Owner Password](https://github.com/code-monster-kevin/NachoTacos.Server.Authentication/blob/master/assets/002_PostmanBody_test1.png?raw=true)

4. Resource owner password flow response
![Authentication Response](https://github.com/code-monster-kevin/NachoTacos.Server.Authentication/blob/master/assets/003_PostmanResponse_test1.png?raw=true)

5. Configure client credentials flow
![Client credentials](https://github.com/code-monster-kevin/NachoTacos.Server.Authentication/blob/master/assets/004_PostmanBody_test2.png?raw=true)

5. Client credentials flow response
![Client credentials](https://github.com/code-monster-kevin/NachoTacos.Server.Authentication/blob/master/assets/005_PostmanResponse_test2.png?raw=true)


## Access Api Protected Resource
1. Open the API Swagger UI page

2. Enter the access token "Bearer {token}"
![Authorize Token](https://github.com/code-monster-kevin/NachoTacos.Server.Authentication/blob/master/assets/006_AuthenticateSwagger_test3.png?raw=true)

3. Execute the "Secure" Api and get the "You are authorized" response
![Authorize Response](https://github.com/code-monster-kevin/NachoTacos.Server.Authentication/blob/master/assets/007_ApiAuthorized_test3.png?raw=true)
