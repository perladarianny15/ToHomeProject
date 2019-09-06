using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ToHomeProject.Models;
using ToHomeProject.Views;
using Xamarin.Forms;

namespace ToHomeProject.ViewModels
{
    public class ContactPageViewModel
    {
        public ContactModel contact { get; set; }

        public ObservableCollection<ContactModel> Contacts { get; set; } = new ObservableCollection<ContactModel>();

        public ICommand SaveContactsCommand { get; set; }

        public ContactPageViewModel()
        {
            ContactModel myContact = new ContactModel();
            contact = new ContactModel();
            SaveContactsCommand = new Command(async () =>
            {
                myContact.FirstName = contact.FirstName;
                myContact.LastName = contact.LastName;
                myContact.Company = contact.Company;
                myContact.CelNumber = contact.CelNumber;
                myContact.Email = contact.Email;
                Contacts.Add(myContact);

                MessagingCenter.Send(this, myContact.FirstName, Contacts);
                //await Application.Current.MainPage.Navigation.PopAsync(new ContactListPage());
                await Application.Current.MainPage.Navigation.PushModalAsync(new ContactListPage());

            });



                // MessagingCenter.Subscribe<App, string>(this, "TESTID", ((sender, param) =>
                //{
                //  MessagingCenter.Unsubscribe<App, string>(this, "TESTID");
                //}));
            }

    }
}
