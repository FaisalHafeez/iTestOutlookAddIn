using System;
using System.Collections.Generic;
using System.Linq;

namespace HunterCV.Common
{
    public class CandidatePosition
    {
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public Guid PositionId { get; set; }
        public Guid CandidateId { get; set; }
        public string CandidatePositionStatus { get; set; }
        public Nullable<DateTime> CandidatePositionDate { get; set; }
    }
}