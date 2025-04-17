using System.Windows;
using System.Windows.Controls;
using Wpf_MvvmFramework.ViewModels;

namespace Wpf_MvvmFramework.Views
{
    //  title를 ViewModel의 Title 프로퍼티를 바인딩하도록 수정했습니다. 
    //  DockPanel을 배치, 메뉴, Frame를 배치했습니다.
    //  만들려는 프레임워크에서는 Frame을 이용해서 각 Page를 네비게이션 시켜서 사용하게 될 것입니다.
    //  메뉴 Header에 _를 입력한 이유는 alt키를 이용해서 단축키로 접근하는 이름을 지정하기 위해서 입니다.
    //  alt+f를 눌러보시면 확인하실 수 있습니다.
    //  메뉴를 클릭하면 FrameBehavior에 바인딩된 NavigationSource 프로퍼티가 변경되고
    //  FrameBehavior는 NavigationSource 프로퍼티가 변경되면, Navigate()를 호출합니다.

    //  FrameBehavior는 ViewModel의 NavigationSource 프로퍼티와 바인딩이 되어 있습니다.
    //  xaml에서 behavior를 사용하기 위해서는 xmlns:behaviors="clr-namespace:WpfFramework.Behaviors" 네임스페이스를 추가해야합니다.
    //  Frame 컨트롤에 위에서 만든 FrameBehavior을 추가해주고, NavigationSource DP에는 뷰모델에 있는 NavigationSource 프로퍼티를 TwoWay로 바인딩 해줍니다.
    //  Master메뉴를 추가하고, 하위 메뉴로 Code Management, Customer Management를 추가했습니다.
    //  Customer Management 메뉴를 클릭하면, 뷰모델의 NavigateCommand를 실행하면서, CommandParameter로는 Views/CustomerPage.xaml를 전달합니다.

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService(typeof(MainViewModel));
        }
    }
}