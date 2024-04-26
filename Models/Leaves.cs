using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Models
{
    public class Leaves
    {
        [Key]
        public int leave_id { get; set; }

        public int mgr_id { get; set; }

        public int emp_id { get; set; }

        public DateTime start_date { get; set; }

        public DateTime end_date { get; set;}

        public int daysofleave
        {
            get => (int)(end_date - start_date).Days + 1;
            set => value = (int)(end_date - start_date).Days + 1;
        }

        public string reason { get; set; } = "";
    }
}
