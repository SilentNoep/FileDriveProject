using Client.Infra;
using Common;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class SignInViewModel : ViewModelBase
    {
        #region Members
        INavigationService _navigationService;
        IUserService _userService;
        IDialogService _messageService;
        private string _email;
        private string _password;
        #endregion

        #region Properties

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                RaisePropertyChanged();
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged();
            }
        }



        #endregion

        #region Commands
        public RelayCommand SignInUserCommand { get; set; }
        public RelayCommand GoToRegisterView { get; set; }
        #endregion

        public SignInViewModel(INavigationService navigationService, IUserService userService, IDialogService messageService)
        {
            _navigationService = navigationService;
            _userService = userService;
            _messageService = messageService;
            InitCommands();
        }

        #region Methods
        public void InitCommands()
        {
            SignInUserCommand = new RelayCommand(async () =>
            {
                if (Email == "" || Email == null || Password == "" || Password == null)
                {
                   await _messageService.ShowMessage("Username & Password are required!", "Invalid Input");
                    return;
                }
                if (Password.Length < 4 || Email.Length < 4)
                {
                   await _messageService.ShowMessage("Username & Password Must Have Atleast 4 Characters", "Invalid Input");
                    return;
                }
                User user = new User() { Email = Email, Password = Password };
                Email = "";
                Password = "";

                User UserFromDB = await _userService.SignIn(user);
                if (UserFromDB == null)
                    await _messageService.ShowMessage("Cant Connect", "Sign In");
                else
                {
                    await _messageService.ShowMessage("You Successfully Logged In!", "GREAT!");
                    _navigationService.NavigateTo("ListFiles", UserFromDB);
                }

            });


            GoToRegisterView = new RelayCommand(() =>
            {
                Email = "";
                Password = "";
                _navigationService.NavigateTo("Register");
            });
        }
        #endregion
    }
}
