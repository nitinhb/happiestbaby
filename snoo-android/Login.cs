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