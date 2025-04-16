using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_MvvmFramework.Bases
{
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
                    _title = "타이틀 null 에러";

                return _title; 
            }
            set { SetProperty(ref _title, value); }
        }
    }
}
