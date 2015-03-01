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
using ContactsPlus.Source;
using Windows.Phone.UI.Input;
using System.ComponentModel;

using Windows.UI.Popups;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace ContactsPlus.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddEditContact : Page
    {
        public static ContactModel currentContact = null;

        public AddEditContact()
        {
            this.InitializeComponent();

            // Add back button event
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e){

            if (currentContact != null) {
                labelTitle.Text = "Edit Contact";

                txtFirstName.Text = currentContact.FirstName;
                txtLastName.Text = currentContact.LastName;
                txtPrimaryNumber.Text = currentContact.PrimaryNumber;
                txtSecondaryNumber.Text = currentContact.SecondaryNumber;

            }
        }

        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e) {
            Frame frame = Window.Current.Content as Frame;

            if (frame == null) {
                return;
            }

            if (frame.CanGoBack) {
                frame.GoBack();
                e.Handled = true;
            }
        }

        private async void buttonSave_Click(object sender, RoutedEventArgs e) {


            ContactModel contact = new ContactModel();
            contact.FirstName = txtFirstName.Text;
            contact.LastName = txtLastName.Text;
            contact.PrimaryNumber = txtPrimaryNumber.Text;
            contact.SecondaryNumber = txtSecondaryNumber.Text;

            if (String.IsNullOrEmpty(contact.FirstName) && String.IsNullOrEmpty(contact.LastName)) {

                MessageDialog dlgMessage = new MessageDialog("You must provide a first or last name!");
                await dlgMessage.ShowAsync();
            } else {

                if (currentContact == null) {
                    // new contact

                    if (Database.addContact(contact)) {
                        // successful

                        MessageDialog dlgMessage = new MessageDialog("Contact Saved!");
                        await dlgMessage.ShowAsync();

                        if (Frame.CanGoBack) {
                            Frame.GoBack();
                        }
                    } else {
                        // error
                        MessageDialog dlgMessage = new MessageDialog("Unable to save contact!");
                        await dlgMessage.ShowAsync();

                    }
                } else {
                    // update existing contact
                    contact.ContactId = currentContact.ContactId;

                    if (Database.updateContact(contact)) {
                        // successful

                        MessageDialog dlgMessage = new MessageDialog("Contact Updated!");
                        await dlgMessage.ShowAsync();

                        if (Frame.CanGoBack) {
                            Frame.GoBack();
                        }
                    } else {
                        // failed

                        MessageDialog dlgMessage = new MessageDialog("Unable to update contact!");
                        await dlgMessage.ShowAsync();
                    }
                }
            }

           

        }
    }
}
