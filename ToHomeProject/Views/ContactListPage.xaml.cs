using System;
using System.Collections.Generic;
using System.Windows.Input;
using ToHomeProject.Models;
using ToHomeProject.ViewModels;
using Xamarin.Forms;

namespace ToHomeProject.Views
{
    public partial class ContactListPage : ContentPage
    {
        public ContactListPage()
        {
            InitializeComponent();
            BindingContext = new ContactPageViewModel();

            var refresh = new ToolbarItem
            {
                Priority = 0,
                Order = ToolbarItemOrder.Primary,
                Text = "Add",


                Command = new Command(() => Navigation.PushModalAsync(new NavigationPage(new ContactPage())))

                };
            ToolbarItems.Add(refresh);

            ContactModel myContact = new ContactModel();

            MessagingCenter.Send<ContactListPage, ContactModel>(this, myContact.FirstName, myContact);

        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");
        }
    }
}
