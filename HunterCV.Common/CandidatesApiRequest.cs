using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterCV.Common
{
    public class CandidatesApiRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortField { get; set; }
        public int SortType { get; set; }
        public string FilterFullName { get; set; }
        public string FilterRole { get; set; }
        public string FilterAreas { get; set; }
        public Nullable<bool> FilterFavorites { get; set; }
        public Nullable<int> FilterCandidateNumber { get; set; }
        public string FilterStatus { get; set; }
        public Nullable<DateTime> FilterRegistrationStartDate { get; set; }
        public Nullable<DateTime> FilterRegistrationEndDate { get; set; }
    }
}
