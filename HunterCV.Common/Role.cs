using System;
using System.Collections.Generic;
using System.Linq;

namespace HunterCV.Common
{
    public class Role
    {
        public string Xml { get; set; }

        public static Guid FreeLicenseGuid = new Guid("{CBC9A837-4FFB-43A9-9550-8C54B5D39CC4}");
        public static Guid StandardLicenseGuid = new Guid("{FAA5B6C9-2DA2-4712-AF3B-D5ADDDA11508}");
        public static Guid PremiumLicenseGuid = new Guid("{D298EB89-FAB7-4F44-893A-6EF708997B64}");
    }
}