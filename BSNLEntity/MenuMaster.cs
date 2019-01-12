namespace BSNLEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MenuMaster")]
    public partial class MenuMaster
    {
        [Key]
        public int MenuID { get; set; }

        [Required]
        [StringLength(50)]
        public string MenuName { get; set; }

        [Required]
        public string MenuURL { get; set; }

        public bool isActive { get; set; }
    }
}
