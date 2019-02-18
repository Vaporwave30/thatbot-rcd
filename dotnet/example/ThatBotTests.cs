using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThatBotLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThatBotLib.Tests
{
    [TestClass()]
    public class ThatBotTests
    {
        [TestMethod()]
        public void LoginTest()
        {
            using (ThatBot t1 = new ThatBot("API_KEY"))
            {
               string fcToken = t1.CreateTask("login").Result;

                if (fcToken != null)
                {
                    var returnLogin = t1.Login("username", "password", fcToken).Result;

                    if (returnLogin.Success)
                    {
                        Console.WriteLine(returnLogin.Cookie);
                    }
                }
            }
        }
    }
}
