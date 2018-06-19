using LightHub.Model;
using Octokit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LightHub
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Windows.UI.Xaml.Controls.Page
    {
        public static string uriStr;
        

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserAccounts.CreateOauthenUri();
        }

        //public async Task<ActionResult> Authorize(string code, string state)
        //{
        //    if (String.IsNullOrEmpty(code))
        //        return RedirectToAction("Index");

        //    //var expectedState = Session["CSRF:State"] as string;
        //    //if (state != expectedState) throw new InvalidOperationException("SECURITY FAIL!");
        //    //Session["CSRF:State"] = null;
        //    return RedirectToAction("Index");
        //}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string tokenString = UserAccounts.userAccountsList[0].GetAccessToken();
        }

        
    }
}
