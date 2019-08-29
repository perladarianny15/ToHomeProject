using System;
using System.ComponentModel;
using System.Windows.Input;
using ToHomeProject.Helper;
using ToHomeProject.Models;
using ToHomeProject.Views;
using Xamarin.Forms;

namespace ToHomeProject.ViewModels
{
    public class RegisterPageViewModel : INotifyPropertyChanged
    {
        public RegisterModel RegisterData { get; set; }
        public ICommand SaveRegisterData { get; set; }
        public string Result { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public RegisterPageViewModel()
        {
            RegisterData = new RegisterModel();

            SaveRegisterData = new Command(async () =>
            {
                if (!UserValidations.IsnotEmpty(RegisterData.UserName))
                {
                    Result = "El nombre de usuario es requerido";
                }
                else if (!UserValidations.IsnotEmpty(RegisterData.Email))
                {
                    Result = "El Email de usuario es requerido";
                }
                else if (!UserValidations.IsnotEmpty(RegisterData.Password) || !UserValidations.IsnotEmpty(RegisterData.ConfirmPassword))
                {
                    Result = "Las contraseña es requerida ";
                }
                else if (!UserValidations.IsEqual(RegisterData.Password, RegisterData.ConfirmPassword))
                {
                    Result = "Las contraseñas no coinciden";
                }
                else
                {
                    await Application.Current.MainPage.Navigation.PushModalAsync(new HomePage());
                }
            });
        }

    }
}
