using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Models
{
    public class LoginDetails
    {
        public int emp_id {  get; set; }

        [Key]
        public string emp_name {  get; set; }

        public string  password { get; set; }
    }
}
