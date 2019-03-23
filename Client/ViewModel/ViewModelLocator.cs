using Client.Infra;
using Client.Services;
using Client.ViewModel;
using Client.Views;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;

namespace Client.ViewModel
{

    public class ViewModelLocator
    {

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //viewmodels
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SignInViewModel>();
            SimpleIoc.Default.Register<RegisterViewModel>();
            SimpleIoc.Default.Register<ListFilesViewModel>();
            SimpleIoc.Default.Register<UploadFileViewModel>();
            //services
            SimpleIoc.Default.Register<IUserService,UserService>();
            SimpleIoc.Default.Register<IFileService, FileService>();
            var navService = new NavigationService();
            navService.Configure("Register", typeof(RegisterView));
            navService.Configure("SignIn", typeof(SignInView));
            navService.Configure("ListFiles", typeof(ListFilesView));
            navService.Configure("UploadFile", typeof(UploadFileView));
            SimpleIoc.Default.Register<INavigationService>(() => navService);

            var dialog = new Services.DialogService();
            SimpleIoc.Default.Register<IDialogService>(() => dialog);
        }

        public MainViewModel MainVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>(Guid.NewGuid().ToString());
            }
        }
        public SignInViewModel SignInVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SignInViewModel>(Guid.NewGuid().ToString());
            }
        }
        public RegisterViewModel RegisterVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RegisterViewModel>(Guid.NewGuid().ToString());
            }
        }
        public ListFilesViewModel ListFilesVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ListFilesViewModel>(Guid.NewGuid().ToString());
            }
        }
        public UploadFileViewModel UploadFileVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UploadFileViewModel>(Guid.NewGuid().ToString()); 
            }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}