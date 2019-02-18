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
            ThatBot t1 = new ThatBot("API_KEY");

            var returnLogin = t1.Login("username", "password", t1.CreateTask("login").Result).Result;

            if (returnLogin.Success)
            {
                Console.WriteLine(returnLogin.Cookie);
            }
        }
    }
}
