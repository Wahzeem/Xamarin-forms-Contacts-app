using System;
using SQLite;

namespace Contacts.Classes
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        [MaxLength(10)]
        public string MobileNumber { get; set; }

        public string Address { get; set; }

        public byte[] Img { get; set; }

    }
}
