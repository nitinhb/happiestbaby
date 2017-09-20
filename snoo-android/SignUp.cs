using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;


namespace snoo_android
{
   
    public class SignUp : Main
    {
        [Test]
        public void SignupPage_Test()
        {
            // app.Repl();

            String firstName = "Nitin";
            String lastName = "Jindal";
            String emailId = "nitinjindal6@gmail.com";
            String password = "Nitin123";
            String passwordConfirmation = "Nitin123";
            String babyName = "John";

            //Performing signUp process
            sign_up(firstName, lastName, emailId, password, passwordConfirmation);
            //Checking if user completed sign up process and landed on my baby page 
            Assert.IsTrue(app.Query("toolbar_title").ElementAt(0).Text.Equals("My Baby"));

            //Providing baby details
            my_baby_page(babyName);
            Assert.IsTrue(app.Query("activity_my_baby_name").ElementAt(0).Text.Equals(babyName));
            Assert.IsTrue(app.Query("activity_my_baby_date_of_birth").ElementAt(0).Text.Equals("October 20, 2017"));
            Assert.IsTrue(app.Query("activity_my_baby_premie_weeks").ElementAt(0).Text.Equals("5 Weeks"));

            //Complete sign up 
            app.Tap("activity_my_baby_next_button");
            System.Threading.Thread.Sleep(10000);
            //Checking sign up process completed
            Assert.IsTrue(app.Query("toolbar_title").ElementAt(0).Text.Equals("Set Up My SNOO"));

            //Logout
            app.Tap("btn_logout");
        }

        private void my_baby_page(string babyName)
        {
            app.Tap("activity_my_baby_name");
            app.EnterText("John");
            app.Tap("activity_my_baby_date_of_birth_til");
            app.Tap("next");
            app.TapCoordinates(760, 1104);
            app.Tap("button1");
            app.Tap("activity_my_baby_gender_boy");
            app.Tap("activity_my_baby_is_preemie");
            app.ScrollDown();
            app.Tap("activity_my_baby_premie_weeks");
            app.TapCoordinates(537, 1106);
            app.Tap("button1");
        }

        private void sign_up(string firstName, string lastName, string emailId, string password, string passwordConfirmation)
        {
            app.Tap("btn_signup");
            app.Tap("activity_signup_first_name_til");
            app.EnterText(firstName);
            app.Tap("activity_signup_last_name_til");
            app.EnterText(lastName);
            app.Tap("activity_signup_email_til");
            app.EnterText(emailId);
            app.Back();
            app.Tap("activity_signup_password_til");
            app.EnterText(password);
            app.Tap("text_input_password_toggle");
            app.PressEnter();
            app.Tap("activity_signup_password_confirm_til");
            app.EnterText(password);
            app.Tap("activity_signup_button");
            System.Threading.Thread.Sleep(10000);
        }
    }
}