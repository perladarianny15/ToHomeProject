using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ToHomeProject.Models;
using ToHomeProject.Views;
using Xamarin.Forms;

namespace ToHomeProject.ViewModels
{
    public class ContactPageListViewModel
    {
        public ObservableCollection<ContactModel> Contacts { get; set; } = new ObservableCollection<ContactModel>();

        public ICommand DeleteElementCommand { get; set; }

        public ICommand GoToNewContactCommand { get; set; }

        public ICommand EditElementCommand { get; set; }


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
            }
        }

        public ContactPageListViewModel()
        {
            ContactModel myContact = new ContactModel();

            DeleteElementCommand = new Command<ContactModel>(async (param) =>
            {
                var result = await App.Current.MainPage.DisplayActionSheet("Menu", "Cancel", "Delete");
                Contacts.Remove(param);

            });

            GoToNewContactCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new ContactPage()));

                MessagingCenter.Subscribe<ContactPageViewModel, ContactModel>(this, "SendContact", ((sender, param) =>
                {
                    Contacts.Add(param);
                    MessagingCenter.Unsubscribe<ContactPageViewModel, ContactModel>(this, "SendContact");
                }));
            });
            EditElementCommand = new Command<ContactModel>(async (param) =>
            {
                string action = await App.Current.MainPage.DisplayActionSheet("Opciones", "Cancel", "Edit", $"Call+ {param.CelNumber}");

                if (action.Contains("Edit"))
                {
                    await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new ContactPage()));
                }else if (action.Contains("Call"))
                {
                    OnSelectItem(param);
                }
            });
        }

        async void OnSelectItem(ContactModel contact)
        {
            await App.Current.MainPage.DisplayAlert("Calling", $"Calling+ {contact.CelNumber}", "Cancel");

        }
    }
}
