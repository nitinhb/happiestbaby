using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snoo_android
{
    class Logout : Main
    {
        [Test]
        public void logout()
        {
            String emailId = ConfigurationManager.AppSettings.Get("loginId");
            String password = ConfigurationManager.AppSettings.Get("loginPassword");
            Login.login(emailId, password);
            app.WaitForElement("dashboard_button_play", "Upload is taking too long", new TimeSpan(0, 0, 1, 0));
            logout_test();
        }

        public static void logout_test()
        {
            System.Threading.Thread.Sleep(5000);
            app.TapCoordinates(91, 143); //open menu drawer
            System.Threading.Thread.Sleep(5000);
            app.TapCoordinates(200, 970); //logout
            System.Threading.Thread.Sleep(5000);
            app.Screenshot("btn_login");
        }

    }
}
