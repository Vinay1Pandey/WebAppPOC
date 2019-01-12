namespace BSNLEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EmailTemplate
    {
        [Key]
        public int TemplateID { get; set; }

        [Required]
        public string Name { get; set; }

        public string ccEmailAddress { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }

        public bool isActive { get; set; }
        public string To { get; set; }
        public string CC { get; set; }
        public string ToUserName { get; set; }
        public string LastPayDate { get; set; }
        public string AmtBill { get; set; }
        public string reminder { get; set; }
        public string Gadgets { get; set; }

    }
}
