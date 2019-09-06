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
        //async void ToContactPage(object sender, EventArgs args)
        //{
          //  await Navigation.PushModalAsync(new ContactPage());
        //}
    }
}
