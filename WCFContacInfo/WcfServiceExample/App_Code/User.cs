using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServiceExample
{
    public class User
    {

        private int userId;
        private string firstName;
        private string lastName;
        private string city;
        private string state;
        private string country;

        public int UserId
        {
            get { return userId; }
            set
            {
                userId = value;

            }
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;

            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;

            }
        }
        public string City
        {
            get { return city; }
            set
            {
                city = value;

            }
        }
        public string State
        {
            get { return state; }
            set
            {
                state = value;

            }
        }
        public string Country
        {
            get { return country; }
            set
            {
                country = value;

            }
        }
    }  
}