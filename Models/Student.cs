using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day2.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }

        public virtual List<Std_Crs> Crs { get; set; }

        [ForeignKey("department")]
        public int? dept_id { set; get; }
        public Department department { set; get; }

        [InverseProperty("leader")]
       public virtual List<Student> group { set; get; }

        [ForeignKey("leader")]
       public int? leader_id { get; set; }
       public Student leader { set; get; }
    }
}
