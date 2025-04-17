using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_MvvmFramework.Bases
{
    /// <summary>
    /// 뷰모델 베이스
    /// </summary>
    public abstract class ViewModelBase : ObservableObject
    {
        private string? _title;
        /// <summary>
        /// 타이틀
        /// </summary>
        public string Title
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
    }
}
