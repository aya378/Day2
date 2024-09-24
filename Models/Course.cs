using System.ComponentModel.DataAnnotations;

namespace Day2.Models
{
    public class Course
    {
        [Key]
        public int id { set; get; }
        public string name { set; get; }
        public int duration { set; get; }

        public virtual List<Ins_Course> courses { set; get; }

        public virtual List<Std_Crs> Crs { get; set; }
    }
}
