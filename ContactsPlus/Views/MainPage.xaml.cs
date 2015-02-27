using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

using ContactsPlus.Models;
using ContactsPlus.Views;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace ContactsPlus
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //public static List<String> ContactsStr;
        public static List<ContactModel> ContactsList;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
         

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.

            ContactsList = new List<ContactModel>();

            ContactModel item = new ContactModel();
            item.ContactId = 1;
            item.FirstName = "Bob";
            item.LastName = "Marley";
            item.PrimaryNumber = 7145689658;
            
            ContactsList.Add(item);

            item = new ContactModel();
            item.ContactId = 2;
            item.FirstName = "Homer";
            item.LastName = "Simpson";
            item.PrimaryNumber = 5623698541;

            ContactsList.Add(item);


            //ContactsStr = new List<string>();
            //ContactsStr.Add("test1");
            //ContactsStr.Add("test2");
            //ContactsStr.Add("test3");
            //ContactsStr.Add("test4");

            listContacts.DataContext = ContactsList;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e) {

        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e) {
         
            
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

            Frame.Navigate(typeof(AddContact));

        }
    }
}
