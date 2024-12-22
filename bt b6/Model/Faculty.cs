namespace bt_b6.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Faculty")]
    public partial class Faculty
    {
        [StringLength(50)]
        public string facultyid { get; set; }

        [StringLength(50)]
        public string facultyname { get; set; }
    }
}
