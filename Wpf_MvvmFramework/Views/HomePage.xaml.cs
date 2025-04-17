using System.Windows.Controls;
using Wpf_MvvmFramework.ViewModels;

namespace Wpf_MvvmFramework.Views
{
    /// <summary>
    /// HomPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService(typeof(HomeViewModel));
        }
    }
}
