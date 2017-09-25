using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;
using System.Configuration;

namespace snoo_android
{
    public class HomePage : Main
    {


        [Test]
        public void startSnoo_test()
        {
            //app.Repl();
            String emailId = ConfigurationManager.AppSettings.Get("loginId");
            String password = ConfigurationManager.AppSettings.Get("loginPassword");
            Login.login(emailId, password);
            app.WaitForElement("dashboard_button_play", "App is taking long time to load", new TimeSpan(0, 0, 2, 0));
            app.TapCoordinates(91, 143); //open menu drawer
            app.Tap("design_menu_item_text"); //click start snoo
            app.WaitForElement("dashboard_button_play", "App is taking long time to load", new TimeSpan(0, 0, 2, 0));
            System.Threading.Thread.Sleep(10000);
            app.Tap("dashboard_button_play");
            app.WaitForElement("btn_dashboard_pause_text", "App is taking long time to load", new TimeSpan(0, 0, 2, 0));
            app.Tap("btn_dashboard_up");
            System.Threading.Thread.Sleep(10000);
            app.Screenshot("dashboard_layout");
            Assert.IsTrue(app.Query("btn_dashboard_pause_text").ElementAt(0).Text.Equals("LEVEL 1"));
            app.Tap("btn_dashboard_up");
            System.Threading.Thread.Sleep(10000);
            app.Screenshot("dashboard_layout");
            Assert.IsTrue(app.Query("btn_dashboard_pause_text").ElementAt(0).Text.Equals("LEVEL 2"));
            app.Tap("btn_dashboard_up");
            System.Threading.Thread.Sleep(10000);
            Assert.IsTrue(app.Query("btn_dashboard_pause_text").ElementAt(0).Text.Equals("LEVEL 3"));
            app.Tap("btn_dashboard_up");
            System.Threading.Thread.Sleep(10000);
            app.Screenshot("dashboard_layout");
            Assert.IsTrue(app.Query("btn_dashboard_pause_text").ElementAt(0).Text.Equals("LEVEL 4"));
            System.Threading.Thread.Sleep(5000);
            app.Tap("btn_dashboard_down");
            System.Threading.Thread.Sleep(5000);
            app.Tap("btn_dashboard_down");
            System.Threading.Thread.Sleep(5000);
            app.Tap("btn_dashboard_down");
            System.Threading.Thread.Sleep(5000);
            app.Tap("btn_dashboard_down");
            System.Threading.Thread.Sleep(5000);
            app.Screenshot("dashboard_layout");
            app.Tap("btn_dashboard_pause_text");
        }
        public void snoo_levels()
        {
            //app.Flash();
            //app.WaitForElement("dashboard_button_play");
            app.Tap("dashboard_button_play");
            app.Tap("btn_dashboard_up");
            app.Tap("btn_dashboard_up");
            app.Tap("btn_dashboard_up");
            app.Tap("btn_dashboard_up");
            app.Tap("btn_dashboard_down");
            app.Tap("btn_dashboard_down");
            app.Tap("btn_dashboard_down");
            app.Tap("btn_dashboard_down"); 
        }

    }

}