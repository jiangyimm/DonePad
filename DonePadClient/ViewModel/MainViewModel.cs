using System.Threading;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;
using DonePadClient.Models;
using System;
using System.Diagnostics;
using System.Reflection;

namespace DonePadClient.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            LogOutCommand=new RelayCommand(DoLogOutCommand,()=>true);
            UpdateUserNameAsync();
        }

        private void DoLogOutCommand()
        {
            App.Current.Shutdown();
            Process.Start(Assembly.GetExecutingAssembly().Location);
        }

        private void UpdateUserNameAsync()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(500);
                    UserName = GetInstance<User>().UserName;
                }
            });
        }
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChanged();
            }
        }

        private ICommand _logOutCommand;

        public ICommand LogOutCommand
        {
            get { return _logOutCommand; }
            set
            {
                _logOutCommand = value;
                RaisePropertyChanged();
            }
        }
    }
}