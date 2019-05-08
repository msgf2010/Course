using System;
using System.Collections.Generic;
using System.Text;

namespace Class61Homework.Data
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public bool? Confirmed { get; set; }
    }
}
