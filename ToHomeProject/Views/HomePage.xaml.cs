using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ToHomeProject.Views
{
    public partial class HomePage : MasterDetailPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        async void LogOut(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}
