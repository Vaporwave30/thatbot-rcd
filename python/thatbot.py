import requests, time

class rcd:
    def __init__(self, api_key):
        self.session = requests.session()
        self.session.headers["X-Api-Key"] = api_key

    def getFuncaptchaToken(self, scope, wait):
        while True:
            time.sleep(wait)
            req = self.session.post('https://roblox.developer-variety.com/api/rcd/create-task', data={"scope":scope})
            if req.status_code != 429 and req.status_code != 400:
                a = self.session.post("https://roblox.developer-variety.com/api/rcd/task-result", data={"taskId":req.json()["data"]["taskId"]}).json()
                return a["data"]["value"]

    def login(self, user, password, fctoken, *ctype):
        csrf_token = ""; ltype = "Username"; user_agent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.86 Safari/537.36"

        if ctype: ltype = ctype
        fcvalidation = requests.post(url="https://captcha.roblox.com/v1/funcaptcha/login/web", headers={"User-Agent": user_agent, "X-CSRF-TOKEN": csrf_token}, json={"credentialsType": "Username", "credentialsValue": user, "fcToken": fctoken})
        csrf_token = fcvalidation.headers["X-CSRF-TOKEN"]
        fcvalidation = requests.post(url="https://captcha.roblox.com/v1/funcaptcha/login/web", headers={"User-Agent": user_agent, "X-CSRF-TOKEN": csrf_token}, json={"credentialsType": "Username", "credentialsValue": user, "fcToken": fctoken})
       
        auth = requests.post(
            url="https://auth.roblox.com/v2/login",
            json={"ctype": "Username", "cvalue": user, "password": password},
            headers={"User-Agent":user_agent, "X-CSRF-TOKEN":csrf_token}
        )
        return auth
