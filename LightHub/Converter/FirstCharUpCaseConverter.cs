using LightHub.Constant;
using System;
using Windows.UI.Xaml.Data;

namespace LightHub.Converter
{
    public class FirstCharUpCaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch (value as string)
            {
                case Const.opened:
                    return "Opened";

                case Const.reopened:
                    return "Reopened";

                case Const.closed:
                    return "Closed";

                case Const.unassigned:
                    return "Unassigned";

                case Const.assigned:
                    return "Assigned";

                case Const.unlabeled:
                    return "Unlabeled";

                case Const.labeled:
                    return "Labeled";

                case Const.edited:
                    return "Edited";

                case Const.milestoned:
                    return "Milestoned";

                case Const.demilestoned:
                    return "Demilestoned";

                case Const.created:
                    return "Created";

                case Const.deleted:
                    return "Deleted";

                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
