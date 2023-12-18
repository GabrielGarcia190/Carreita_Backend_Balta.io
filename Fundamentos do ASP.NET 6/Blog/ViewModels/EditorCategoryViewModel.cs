using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class EditorCategoryViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Este campo deve no mínimo 3 caracteres e no máximo 40")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O slug é obrigatório")]
        public string? Slug { get; set; }
    }
}