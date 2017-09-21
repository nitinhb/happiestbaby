using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;
using System.Configuration;
using NUnit.Framework;

namespace snoo_android
{
    class SplashScreen : Main
    {
        [Test]
        public void splashScreen_test()
        {
            app.WaitForElement("btn_login", "Taking too long to open", new TimeSpan(0, 0, 2, 0));
            app.Screenshot("btn_config");
            System.Threading.Thread.Sleep(5000);
            Assert.IsTrue(app.Query("btn_login").ElementAt(0).Text.Equals("Log In"));
            Assert.IsTrue(app.Query("btn_signup").ElementAt(0).Text.Equals("Sign Up"));
            Assert.IsTrue(app.Query("btn_about").ElementAt(0).Text.Equals("WHAT IS SNOO?"));

        }

    }
}
