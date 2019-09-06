using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ToHomeProject.Models;
using Xamarin.Forms;

namespace ToHomeProject.ViewModels
{
    public class ContactPageListViewModel
    {
        public ObservableCollection<ContactModel> Contacts { get; set; } = new ObservableCollection<ContactModel>();

        public ICommand DeleteElementCommand { get; set; }

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

        public ContactPageListViewModel()
        {
            ContactModel myContact = new ContactModel();

            myContact.FirstName = "prueba01ß";
            Contacts.Add(myContact);


            DeleteElementCommand = new Command<ContactModel>(async (param) =>
            {
                var result = await App.Current.MainPage.DisplayActionSheet("Menu", "Cancel", "Destruction");
                Contacts.Remove(param);

            });

            MessagingCenter.Subscribe<ContactPageViewModel, ContactModel>(this, myContact.FirstName, ((sender, param) =>
            {
                MessagingCenter.Unsubscribe<ContactPageViewModel, ContactModel>(this, myContact.FirstName);
            }));
        }

        void OnSelectItem(ContactModel contact)
        {
            ContactModel myContact = new ContactModel();
            myContact.FirstName = "New Student";

            Contacts.Add(myContact);
        }
    }
}
