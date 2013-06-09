using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterCV.Common
{
    public class PostCandidateApiResponse
    {
        public Candidate NewCandidate { get; set; }
        public IEnumerable<Candidate> Duplicates { get; set; }
    }
}
