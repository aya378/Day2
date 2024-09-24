using System.ComponentModel.DataAnnotations.Schema;

namespace Day2.Models
{
    public class Ins_Course
    {
        [ForeignKey("instructor")]
        public int ins_id { get; set; }
        [ForeignKey("course")]
        public int crs_id { get; set; }

        public Instructor instructor { get; set; }
        public Course course {  get; set; }
    }
}
