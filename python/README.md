# thatbot.py
A simple Python module for thatbot/rcd using Python 3.7+. 

## Usage
Download/save the module file [here](https://example.com) and drag it to your script's directory.
### Example:
![example](https://i.imgur.com/K5OGp11.png)
### Initialization
To start off, call the module by importing it
```python
import thatbot
```
Then, call the thatbot class. Remember to provide your API key.
```python
bot = thatbot.rcd(API KEY HERE)
```
### Getting Funcaptcha token (fctoken):
Currently, RCD supports 3 different scopes; login, signup, action
```python
token = bot.getFuncaptchaToken("login") #gets login fctoken
```
### Making a Roblox login:
This returns a raw request's response, you can fetch headers, cookies, text and more from it. Function supports email log-ins, to do it add "ctype" parameter to the function call. Accepted types: "Email" and "PhoneNumber". "Username" is default. 
```python
rcd.login(USER, PASSWORD, fcToken)
```
