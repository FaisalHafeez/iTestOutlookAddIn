using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterCV.AddIn
{
    public class DuplicateCandidatesException : Exception
    {
        public IEnumerable<HunterCV.Common.Candidate> Duplicates { get; set; }
    }
}
