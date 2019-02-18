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
            ThatBot t1 = new ThatBot("cc21e57d-5b2b-4870-9b2f-837e8cf54836");

            var returnLogin = t1.Login("xleky1", "harder87", t1.CreateTask("login").Result).Result;

            if (returnLogin.Success)
            {
                Console.WriteLine(returnLogin.Cookie);
            }
        }
    }
}