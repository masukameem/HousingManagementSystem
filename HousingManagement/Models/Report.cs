using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HousingManagement.Models
{
    public class Report
    {
        [Key]
        public Int64 Id { get; set; }
        public Int64 AddedBy { get; set; }
        public string AddedName { get; set; }
        public Int64 AgainstId { get; set; }
        public string ReportReason { get; set; }
        public string Comment { get; set; }
    }


    public class ReportList
    {
        public List<Report> ReportsAll { get; set; } 
    }
}

