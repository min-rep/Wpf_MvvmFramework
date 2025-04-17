using CommunityToolkit.Mvvm.ComponentModel;
using Wpf_MvvmFramework.Interfaces;

namespace Wpf_MvvmFramework.Bases
{
    //  뷰모델에서 INavigationAware를 ViewModelBase의 인터페이스로 추가하고, 2개의 메서드를 구현하면서
    //  virtual 메소드로 변경했습니다. 해당 메소드들을 사용하려면 override해서 사용하면 됩니다.
    /// <summary>
    /// 뷰모델 베이스
    /// </summary>
    public abstract class ViewModelBase : ObservableObject, INavigationAware
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public ViewModelBase()
        {
            //생성자에서 타이틀을 설정합니다.
            Title = "타이틀 없음";
        }

        private string? _title;
        /// <summary>
        /// 타이틀
        /// </summary>
        public string? Title
        {
            get 
            {
                if (_title == null)
                    _title = "타이틀 없음";
                return _title; 
            }
            //SetProperty()메서드: Binding을 이용해서 프로퍼티와 연결 시킨다,
            //데이터가 변경이 되었을 때, 변경된 내용을 알려주는 역할
            set { SetProperty(ref _title, value); }
        }

        private string? _message;
        /// <summary>
        /// 메시지
        /// </summary>
        public string Message
        {
            get 
            {
                _message ??= string.Empty;  // null일 경우 string.Empty로 초기화   (c# 8.0 이상)
                return _message;
            }
            set { SetProperty(ref _message, value); }
        }
        
        /// <summary>
        /// 네비게이션 시작 이벤트 핸들러
        /// </summary>
        public virtual void OnNavigating(object sender, object navigationEventArgs) { }
        
        /// <summary>
        /// 네비게이션 종료 이벤트 핸들러
        /// </summary>
        public virtual void OnNavigated(object sender, object navigatedEventArgs) { }

    }
}
