using System.ComponentModel.DataAnnotations.Schema;

namespace Day2.Models
{
    public class Instructor
    {
       public int ID { set; get; }
       public string Name { set; get; }
       public string? Address { set; get; }
       public int Age { set; get; }
        [Column(TypeName ="money")]
       public decimal Salary { set; get; }

        //navigation property
        #region dept
        [ForeignKey("workDepartment")]
        public int? Dept_id { set; get; }

        public virtual Department workDepartment { get; set; }

        public virtual Department manageDepartment { set; get; }
        #endregion

        #region course
        public virtual List<Ins_Course>Courses { set; get; }
        #endregion
    }
}
