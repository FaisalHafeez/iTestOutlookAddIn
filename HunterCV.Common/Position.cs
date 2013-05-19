using System;
using System.Collections.Generic;
using System.Linq;

namespace HunterCV.Common
{
    public class Position
    {
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public Guid PositionID { get; set; }
        public Nullable<Int32> PositionNumber { get; set; }
        public string Username { get; set; }
        public Nullable<DateTime> PublishedAt { get; set; }
        public String PositionTitle { get; set; }
        public String PositionDescription { get; set; }
        public String PositionAreas { get; set; }
        public String PositionRole { get; set; }
        public String Company { get; set; }
        public String Status { get; set; }
        public String Events { get; set; }

        public bool IsNew { get; set; }
    }
}