using System;
using System.Collections.Generic;
using System.Linq;

namespace HunterCV.Common
{
    public class UserData
    {
        public Guid license { get; set; }
        public Guid roleId { get; set; }
        public string areas { get; set; }
        public string companies { get; set; }
        public string roles { get; set; }
        public string candidatesStatuses { get; set; }
        public string positionsStatuses { get; set; }
        public IEnumerable<HunterCV.Common.MailTemplate> templates { get; set; }
        public IEnumerable<HunterCV.Common.Position> positions { get; set; }
        public string settings { get; set; }
        public Dictionary<string, string> users { get; set; }
    }

    public class Candidate
    {
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public Guid CandidateID { get; set; }
        public Nullable<Int32> CandidateNumber { get; set; }
        public string Username { get; set; }
        public Nullable<DateTime> RegistrationDate { get; set; }
        public String IdentityNumber { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }
        public Nullable<Boolean> IsActive { get; set; }
        public String Events { get; set; }
        public String ResumePath { get; set; }
        public Nullable<Int16> Experience { get; set; }
        public String Areas { get; set; }
        public String Roles { get; set; }
        public String Phone { get; set; }
        public String Mobile { get; set; }
        public String EMailAddress { get; set; }
        public String Status { get; set; }
        public String SentToCompanies { get; set; }
        public Nullable<Boolean> Former8200 { get; set; }
        public String MailEntryID { get; set; }
        public String Reference { get; set; }
        public Nullable<DateTime> SigningDate { get; set; }
        public Nullable<DateTime> WorkStartDate { get; set; }
        public IList<CandidatePosition> CandidatePositions { get; set; }
        public bool SkipDuplicatesCheck { get; set; }
        public string Starred { get; set; }
    }
}