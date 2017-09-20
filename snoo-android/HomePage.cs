using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;


namespace snoo_android
{
    public class HomePage : Main
    {
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