# Errors Toolbox

## 6.1.0

- API Design guidelines: ExtraInfo should be used instead of ExtraParameters

## 6.0.0

- Upgrade to .Net Standard 2.1 for LTS

## 5.2.0

- BadGatewayException added
- GatewayTimeoutException added
- Unit tests updated
- Readme updated

## 5.1.0

- ForbiddenException added.
- Bug: UnauthorizedException maps now to HTTP status code 401 instead of 403

## 5.0.0

- conversion to csproj and MSBuild.

## 4.0.0
- Added support for custom errorcodes.
- Fixed Error deserialization problem 

## 3.0.0
- Error model has changed
  - All methods related to adding messages have been removed
- BaseException has changed 
  - All methods related to adding messages from Error have been relocated here 
- ExceptionMapper has been introduced
  - This will map exceptions to errors instead of letting the exceptions containing an Error model

## 2.0.0

- Upgrade to .NET Core 1.0

## 1.2.1

- Removed http status codes
- Added constructor overload to Error object

## 1.0.0

- initial version

