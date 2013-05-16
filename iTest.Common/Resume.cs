using System;
using System.Collections.Generic;
using System.Linq;

namespace iTest.Common
{
    public class Resume
    {
        public int ResumeID { get; set; }
        public Guid CandidateID { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
    }
}