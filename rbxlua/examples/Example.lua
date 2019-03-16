local RCD = require(2964156739) 

-- the above module is open source meaning that it should not be affected by the ROBLOX Februrary update...
-- to private main modules.

local api_key = '' -- your RCD api key
local scope = 'login' -- what scope/type of captcha should be solved

print('Getting task...')
local taskIdR = RCD.create_task(api_key, scope) -- Pauses thread until a task is made
if taskIdR['success'] == false then
	print(taskIdR['reason'])
	return
end

local taskId = taskIdR['task']
print('Got task:', taskId)
print('Getting fctoken...')
local completion = RCD.wait_for_task_completion(api_key, taskId) -- Will pause current thread until fctoken is available.
if completion['success'] == false then
	print(completion['reason'])
	return
end

local fctoken = completion['fctoken']
print('Got fctoken:', fctoken)

-- The fctoken can then be used for the scope you provided
-- You can do this by sending it to an API endpoint.