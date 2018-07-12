using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using LightHub.Constant;

namespace LightHub.TemplatesSelector
{
    public class ActivityTemplatesSelector : DataTemplateSelector
    {
        public DataTemplate PushEventTemplate { get; set; }
        public DataTemplate WatchEventTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            Octokit.Activity activity = item as Octokit.Activity;
            switch (activity?.Type)
            {
                case Const.pushEvent:
                    return PushEventTemplate;

                case Const.watchEvent:
                    return WatchEventTemplate;

                default:
                    return base.SelectTemplateCore(item, container); 
            }
        }
    }
}
