using System;
using System.Collections.Generic;
using Contacts.Classes;
using SQLite;
using Xamarin.Forms;
using System.Linq;

namespace Contacts
{
    public partial class EditContact : ContentPage
    {

        int currentID;
  


        public EditContact(int id, string fName, string sName, string email, string mobile, string address)
        {
            InitializeComponent();

            currentID = id;
            FirstNameEntry.Text = fName;
            SurnameEntry.Text = sName;
            EmailEntry.Text = email;
            MobileEntry.Text = mobile;
            AddressEntry.Text = address;
        }

        void updateButton_Clicked(object sender, EventArgs e)
        {
            using(SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                Contact contact = new Contact
                {
                    Id = currentID,
                    FirstName = FirstNameEntry.Text,
                    Surname = SurnameEntry.Text,
                    Email = EmailEntry.Text,
                    MobileNumber = MobileEntry.Text,
                    Address = AddressEntry.Text
                };
                conn.Update(contact);
                Navigation.PopAsync();
            }
            
        }
    }
}
