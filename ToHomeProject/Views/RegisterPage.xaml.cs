using System;
using System.Collections.Generic;
using ToHomeProject.ViewModels;
using Xamarin.Forms;

namespace ToHomeProject.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new RegisterPageViewModel();
        }
    }
}
