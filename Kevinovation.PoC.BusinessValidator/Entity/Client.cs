using System;
using System.Collections.Generic;

namespace Kevinovation.PoC.BusinessValidator.Entity
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Contact> Contacts { get; set; }

        public Client()
        {
            this.Name = String.Empty;
            this.Contacts = new List<Contact>();
        }
    }
}