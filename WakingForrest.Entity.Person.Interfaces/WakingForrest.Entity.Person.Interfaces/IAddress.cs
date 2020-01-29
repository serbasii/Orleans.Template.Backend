using System;
using System.Collections.Generic;
using System.Text;

namespace WakingForrest.Entity.Person.Interfaces
{
    public interface IAddress
    {
        string LocationName { get; set; }
        int LocationType { get; set; }
        string StreetAddress { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Zip { get; set; }
    }
}