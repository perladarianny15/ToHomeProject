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
            BindingContext = new ContactPageListViewModel();

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
    }
}
