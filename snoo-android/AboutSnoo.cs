using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snoo_android
{
    class AboutSnoo : Main
    {
        [Test]
        public void WhatIsSnoo()
        {
            app.Tap(c => c.Marked("btn_about"));
            System.Threading.Thread.Sleep(10000);
            app.Screenshot("CalabashRootView");
        }

    }
}
