# ThatBot C# Library

A library used for our service, thatbot. 

## Dependencies

Compile with Microsoft .NET Framework 4.7+ or reference System.ValueTuple 3.2+

Newtonsoft.json

## Methods

```
CreateTask(string scope) returns the funcaptcha token.
```
```
Login(string Username, string Password, string Token) returns a Tuple<bool Success, string Cookie>.
``` 
