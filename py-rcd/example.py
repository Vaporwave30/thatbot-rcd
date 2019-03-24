import requests

headers = {"X-Api-Key": ""} #put your api key here
scrope = "login" #put the scope here

def create_task():
    print("Creating task...")
    create_task_url = "https://roblox.developer-variety.com/api/rcd/create-task"
    params = {"scope": scope}
    r = requests.post(url=create_task_url, headers=headers, params=params).json()
    if r["status"] == "success":
        task_id = r["data"]["taskId"]
        print("Task created! Waiting for process.")
        return task_id
    elif r["status"] == "error":
        print("Creating task error -> {}".format(r["data"]["message"]))
        return False


def task_result():
    task_result_url = "https://roblox.developer-variety.com/api/rcd/task-result"
    task_id = create_task()
    if task_id != False:
        params = {"taskID": task_id}
        r = requests.post(url=task_result_url, headers=headers, params=params).json()
        if r["status"] == "success":
            fctoken = r["data"]["fctoken"]
            print("Got fctoken: {}".format(fctoken))
        elif r["status"] == "error":
            print("Task result error -> {}".format(r["data"]["message"]))


task_result() #it returns the fctoken
