using System;
using System.Collections.Generic;
using System.Text;

namespace AdidasModels.Solution.DTO.Appsetting
{
    public class Appsettings
    {
        public string FromEmailAddress { get; set; }
        public string FromEmailPassword { get; set; }
        public string FromEmailDisplayName { get; set; }
        public string SMTPHost { get; set; }
        public string SMTPPort { get; set; }
        public string EnabledSSL { get; set; }
    }
}
