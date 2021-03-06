﻿using System;
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


using ContactsPlus.Source;
using ContactsPlus.Models;
using ContactsPlus.Views;
using Windows.UI.Popups;
using System.Diagnostics;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace ContactsPlus
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

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

      

            listContacts.DataContext = Database.contacts;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            AddEditContact.currentContact = null;
            Frame.Navigate(typeof(AddEditContact));

        }

        private async void listContacts_Tapped(object sender, TappedRoutedEventArgs e) {
            ContactModel item = (ContactModel)listContacts.SelectedItem;

            if (item != null && item.ContactId > 0) {
                ContactModel contact = Database.getContactById(item.ContactId);

                if(contact == null) {

                    MessageDialog dlgMessage = new MessageDialog("Unable to load contact!");
                    await dlgMessage.ShowAsync();
                } else {

                    AddEditContact.currentContact = contact;
                    Frame.Navigate(typeof(AddEditContact));
                }

            }
            
        }
    }
}
