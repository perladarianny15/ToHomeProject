using System;
using System.ComponentModel;
using System.Windows.Input;
using ToHomeProject.Helper;
using ToHomeProject.Models;
using ToHomeProject.Views;
using Xamarin.Forms;

namespace ToHomeProject.ViewModels
{
    public class LoginPageViewModel: INotifyPropertyChanged
    {
        public LoginModel UserData { get; set; }
        public ICommand SaveLoginDataCommand { get; set; }
        public ICommand ToRegistePage { get; private set; }
        public string Result { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public LoginPageViewModel()
        {
            UserData = new LoginModel();

            SaveLoginDataCommand = new Command(async () =>
            {
                if (!UserValidations.IsnotEmpty(UserData.UserName))
                {
                    Result = "El nombre de usuario es requerido";
                }
                else if (!UserValidations.IsnotEmpty(UserData.Password))
                {
                    Result = "La contraseña es requerida.";
                }
                else
                {
                    await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new ContactListPage() { BackgroundColor = Color.CadetBlue}));
                }
            });

            ToRegistePage = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
            });

        }
    }
}
