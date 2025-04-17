using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf_MvvmFramework.Bases;
using Wpf_MvvmFramework.Behaviors;
using Wpf_MvvmFramework.Models;

namespace Wpf_MvvmFramework.ViewModels
{
    /// <summary>
    /// 메인 뷰모델 클래스입니다.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        //  NavigationSource 프로퍼티를 변경하는 2가지 방법이 있습니다.
        //  하나는 NavigateCommand를 실행하는 것이고, 다른 하나는 Toolkit.Mvvm에 존재하는 기능인 Message 기능을 활용하는 것입니다.
        //
        //  네비게이션 방법을 정리 하면 다음과 같습니다.
        //  메뉴에서 NavigateCommand와 페이지 주소를 입력 받음 -> NavigationSource 변경 ->
        //  FrameBehavior.NavigationSource DP의 값 변경 -> PropertyChanged가 발생 ->
        //  FrameBehavior 내부에 Navigate() 메소드가 실행되면서 페이지 이동 ->
        //  페이지가 이동되기전에 뷰모델에 OnNavigating 메소드 실행 -> 페이지 이동 완료 후 OnNavigated 메소드 실행
        //  다른 화면에서 뒤로가기 버튼 클릭 -> Messenger를 이용해서 NavigationMessage 발생 -> MainViewModel에서 메시지 수신 ->
        //  NavigationSource 변경 -> 나머지는 위와 같음

        /// <summary>
        /// 생성자
        /// </summary>
        public MainViewModel()
        {
            Title = "메인 뷰";
            Init();
        }

        private void Init()
        {
            //시작 페이지 설정
            NavigationSource = "Views/HomePage.xaml";
            NavigateCommand = new RelayCommand<string>(OnNavigate);

            //네비게이션 메시지 수신 등록
            WeakReferenceMessenger.Default.Register<NavigationMessage>(this, OnNavigationMessage);
        }

        /// <summary>
        /// 네비게이션 메시지 수신 처리
        /// </summary>
        /// <param name="recipient"></param>
        /// <param name="message"></param>
        private void OnNavigationMessage(object recipient, NavigationMessage message)
        {
            NavigationSource = message.Value;
        }

        private void OnNavigate(string? pageUri) => NavigationSource = pageUri!;
        //{
        //    NavigationSource = pageUri!;
        //}

        private string? _navigationSource;
        /// <summary>
        /// 네비게이션 소스
        /// </summary>
        public string NavigationSource
        {
            get 
            {
                _navigationSource ??= string.Empty; // null일 경우 string.Empty로 초기화
                return _navigationSource; 
            }
            set { SetProperty(ref _navigationSource, value); }
        }
        /// <summary>
        /// 네비게이트 커맨드
        /// </summary>
        public ICommand? NavigateCommand { get; set; }
    }
}
