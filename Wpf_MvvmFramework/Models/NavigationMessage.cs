using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_MvvmFramework.Models
{
    public class NavigationMessage : ValueChangedMessage<string>
    {
        public NavigationMessage(string value) : base(value)
        {
        }

        //public NavigationMessage(string value, string? oldValue) : base(value, oldValue)
        //{
        //}
    }
}
