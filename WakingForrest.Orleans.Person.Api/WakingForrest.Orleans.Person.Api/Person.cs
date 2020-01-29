using System;
using System.Collections.Generic;
using WakingForrest.Entity.Person.Interfaces;

namespace WakingForrest.Orleans.Person.Api
{
    public class Person : IPerson
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public List<IPhone> PhoneNumbers { get; set; }
        public List<IAddress> Addresses { get; set; }
        public List<string> EmailAddresses { get; set; }
    }
}