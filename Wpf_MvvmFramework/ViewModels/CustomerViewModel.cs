using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf_MvvmFramework.Bases;
using Wpf_MvvmFramework.Models;

namespace Wpf_MvvmFramework.ViewModels
{
    public class CustomerViewModel : ViewModelBase
    {
        public ICommand? BackCommand { get; set; }

        public CustomerViewModel()
        {
            Init();
        }

        private void Init()
        {
            Title = "Customer";
            BackCommand = new RelayCommand(OnBack);
        }

        private void OnBack()
        {
            WeakReferenceMessenger.Default.Send(new NavigationMessage("GoBack"));
        }

        public override void OnNavigated(object sender, object navigatedEventArgs)
        {
            Message = "Navigated";
        }
    }
}
