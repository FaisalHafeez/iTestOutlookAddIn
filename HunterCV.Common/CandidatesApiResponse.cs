using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterCV.Common
{
    public class CandidatesApiResponse
    {
        public int TotalRows { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<Candidate> Candidates { get; set; }
    }
}
