# ThatBot Roblox Lua Module and Functions

A module uploaded to roblox which can be used to interact with thatbot/RCD endpoints.
Should be used server-sided on a normal script as it interacts with the HttpService.

## Functions

```
create_task(api_key, scope) Creates a new scope and returns an table containing "success" and "taskId" if success is true.
```
```
wait_for_task_completion(api_key, taskId) Takes in the task and waits (pauses thread) until RCD/ThatBot has solved the captcha. Returns an table containing "success" and "fctoken" if success is true.
```

## Further information
The module returns the above functions. The module has already been uploaded to Roblox as a public module so that you don't have to copy the whole behind the module.
The public module can by requiring the following: 2964156739.

See the examples to see further information about how to interact and use these functions.