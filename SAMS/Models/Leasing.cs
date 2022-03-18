namespace SAMS.Models
{
    public class Leasing
    {
        [Key]
        public int Leasing_No { get; set; }
        public int Student_No { get; set; }
        public int Place_No { get; set; }
        public DateTime Date_From { get; set; }
        public DateTime Date_To { get; set; }
    }
}
