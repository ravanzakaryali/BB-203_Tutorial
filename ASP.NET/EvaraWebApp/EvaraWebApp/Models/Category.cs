using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvaraWebApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bos ola bilmez!!!!"), MaxLength(20, ErrorMessage = "Məmməd inspectnen oynanma!")]
        public string Name { get; set; } = null!;
        public ICollection<Product>? Products { get; set; }
    }
}
