namespace BSNLEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dispute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerID { get; set; }

        [Column(TypeName = "date")]
        public DateTime RequestDate { get; set; }

        [StringLength(50)]
        public string RequestType { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public bool isActive { get; set; }

        public virtual BaseData BaseData { get; set; }
    }
}
