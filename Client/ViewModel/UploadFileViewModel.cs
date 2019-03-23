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
    public class UploadFileViewModel : ViewModelBase
    {
        #region Fields
        INavigationService _navigationService;
        IUserService _userService;
        IDialogService _messageService;
        IFileService _fileService;
        private User _myUser;
        private File _fileToUpload;
        private string _description;
        #endregion

        #region Properties
        public string Description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged(); }
        }
        public File FileToUpload
        {
            get { return _fileToUpload; }
            set { _fileToUpload = value; RaisePropertyChanged(); }
        }
        public User MyUser
        {
            get { return _myUser; }
            set { _myUser = value; RaisePropertyChanged(); }
        }
        #endregion

        #region Commands
        public RelayCommand BrowseFileCommand { get; set; }
        public RelayCommand UploadFileCommand { get; set; }
        public RelayCommand SignOutCommand { get; set; }
        public RelayCommand GoToListFilesView { get; set; }
        #endregion

        public UploadFileViewModel(INavigationService navigationService, IUserService userService, IDialogService messageService, IFileService fileService)
        {
            _messageService = messageService;
            _navigationService = navigationService;
            _userService = userService;
            _fileService = fileService;
            MyUser = new User();
            Description = "";

            BrowseFileCommand = new RelayCommand(async () =>
            {
                FileToUpload = await _fileService.Browse();
                if (FileToUpload != null)
                    FileToUpload.UserID = MyUser.UserID;  
            });
            UploadFileCommand = new RelayCommand(async () =>
            {
                if (FileToUpload != null)
                {
                    FileToUpload.Description = Description;
                    if (await _fileService.UploadFile(FileToUpload))
                        await _messageService.ShowMessage("Upload Complete", "Success");
                    else
                        await _messageService.ShowMessage("Failed to Upload", "Failed");
                }
                FileToUpload = null;
                Description = "";
            });

            SignOutCommand = new RelayCommand(() =>
            {
                _navigationService.NavigateTo("SignIn");
            });
            GoToListFilesView = new RelayCommand(() =>
            {
                _navigationService.NavigateTo("ListFiles", MyUser);
            });
        }
    }
}
