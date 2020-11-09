using System;
using System.Collections.Generic;
using Contacts.Classes;
using SQLite;
using Xamarin.Forms;
using System.Linq;
using MvvmHelpers;
using System.Collections.ObjectModel;

namespace Contacts
{
    public partial class ContactsPage : ContentPage
    {

        int currentID;
        


        public ContactsPage()
        {
            InitializeComponent();
        }



        void NewContactToolbarItem_Clicked(object sender, EventArgs e) //Functionality for +new button
        {
            Navigation.PushAsync(new MainPage()); //Navigate to the create page
        }



        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Contact>();
                var contacts =conn.Table<Contact>().ToList();


              

                

                contactsListView.ItemsSource = contacts.OrderBy(x => x.FirstName); //Make list Alphabetical
            }
        }



        private async void contactsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            
            var contact = e.Item as Contact;

            currentID = contact.Id;

            await Navigation.PushAsync(new ContactView(contact.Id ,contact.FirstName, contact.Surname, contact.Email, contact.MobileNumber, contact.Address));
        }


        

       

        void OnDelete(object sender, EventArgs e)
        {
            //var mi = ((MenuItem)sender);
            //await DisplayAlert("Delete", mi.CommandParameter + " Are you sure?", "Yes","No");

            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
               
                conn.Table<Contact>().Delete(x => x.Id == currentID); //Not working yet
                
            }
        }
    }
}






 