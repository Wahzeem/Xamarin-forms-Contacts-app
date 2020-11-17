using System;
using SQLite;
using Xamarin.Forms;
using Xamarin.Essentials;
using Contacts.Classes;
using Contact = Contacts.Classes.Contact;

[assembly: ExportFont("BarlowCondensed-Light.ttf", Alias = "BarlowLight")]
[assembly: ExportFont("BarlowCondensed-Thin.ttf", Alias = "BarlowThin")]
[assembly: ExportFont("BarlowCondensed-Regular.ttf", Alias = "BarlowReg")]
namespace Contacts
{
    public partial class ContactView : ContentPage
    {

        int currentId;
        string currentFName;
        string currentSName;
        string currentEmail;
        string currentMobile;
        string currentAddress;

        public ContactView(int Id, string firstName, string surname, string email, string mobile, string address)
        {
            currentId = Id;
            currentFName = firstName;
            currentSName = surname;
            currentEmail = email;
            currentMobile = mobile;
            currentAddress = address;

            InitializeComponent();
            MyFirstName.Text = currentFName + " " + surname;
            MyNumber.Text = mobile;
            MyEmail.Text = email;
            MyAddress.Text = address;
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
        //    {
        //        var selectedTable = conn.Table<Contact>().Select(x => x.Id = currentId);
        //    }
        //}

        private async void OnEdit(object sender, EventArgs e) //TODO
        {
            await Navigation.PushAsync(new EditContact(currentId, currentFName, currentSName, currentEmail, currentMobile, currentAddress));
        }


        private async void OnDelete(object sender, System.EventArgs e)
        {
            var response = await DisplayAlert("Delete Contact", $"Are you sure you'd like to permanently remove {currentFName}?", "Yes", "No");

            if (response)
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
                {
                    conn.Table<Classes.Contact>().Delete(x => x.Id == currentId);
                }
                await Navigation.PopAsync();
            }

            
        }

        async void PickImage_Clicked(object sender, EventArgs e)
        {
            var pickResult = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Pick an image"
            });

            if(pickResult != null)
            {
                var stream = await pickResult.OpenReadAsync();
                ResultImage.Source = ImageSource.FromStream(() => stream);
            }
            else
            {
                ResultImage.Source = ImageSource.FromFile("/Images/Contact-Icon.png}");
            }



            //using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            //{
            //    Contact contact = new Contact
            //    {
            //        Img = 
            //    };
            //};
        }
    }
}
