using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kist_api.Models.Account
{
    public class ApplicationsModel
    {
        public long ID { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationCode { get; set; }
        public bool IsActive { get; set; }
    }
}