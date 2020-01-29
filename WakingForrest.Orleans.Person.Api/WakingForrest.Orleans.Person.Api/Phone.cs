using System;
using System.Collections.Generic;
using System.Text;
using WakingForrest.Entity.Person.Interfaces;

namespace WakingForrest.Orleans.Person.Grains
{
    public class Phone : IPhone
    {
        public int LocationType { get; set; }
        public string Number { get; set; }
    }
}