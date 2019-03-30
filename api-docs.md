# API Documentation

## Notice: thabot Developers (and thatbot in general) are/is **NOT** responsible for anything you do with the token.

### POST /api/rcd/create-task
Content-Type: application/json

|Header name    |Header value   |
|---------------|---------------|
|X-Api-Key (str)|Your API Key   |

|Parameter name|Parameter value|
|--------------|---------------|
|scope (str)   |login          |


|Scopes|
|------|
|login |
|signup|
|action|

Response
```json
{"status": "true", "data": { "taskId": 1, "timestamp": 1553271937 }}
```

### POST /api/rcd/task-result
Content-Type: application/json

|Header name    |Header value   |
|---------------|---------------|
|X-Api-Key (str)|Your API Key   |

|Parameter name|Parameter value|
|--------------|---------------|
|taskId (int)   |taskId        |

Response
```json
{"status": "true", "data": { "ready": true, "value": "FCTOKEN", "timestamp": 1553271937 }}
```
