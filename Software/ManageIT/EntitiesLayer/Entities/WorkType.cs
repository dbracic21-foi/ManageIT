namespace EntitiesLayer.Entities {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("WorkType")]
    public partial class WorkType {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Work_Type { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
