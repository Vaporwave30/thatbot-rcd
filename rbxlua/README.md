# ThatBot Roblox Lua Module and Functions

A module uploaded to roblox which can be used to interact with thatbot/RCD endpoints.
Should be used server-sided on a normal script as it interacts with the HttpService.

## Functions

```
create_task(api_key, scope) Creates a new task and returns an table containing "success" and "taskId" if success is true.
```
```
wait_for_task_completion(api_key, taskId) Takes in the task and waits (pauses thread) until RCD/ThatBot has solved the captcha. Returns a table containing "success" and "fctoken" if success is true.
```

## Further information
The module returns the above functions. 

It has already been uploaded to Roblox as a public module so that you don't have to copy the whole source behind the module, just require it.
The public module can by required with the following ID: 2964156739.

See the examples to see further information about how to interact and use these functions.

After getting the fctoken using the functions from the module, you can then send it to an API endpoint using Roblox's HttpService and do what you wish with the fctoken.
Because Roblox blocks all http requests to the roblox.com domain (and subdomains) from the http service, you cannot use the fctoken directly in Roblox and needs to be sent to a server or something to actually be used.