using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestmentPortfolioManager.Domain.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required]
        [StringLength(10)]
        public required string Code { get; set; } // TODO: add unique constraint

        [Required]
        [StringLength(100)]
        public required string Description { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int AvailableQuantity { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        public DateTime? UpdatedAt { get; set; } // TODO: auto generate on update

        [Required]
        public DateTime CreatedAt { get; set; } // TODO: auto generate on creation
    }
}
