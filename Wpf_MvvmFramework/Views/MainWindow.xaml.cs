using System.Windows;
using System.Windows.Controls;
using Wpf_MvvmFramework.ViewModels;

namespace Wpf_MvvmFramework.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    //title를 ViewModel의 Title 프로퍼티를 바인딩하도록 수정했습니다. 
    //DockPanel을 배치, 메뉴, Frame를 배치했습니다.
    //만들려는 프레임워크에서는 Frame을 이용해서 각 Page를 네비게이션 시켜서 사용하게 될 것입니다.
    //메뉴 Header에 _를 입력한 이유는 alt키를 이용해서 단축키로 접근하는 이름을 지정하기 위해서 입니다.
    //alt+f를 눌러보시면 확인하실 수 있습니다.

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService(typeof(MainViewModel));
        }
    }
}