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
            return String.Format("ID: {0} | Report Title: {1} | Start Date: {2} | End Date: {3} | Number of Assessments: {4} | First Time Applicants: {5}| Repeat Applicants: {6} | Gender Distribution: {7}| Ethnic Distribution: {8} | Reason for Homelesness: {9}| Household Type: {10}| District: {11}| Children: {12}| Income Status: {13}| Income Status: {15}| Addiction Status: {16}| Assessment Status: {17}", ID, ReportTitle, StartDate, EndDate, AssessmentCount, FirstTimeApp, RepeatApp, Genders, Ethnicities, Reasons, Households, Districts, Children, Incomes, Addictions, Statuses);
        }
    }
}
