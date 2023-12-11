using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        [Column("Nome", TypeName = "TIPO_DE_DADOS")]
        public required string Name { get; set; }

        [Required]
        [MaxLength(80)]
        [Column("Slug", TypeName = "TIPO_DE_DADOS")]
        public required string Slug { get; set; }
    }
}