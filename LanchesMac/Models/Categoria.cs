using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage ="O nome da categoria deve ser informado")]
        [StringLength(100, ErrorMessage="O tamanho máximo é 100 caracteres")]
        [Display(Name="Nome")]
        public string CategoriaNome { get; set; }

        [Required(ErrorMessage = "Informe a descrição")]
        [StringLength(200, ErrorMessage = "O tamanho máximo é 100 caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public List<Lanche> Lanches { get; set;}
    }
}
