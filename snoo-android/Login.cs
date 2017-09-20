using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;


namespace snoo_android
{

    public class Login : Main
    {
        [Test]
        public void loginPage_test()
        {
            //app.Repl();
            String emailId = "jindaln@gmail.com";
            String password = "Xgfrg120";
            login(emailId, password);
        }

        [Test]
        public void start_snoo_test()
        {
            String emailId = "jindaln@gmail.com";
            String password = "Xgfrg120";
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

        [Test]
        public void app_setting_test()
        {
            //Opens repl window
            //app.Repl();

            //setting => my baby 
            setting_change_name_test();
            //Check name is changed
            Assert.IsTrue(app.Query("activity_my_baby_name").ElementAt(0).Text.Equals("Test baby"));

            setting_change_birth_date();
            //check date is changed
            Assert.IsTrue(app.Query("activity_my_baby_date_of_birth").ElementAt(0).Text.Equals("June 14, 2017"));

            //Checking boy/girl radio buttons
            System.Threading.Thread.Sleep(5000);
            app.Tap("activity_my_baby_gender_boy");
            app.Screenshot("activity_my_baby_date_of_birth_til");
            System.Threading.Thread.Sleep(5000);
            app.Tap("activity_my_baby_gender_girl");
            app.Screenshot("activity_my_baby_date_of_birth_til");

            //Testing setting my profile
            String firstName="Nitin";
            String lastName = "Jindal";
            setting_my_profile_name_change(firstName, lastName);
            //Checking name is updated
            Assert.IsTrue(app.Query("activity_my_profile_first_name_text").ElementAt(0).Text.Equals(firstName));
            Assert.IsTrue(app.Query("activity_my_profile_last_name_text").ElementAt(0).Text.Equals(lastName));


            firstName = "nit";
            lastName = "jin";
            setting_my_profile_name_change(firstName, lastName);
            //Checking name is updated
            Assert.IsTrue(app.Query("activity_my_profile_first_name_text").ElementAt(0).Text.Equals(firstName));
            Assert.IsTrue(app.Query("activity_my_profile_last_name_text").ElementAt(0).Text.Equals(lastName));

            //Testing about page
            about_test();

            //Logout test
            logout_test();

        }

        [Test]
        public void password_change_test()
        {
            String emailId = "jindaln@gmail.com";
            String newPassword = "Xgfrg121";
            String oldPassword = "Xgfrg120";


            //Logging in
            login(emailId, oldPassword);
            System.Threading.Thread.Sleep(10000);
            setting_password_change(emailId, newPassword);
            app.WaitForElement("dashboard_button_play", "app taking too long", new TimeSpan(0, 0, 2, 0));
            logout_test();
            System.Threading.Thread.Sleep(10000);
            //Setting old password again    
            login(emailId, newPassword);
            System.Threading.Thread.Sleep(10000);
            setting_password_change(emailId, oldPassword);
            app.WaitForElement("dashboard_button_play", "app is taking too long", new TimeSpan(0, 0, 2, 0));
            logout_test();

        }

        private void setting_password_change(String emailId,String newPasseord)
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
            logout_test();
            System.Threading.Thread.Sleep(10000);
            login(emailId,newPasseord);

        }

        private void setting_my_profile_name_change(String firstName,String lastName)
        {
            System.Threading.Thread.Sleep(5000);
            app.TapCoordinates(108, 150); //press back button
            app.Tap("activity_settings_my_profile_button");
            System.Threading.Thread.Sleep(10000);
            app.Tap("activity_my_profile_first_name_text");
            System.Threading.Thread.Sleep(2000);
            app.ClearText();
            app.EnterText(firstName);
            System.Threading.Thread.Sleep(5000);
            app.Tap("activity_my_profile_last_name_text");
            System.Threading.Thread.Sleep(2000);
            app.ClearText();
            app.EnterText(lastName);
            System.Threading.Thread.Sleep(5000);
            app.Tap("activity_my_profile_button");
            System.Threading.Thread.Sleep(5000);
            app.Tap("activity_settings_my_profile_button");
            System.Threading.Thread.Sleep(5000);
        }

        private void setting_change_birth_date()
        {
            app.Tap("activity_my_baby_date_of_birth"); //click date picker
            app.TapCoordinates(315, 1111);             //set date to 14th june
            app.Tap("button1"); 					   //set the date press ok
            app.Tap("activity_my_baby_date_of_birth"); //click date picker
            app.TapCoordinates(558, 1106);             //select date to 14th june
            app.Tap("button1"); 					   //set the date press ok
        }

        private void setting_change_name_test()
        {
            String emailId = "jindaln@gmail.com";
            String password = "Xgfrg120";
            login(emailId,password);
            System.Threading.Thread.Sleep(10000);
            app.WaitForElement("dashboard_button_play", "Taking too long to open", new TimeSpan(0, 0, 2, 0));
            app.TapCoordinates(91, 143); //open menu drawer
            System.Threading.Thread.Sleep(10000);
            app.TapCoordinates(250, 721);
            System.Threading.Thread.Sleep(10000);
            app.Tap("activity_settings_my_baby_button");
            System.Threading.Thread.Sleep(5000);
            app.Tap("activity_my_baby_name");
            app.ClearText();
            System.Threading.Thread.Sleep(5000);
            app.EnterText("Test baby");
            System.Threading.Thread.Sleep(5000);
            app.TapCoordinates(108, 150);
            System.Threading.Thread.Sleep(5000);
            app.Tap("activity_settings_my_baby_button");
            System.Threading.Thread.Sleep(5000);
        }

        public void about_test()
        {
            System.Threading.Thread.Sleep(5000);
            app.TapCoordinates(108, 150); //press back button
            System.Threading.Thread.Sleep(5000);
            app.TapCoordinates(91, 143); //open menu drawer
            System.Threading.Thread.Sleep(5000);
            app.TapCoordinates(300, 840); //about 
       }

       private void logout_test()
       {
            System.Threading.Thread.Sleep(5000);
            app.TapCoordinates(91, 143); //open menu drawer
            System.Threading.Thread.Sleep(5000);
            app.TapCoordinates(200, 970); //logout
            System.Threading.Thread.Sleep(5000);
            app.Screenshot("btn_login");
        }


        public void login(String emailId,String password)
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