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
        public ContactModel SelectedContacts
        {
            get
            {
                return contact;
            }
            set
            {
                contact = value;

                if (contact != null)
                    OnSelectItem(contact);

            }
        }

        public ObservableCollection<ContactModel> Contacts { get; set; } = new ObservableCollection<ContactModel>();

        public ICommand DeleteElementCommand { get; set; }

        public ICommand SaveContactsCommand { get; set; }

        public ContactPageViewModel()
        {
            ContactModel myContact = new ContactModel();
            contact = new ContactModel();
            SaveContactsCommand = new Command(async () =>
            {
                myContact.FirstName = "prueba";
                myContact.FirstName = contact.FirstName;
                myContact.LastName = contact.LastName;
                myContact.Company = contact.Company;
                myContact.CelNumber = contact.CelNumber;
                myContact.Email = contact.Email;
                Contacts.Add(myContact);

                await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new ContactListPage()));


            });

            MessagingCenter.Subscribe<ContactListPage, ContactModel>(this, myContact.FirstName, ((sender, param) =>
            {
                MessagingCenter.Unsubscribe<ContactListPage, string>(this, myContact.FirstName);
            }));

            DeleteElementCommand = new Command<ContactModel>(async (param) =>
                {
                  var result = await App.Current.MainPage.DisplayActionSheet("Menu", "Cancel", "Destruction");

                });

                // MessagingCenter.Subscribe<App, string>(this, "TESTID", ((sender, param) =>
                //{
                //  MessagingCenter.Unsubscribe<App, string>(this, "TESTID");
                //}));
            }

        void OnSelectItem(ContactModel contact)
        {
            ContactModel myContact = new ContactModel();
            myContact.FirstName = "New Student";

            Contacts.Add(myContact);
        }
    }
}
