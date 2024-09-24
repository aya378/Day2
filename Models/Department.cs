using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day2.Models
{
    public class Department
    {
        [Key]
        public int ID { set; get; }
        public string Name { set; get; }
        public string Loc { set; get; }

        #region instructor
        [ForeignKey("manager")]
        public int ins_id { get; set; }

        [InverseProperty("workDepartment")]
        public virtual List<Instructor>Instructors { set; get; }

        [InverseProperty("manageDepartment")]
        public virtual Instructor manager { set; get; }
        #endregion

        public virtual List<Student>  students { set; get; }
    }
}
