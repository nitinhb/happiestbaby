using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;
using System.Configuration;
using System.Collections.Specialized;

namespace snoo_android
{

    public class Login : Main
    {
        [Test]
        public void loginPage_test()
        {
            String emailId = ConfigurationManager.AppSettings.Get("loginId");
            String password = ConfigurationManager.AppSettings.Get("loginPassword");
            login(emailId, password);
        }

        [Test]
        public void startSnoo_test()
        {
            String emailId = ConfigurationManager.AppSettings.Get("loginId");
            String password = ConfigurationManager.AppSettings.Get("loginPassword");
            login(emailId, password);
            app.WaitForElement("dashboard_button_play", "Upload is taking too long", new TimeSpan(0, 0, 1, 0));
            app.TapCoordinates(91, 143); //open menu drawer
            app.Tap("design_menu_item_text"); //click start snoo
            System.Threading.Thread.Sleep(10000);
            app.Tap("dashboard_button_play");
            System.Threading.Thread.Sleep(10000);
            app.Tap("btn_dashboard_up");
            System.Threading.Thread.Sleep(10000);
            app.Tap("btn_dashboard_down");
            System.Threading.Thread.Sleep(5000);
            app.Tap("btn_dashboard_pause_text");
        }
      

        public static void login(String emailId,String password)
        {
            app.WaitForElement("btn_login", "Taking too long to open", new TimeSpan(0, 0, 2, 0));
            app.Tap("btn_login");
            app.Tap("til_email");
            app.EnterText(emailId);
            app.Tap("til_password");
            app.EnterText(password);
            app.Tap("text_input_password_toggle");
            app.Tap("activity_login_button");
            app.Screenshot("activity_login_button");
        }

    }
}