using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_MvvmFramework.Bases;

namespace Wpf_MvvmFramework.ViewModels
{
    /// <summary>
    /// 메인 뷰모델 클래스입니다.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public MainViewModel()
        {
            Title = "메인 뷰";
        }
    }
}
