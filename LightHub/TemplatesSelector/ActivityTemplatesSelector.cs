using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using LightHub.Constant;

namespace LightHub.TemplatesSelector
{
    public class ActivityTemplatesSelector : DataTemplateSelector
    {
        public DataTemplate PushEventTemplate { get; set; }
        public DataTemplate WatchEventTemplate { get; set; }
        public DataTemplate IssuesEventTemplate { get; set; }
        public DataTemplate IssueCommentEventTemplate { get; set; }
        public DataTemplate CreateEventTemplate { get; set; }
        public DataTemplate ForkEventTemplate { get; set; }
        public DataTemplate ReleaseEventTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            Octokit.Activity activity = item as Octokit.Activity;
            switch (activity?.Type)
            {
                case Const.pushEvent:
                    return PushEventTemplate;

                case Const.watchEvent:
                    return WatchEventTemplate;

                case Const.issuesEvent:
                    return IssuesEventTemplate;

                case Const.issueCommentEvent:
                    return IssueCommentEventTemplate;

                case Const.createEvent:
                    return CreateEventTemplate;

                case Const.forkEvent:
                    return ForkEventTemplate;

                case Const.releaseEvent:
                    return ReleaseEventTemplate;

                default:
                    return base.SelectTemplateCore(item, container); 
            }
        }
    }
}
