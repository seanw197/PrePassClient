using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrePassClient.Models
{
    public class ReportItem
    {
        [Key]
        public int ID { get; set; }
        public string Item { get; set; }
        public int Count { get; set; }
    }

    public class Report
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Report Title")]
        public string ReportTitle = "PrePass Summary Report";

        [Display(Name = "Start Date")]
        public string StartDate { get; set; }

        [Display(Name = "End Date")]
        public string EndDate { get; set; }

        [Display(Name = "Number of Assessments")]
        public int AssessmentCount { get; set; }

        [Display(Name = "First Time Applicants")]
        public int FirstTimeApp { get; set; }

        [Display(Name = "Repeat Applicants")]
        public int RepeatApp { get; set; }

        [Display(Name = "Gender Distribution")]
        public List<ReportItem> Genders { get; set; } = new List<ReportItem>();

        [Display(Name = "Ethnic Distribution")]
        public List<ReportItem> Ethnicities { get; set; } = new List<ReportItem>();

        [Display(Name = "Reason for Homelessness")]
        public List<ReportItem> Reasons { get; set; } = new List<ReportItem>();

        [Display(Name = "Household Type")]
        public List<ReportItem> Households { get; set; } = new List<ReportItem>();

        [Display(Name = "District")]
        public List<ReportItem> Districts { get; set; } = new List<ReportItem>();

        [Display(Name = "Children")]
        public List<ReportItem> Children { get; set; } = new List<ReportItem>();

        [Display(Name = "Income Status")]
        public List<ReportItem> Incomes { get; set; } = new List<ReportItem>();

        [Display(Name = "Addiction Status")]
        public List<ReportItem> Addictions { get; set; } = new List<ReportItem>();

        [Display(Name = "Assessment Status")]
        public List<ReportItem> Statuses { get; set; } = new List<ReportItem>();

        public override string ToString()
        {
            return String.Format("{0} \nStart Date: {1} End Date: {2} \nNumber of Assessments: {3} \nFirst Time Applicants: {4} \nRepeat Applicants: {5}", ReportTitle, StartDate, EndDate, AssessmentCount, FirstTimeApp, RepeatApp);
        }
    }
}
