namespace BSNLEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RevenueData")]
    public partial class RevenueData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerID { get; set; }

        [Column(TypeName = "date")]
        public DateTime BillDate { get; set; }

        public float BillAmount { get; set; }

        public float LatePaymentPenalty { get; set; }

        public int NoOfReminders { get; set; }

        public bool isActive { get; set; }

        public virtual BaseData BaseData { get; set; }
    }
}
