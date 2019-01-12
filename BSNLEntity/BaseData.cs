namespace BSNLEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaseData")]
    public partial class BaseData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerID { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerType { get; set; }

        [Column(TypeName = "date")]
        public DateTime ConnectionActivationDate { get; set; }

        [Required]
        [StringLength(50)]
        public string ConnectionLength { get; set; }

        [Required]
        [StringLength(50)]
        public string LoyaltyScore { get; set; }

        [Required]
        [StringLength(50)]
        public string AvgRevenueScore { get; set; }

        public float AvgMonthlyBilling { get; set; }

        [StringLength(50)]
        public string CustomerCategory { get; set; }

        [Required]
        [StringLength(50)]
        public string ConnectionType { get; set; }

        [StringLength(50)]
        public string FixedLine { get; set; }

        [StringLength(50)]
        public string BB { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        public float SecurityDepositAmt { get; set; }

        public float CreditLimit { get; set; }

        public int DefaultsOrYear { get; set; }

        [Column(TypeName = "date")]
        public DateTime LastPaymentDate { get; set; }

        public string Status { get; set; }

        [Required]
        public string ContactEmail { get; set; }

        public bool isActive { get; set; }

        public virtual Dispute Dispute { get; set; }

        public virtual RevenueData RevenueData { get; set; }
    }
}
