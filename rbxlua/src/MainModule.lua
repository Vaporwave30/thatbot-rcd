-- Roblox API for RCD Created by TheRealFloof
-- RCD Github: https://github.com/dev-variety/thatbot-rcd

-- Functions return arrays like... {['success'] = false, ['reason'] = 'Invalid API key.'}

local endpoints = {
	["createTask"] = 'https://roblox.developer-variety.com/api/rcd/create-task',
	["taskResult"] = 'https://roblox.developer-variety.com/api/rcd/task-result',
}


local function create_task(api_key, scope) -- provide the function with your api key and captcha type/scope
	--if not check_http() then return {['success'] = false, ['reason'] = 'Http is not enabled. Please enable http requests in the HttpService.'} end
	
	local response = nil
	local r, e = pcall(function()
		response = game:GetService('HttpService'):RequestAsync({
			Url = endpoints.createTask,
			Method = 'POST',
			Headers = {
				["Content-Type"] = 'application/json',
				["X-Api-Key"] = api_key,
			},
			Body = game:GetService('HttpService'):JSONEncode({scope=scope})
		})
	end)
	
	if response == nil then
		return {['success'] = false, ['reason'] = 'Http request failed. See error.', ['error'] = e}
	end
	
	local status = response.StatusCode
	local body = response.Body
	local decode = nil
	pcall(function()
		decode = game:GetService('HttpService'):JSONDecode(body)
	end)
	
	if decode == nil then
		return {['success'] = false, ['reason'] = 'Could not JSON decode request body.', ['status'] = status}
	end
	
	local status = decode['status']
	if status == 'success' then
		return {['success'] = true, ['task'] = decode.data.taskId}
	elseif status == 'error' then
		local e = decode.data.message
		if decode.data['additionalMessage'] then
			e = e..', '..decode.data.additionalMessage
		end
		return {['success'] = false, ['reason'] = e, ['status'] = status}
	end
	
end

local function wait_for_task_completion(api_key, task)
	--if not check_http() then return {['success'] = false, ['reason'] = 'Http is not enabled. Please enable http requests in the HttpService.'} end
	
	local fctoken = nil
	local tries = 0
	local max_tries = 5
	repeat wait(4)
		pcall(function()
			local response = nil
			local r, e = pcall(function()
				response = game:GetService('HttpService'):RequestAsync({
					Url = endpoints.taskResult,
					Method = 'POST',
					Headers = {
						["Content-Type"] = 'application/json',
						["X-Api-Key"] = api_key,
					},
					Body = game:GetService('HttpService'):JSONEncode({taskId=task})
				})
			end)
			
			if response == nil then
				return
			end
			
			local status = response.StatusCode
			local body = response.Body
			local decode = nil
			pcall(function()
				decode = game:GetService('HttpService'):JSONDecode(body)
			end)
			
			if decode == nil then
				return
			end
			
			local status = decode['status']
			if status == 'success' then
				fctoken = decode.data.value
			end
		end)
		tries = tries + 1
	until fctoken or tries >= max_tries
	
	if fctoken == nil then
		return {['success'] = false, ['reason'] = 'Failed to get solved fctoken within 20 seconds.'}
	else
		return {['success'] = true, ['fctoken'] = fctoken} 
	end
end

return {
	create_task = create_task,
	wait_for_task_completion = wait_for_task_completion
}