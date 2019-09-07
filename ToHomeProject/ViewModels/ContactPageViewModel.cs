using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using ToHomeProject.Helper;
using ToHomeProject.Models;
using ToHomeProject.Views;
using Xamarin.Forms;

namespace ToHomeProject.ViewModels
{
    public class ContactPageViewModel : INotifyPropertyChanged
    {
        public ContactModel contact { get; set; }

        public ICommand SaveContactsCommand { get; set; }

        public string Result { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ContactPageViewModel()
        {
            contact = new ContactModel();
            SaveContactsCommand = new Command(async () =>
            {
                if (UserValidations.NumberIsNotEmpty(contact.CelNumber))
                {
                    MessagingCenter.Send<ContactPageViewModel, ContactModel>(this, "SendContact", contact);

                    await Application.Current.MainPage.Navigation.PopModalAsync();
                }else
                    Result = "El Numero telefonico es requerido.";


            });
        }

    }
}
