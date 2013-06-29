using System;
using System.Collections.Generic;
using System.Linq;

namespace HunterCV.Common
{
    public class MailTemplate
    {
        public Guid RoleId { get; set; }
        public short TemplateIndex { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string RtfBody { get; set; }
        public bool IncludeAttachments { get; set; }
        public bool SetOpeningCompanyRecipient { get; set; }
    }
}