using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Classes;
using Xamarin.Forms;
using SQLite;
using System.IO;

namespace Contacts
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent(); 
        }

        void saveButton_Clicked(object sender, EventArgs e) //Save button clicked event 
        {
            Contact contact = new Contact()
            {
                FirstName = FirstNameEntry.Text,
                Surname = SurnameEntry.Text,
                Email = EmailEntry.Text,
                MobileNumber = MobileEntry.Text,
                Address = AddressEntry.Text
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                //conn.CreateTable<Contact>();
                //int rowsAdded = conn.Insert(contact);

                if (FirstNameEntry.Text.Length <= 0)
                {
                    DisplayAlert("Invalid", "Please Enter a name", "Ok");
                }
                else
                {
                    conn.CreateTable<Contact>();
                    int rowsAdded = conn.Insert(contact);
                }
            }

            Navigation.PopAsync(); //As soon as save button is hit, navigate back to Contact page.
        }

    }
}
