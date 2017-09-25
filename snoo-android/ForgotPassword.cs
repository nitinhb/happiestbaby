using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snoo_android
{
    class ForgotPassword : Main
    {
        [Test]
        public void forgot_passowrd_test()
        {
            String emailId = ConfigurationManager.AppSettings.Get("emailId");
            app.WaitForElement("btn_login", "App taking long time to load", new TimeSpan(0, 0, 2, 0));
            app.Tap("btn_login");
            app.Tap("til_email");
            app.EnterText(emailId);
            app.Back();
            app.Tap("btn_forgot_password");
            app.WaitForElement("alertTitle", "App taking long time to load", new TimeSpan(0, 0, 2, 0));
            app.Screenshot("alertTitle");
            Assert.IsTrue(app.Query("alertTitle").ElementAt(0).Text.Equals("Password reset link sent"));
            app.Tap("button1");

        }

        [Test]
        public void forgot_passowrd_invalid_user_test()
        {
            String emailId = "invaliduser@gmail.com";
            app.WaitForElement("btn_login", "App taking long time to load", new TimeSpan(0, 0, 2, 0));
            app.Tap("btn_login");
            app.Tap("til_email");
            app.EnterText(emailId);
            app.Back();
            app.Tap("btn_forgot_password");
            app.WaitForElement("alertTitle", "App taking long time to load", new TimeSpan(0, 0, 2, 0));
            app.Screenshot("alertTitle");
            Assert.IsTrue(app.Query("alertTitle").ElementAt(0).Text.Equals("Error"));
            Assert.IsTrue(app.Query("message").ElementAt(0).Text.Equals("No account was found with that email. Please try again"));
            app.Tap("button1");

        }
    }
}
