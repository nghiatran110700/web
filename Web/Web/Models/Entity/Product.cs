namespace Web.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public int? amount { get; set; }

        public decimal? pirce { get; set; }

        public int? idcategory { get; set; }

        [StringLength(50)]
        public string photo { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        public virtual category category { get; set; }
    }
}
