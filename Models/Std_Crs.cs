using System.ComponentModel.DataAnnotations.Schema;

namespace Day2.Models
{
    public class Std_Crs
    {
        [ForeignKey("student")]
        public int st_id { set; get; }
        [ForeignKey("course")]
        public int crs_id { set; get; }

        public Student student { set; get; }
        public Course  course { set; get; }
    }
}
