using Microsoft.Xaml.Behaviors;
using System.Runtime.Intrinsics.Arm;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Wpf_MvvmFramework.Interfaces;

namespace Wpf_MvvmFramework.Behaviors
{
    //  ViewModel에서 Frame를 직접 컨트롤을 하기는 어렵습니다.
    //  Frame의 Navigate() 메소드와 각종 이벤트들을 사용해야 하기 때문인데
    //  이렇게 뷰모델에서 직접 접근을 하기 어려운 컨트롤이나 컴포넌트를
    //  쉽게 제어하고 사용하기 위해서는 Behavior을 만들어 주어야 합니다.
    /**  FrameBehavior.cs **/
    //  작동 방식은 FrameBehavior에 추가한 NavigationSource DP를 ViewModel의 프로퍼티와 바인딩을 한 후
    //  ViewModel에서 프로퍼티를 변경하면, 그 내용을 전달 받은 FrameBehavior가 내용을 확인해서
    //  Navigate()를 호출하던가, GoBack을 하고 됩니다.

    /// <summary>
    /// Frame 비헤이비어
    /// </summary>
    public class FrameBehavior : Behavior<Frame>
    {
        /// <summary>
        /// NavigationSource DP 변경 때문에 발생하는 프로퍼티 체인지 이벤트를 막기 위해 사용
        /// </summary>
        private bool _isWork;
        /// <summary>
        /// Navigation 속성 이름(뷰)을 저장
        /// </summary>
        public string NavigationSource
        {
            get { return (string)GetValue(NavigationSourceProperty); }
            set { SetValue(NavigationSourceProperty, value); }
        }

        protected override void OnAttached()
        {
            //네비게이션 시작
            AssociatedObject.Navigating += AssociatedObject_Navigating;
            //네비게이션 종료
            AssociatedObject.Navigated += AssociatedObject_Navigated;
        }
        /// <summary>
        /// 네비게이션 종료 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssociatedObject_Navigated(object sender, NavigationEventArgs e)
        {
            _isWork = true;
            //네비게이션이 완료된 Uri를 NavigationSource에 입력
            NavigationSource = e.Uri.ToString();
            _isWork = false;
            //네비게이션이 완료된 상황을 뷰모델에 알려주기
            if (AssociatedObject.Content is Page pageContent
                && pageContent.DataContext is INavigationAware navigationAware)
            {
                navigationAware.OnNavigated(sender, e);
            }
        }
        /// <summary>
        /// 네비게이션 시작 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssociatedObject_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            //네비게이션 시작전 상황을 뷰모델에 알려주기
            if (AssociatedObject.Content is Page pageContent
                && pageContent.DataContext is INavigationAware navigationAware)
            {
                navigationAware?.OnNavigating(sender, e);
            }
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Navigating -= AssociatedObject_Navigating;
            AssociatedObject.Navigated -= AssociatedObject_Navigated;
        }

        // DependencyProperty : DependencyObject를 상속받은 클래스에서 사용할 수 있는 속성
        // DependencyProperty는 WPF에서 제공하는 속성 시스템을 사용하여 속성을 정의할 수 있도록 해줍니다.
        // DependencyProperty는 WPF의 데이터 바인딩, 스타일, 애니메이션 등에서 사용됩니다.
        // DependencyProperty.Register() 메서드를 사용하여 속성을 등록합니다.
        // Register() 메서드는 속성의 이름, 속성의 타입, 소속된 클래스, 기본값을 인자로 받습니다.
        // DependencyProperty는 DependencyObject의 속성으로 사용되며,
        // DependencyObject는 WPF의 모든 UI 요소의 기본 클래스입니다.
        /// <summary>
        /// NavigationSource DP
        /// </summary>
        public static readonly DependencyProperty NavigationSourceProperty =
            DependencyProperty.Register(nameof(NavigationSource), typeof(string), typeof(FrameBehavior), new PropertyMetadata(null, NavigationSourceChanged));

        /// <summary>
        /// NavigationSource PropertyChanged
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void NavigationSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = (FrameBehavior)d;
            if (behavior._isWork)
            {
                return;
            }
            behavior.Navigate();
        }
        /// <summary>
        /// 네비게이트
        /// </summary>
        private void Navigate()
        {
            switch (NavigationSource)
            {
                case "GoBack":
                    //GoBack으로 오면 뒤로가기
                    if (AssociatedObject.CanGoBack)
                    {
                        AssociatedObject.GoBack();
                    }
                    break;
                case null:
                case "":
                    //아무것도 안함
                    return;
                default:
                    //navigate
                    AssociatedObject.Navigate(new Uri(NavigationSource, UriKind.RelativeOrAbsolute));
                    break;
            }
        }
    }
}
