namespace EntitiLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            WorkOrders = new HashSet<WorkOrder>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_client { get; set; }

        [StringLength(60)]
        public string Email { get; set; }

        [StringLength(13)]
        public string Number { get; set; }

        [StringLength(40)]
        public string FirstName { get; set; }

        [StringLength(60)]
        public string LastName { get; set; }

        [StringLength(60)]
        public string CompanyName { get; set; }

        [StringLength(34)]
        public string IBAN { get; set; }

        public int? ID_type { get; set; }

        [StringLength(60)]
        public string Client_Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }

        public virtual ClientType ClientType { get; set; }
    }
}
