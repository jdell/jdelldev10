using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;
using com.mxply.net.common.EventAggregator;

namespace com.mxply.app.baseball.client.wpf.Core
{
    public class Cache : INotifyPropertyChanged
    {
        public Stack<String> History { get; private set; }
       
        public String PreviousPageName { get; set; }

        public Cache()
        {
            History = new Stack<string>();
        }

//        public ConcelloCambreServiceClient CreateService()
//        {
//            string endPointName = "basicHttpOptimized";
//#if DEBUG
//            endPointName = "basicHttpOptimizedDebug";
//#endif
//            return new ConcelloCambreServiceClient(endPointName);
//        }


        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

    public abstract class Common
    {
        public static void ShowMessage(String message)
        {
            try
            {
                System.Windows.MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                HandleError("Common", ex);
            }
        }
        public static void HandleError(string nameVM, Exception ex)
        {
            try
            {
                System.Windows.MessageBox.Show(ex.Message, "Exception: " + nameVM);
                Trace.TraceError(string.Format("{0} - {1}", nameVM, ex.ToString()));
                //LogUtil.Manager.Error(nameVM, ex);
            }
            catch (Exception exi)
            {
                System.Windows.MessageBox.Show(exi.Message, "Exception: Common");
            }
        }
        public static void NavigateTo(string page)
        {
            try
            {
                page.PublishEvent("NavigateToPageEvent");
            }
            catch (Exception ex)
            {
                HandleError("Common", ex);
            }
        }
    }
}
