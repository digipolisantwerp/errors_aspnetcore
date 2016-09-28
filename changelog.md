# Errors Toolbox

## 1.0.0

- initial version

## 1.2.1

- Removed http status codes
- Added constructor overload to Error object

## 2.0.0

- Upgrade to .NET Core 1.0

## 3.0.0
- Error model has changed
  - All methods related to adding messages have been removed
- BaseException has changed 
  - All methods related to adding messages from Error have been relocated here 
- ExceptionMapper has been introduced
  - This will map exceptions to errors instead of letting the exceptions containing an Error model