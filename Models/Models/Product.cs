    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    namespace Models.Models;

    public class Product {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public bool Perishable { get; set; } = false;

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
