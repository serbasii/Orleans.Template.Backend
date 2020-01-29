using System;
using System.Collections.Generic;

namespace WakingForrest.Entity.Person.Interfaces
{
    public interface IPerson
    {
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string Nickname { get; set; }
        List<IPhone> PhoneNumbers { get; set; }
        List<IAddress> Addresses { get; set; }
        List<string> EmailAddresses { get; set; }
    }
}