namespace SAMS.Models
{
    public class StudentLeasingsViewModel
    {
        public int Student_No { get; set; }
        public string SName { get; set; }
        public int Leasing_No { get; set; }
        public int Place_No { get; set; }
        public int Rent_Per_Semester { get; set; }
        public int? Dormitory_No { get; set; }
        public int? Appart_No { get; set; }
    }
}
