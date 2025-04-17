using Wpf_MvvmFramework.Bases;

namespace Wpf_MvvmFramework.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public static int Count { get; set; }

        public HomeViewModel()
        {
            Title = "Home";
        }

        public override void OnNavigated(object sender, object navigatedEventArgs)
        {
            Count++;
            Message = $"{Count} Navigated";
        }
    }
}
