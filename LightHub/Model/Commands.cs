using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LightHub.Model
{
    public class NaviToUserDetail : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public static event EventHandler OnNaviToUserDetailReady;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Activity activity = parameter as Activity;
            OnNaviToUserDetailReady(activity.Actor, null);
        }
    }
}
