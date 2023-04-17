using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace taller
{

        [Activity(Label = "taller", MainLauncher = true)]
        public class LoginActivity : Activity
        {
            private EditText _usernameEditText;
            private EditText _passwordEditText;
            private Button _loginButton;

            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.activity_login);

                _usernameEditText = FindViewById<EditText>(Resource.Id.usernameEditText);
                _passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
                _loginButton = FindViewById<Button>(Resource.Id.loginButton);

                _loginButton.Click += LoginButton_Click;
            }

            private void LoginButton_Click(object sender, System.EventArgs e)
            {
                var username = _usernameEditText.Text;
                var password = _passwordEditText.Text;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    Toast.MakeText(this, "Por favor, ingrese nombre de usuario y contraseña", ToastLength.Long).Show();
                    return;
                }

                if (username == "a" && password == "a")
                {
                    Toast.MakeText(this, "Bienvenido!", ToastLength.Long).Show();
                    StartActivity(typeof(MainActivity));
                }
                else
                {
                    Toast.MakeText(this, "Usuario o contraseña invalidos", ToastLength.Long).Show();
                }
            }
        }
    }