using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snoo_android
{
    class PasswordChange : Main
    {
        [Test]
        public void password_change_test()
        {
            String emailId = ConfigurationManager.AppSettings.Get("loginId"); ;
            String newPassword = ConfigurationManager.AppSettings.Get("newPassword"); ;
            String oldPassword = ConfigurationManager.AppSettings.Get("loginPassword"); ;

            //Logging in
            Login.login(emailId, oldPassword);
            System.Threading.Thread.Sleep(10000);
            setting_password_change(emailId, newPassword);
            app.WaitForElement("dashboard_button_play", "app taking too long", new TimeSpan(0, 0, 2, 0));

            Logout.logout_test();
            System.Threading.Thread.Sleep(10000);
            //Setting old password again    
            Login.login(emailId, newPassword);
            System.Threading.Thread.Sleep(10000);
            setting_password_change(emailId, oldPassword);
            app.WaitForElement("dashboard_button_play", "app is taking too long", new TimeSpan(0, 0, 2, 0));
            Logout.logout_test();

        }

        private void setting_password_change(String emailId, String newPasseord)
        {
            System.Threading.Thread.Sleep(10000);
            app.TapCoordinates(91, 143); //open menu drawer
            System.Threading.Thread.Sleep(10000);
            app.TapCoordinates(250, 721);
            System.Threading.Thread.Sleep(10000);
            app.Tap("activity_settings_my_profile_button");
            System.Threading.Thread.Sleep(5000);
            app.Tap("activity_my_profile_password_text");
            app.EnterText(newPasseord);
            app.PressEnter();
            app.EnterText(newPasseord);
            app.Back();
            app.Tap("activity_my_profile_button");
            Logout.logout_test();
            System.Threading.Thread.Sleep(10000);
            Login.login(emailId, newPasseord);

        }

    }
}
