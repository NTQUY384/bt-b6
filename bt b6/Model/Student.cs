namespace bt_b6.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [StringLength(50)]
        public string id { get; set; }

        [StringLength(50)]
        public string fullname { get; set; }

        public double? avg { get; set; }

        [StringLength(50)]
        public string facultyid { get; set; }
    }
}
