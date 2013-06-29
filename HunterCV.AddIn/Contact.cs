using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterCV.AddIn
{
    public class Contact
    {
        public Guid ID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string Remarks { get; set; }
    }
}
