using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snoo_android
{
    class SetUpMySnoo : Main
    {
        [Test]
        public void getStartedTab_test()
        {
            enterMySnooPage();
            app.WaitForElement("activity_my_device_sensitivity_container", "Taking long time to load", new TimeSpan(0, 0, 1, 0));
            app.Tap("activity_my_device_setup_button");
            System.Threading.Thread.Sleep(5000);
            app.Tap("btn_next");
            app.WaitForElement("scanning_label", "Taking long time to load", new TimeSpan(0, 0, 1, 0));
            app.Screenshot("scanning_label");
            app.TapCoordinates(80, 160); //go back
            app.Tap("btn_logout");
        }

        [Test]
        public void settingMySnoo_test()
        {
            enterMySnooPage();
            app.Tap("activity_my_device_sensitivity_label");
            app.Tap("sensitivity_two");
            app.Tap("activity_my_device_sensitivity_label");
            Assert.IsTrue(app.Query("activity_my_device_sensitivity_value_label").ElementAt(0).Text.Equals("+2"));
            app.Tap("activity_my_device_sensitivity_label");
            app.Tap("sensitivity_zero");
            app.Tap("activity_my_device_sensitivity_label");
            Assert.IsTrue(app.Query("activity_my_device_sensitivity_value_label").ElementAt(0).Text.Equals("Normal"));
            app.Tap("activity_my_device_level_limiter");
            app.TapCoordinates(80, 160); //go back
            Logout.logout_test();
        }

        private void enterMySnooPage()
        {
            String emailId = ConfigurationManager.AppSettings.Get("loginId");
            String password = ConfigurationManager.AppSettings.Get("loginPassword");
            Login.login(emailId, password);
            app.WaitForElement("dashboard_button_play", "Taking long time to load", new TimeSpan(0, 0, 1, 0));
            app.TapCoordinates(91, 143); //open menu drawer
            System.Threading.Thread.Sleep(10000);
            app.TapCoordinates(250, 721);
            System.Threading.Thread.Sleep(10000);
            app.Tap("activity_settings_my_snoo_button");
        }

    }
}
