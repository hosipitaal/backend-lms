using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int emp_id {  get; set; }

        public string emp_name { get; set; }

        public string emp_phone { get; set; }
        public string mgr_name { get; set; }

        public string emp_email { get; set; }

        public int mgr_id { get; set;} 

    }
}
