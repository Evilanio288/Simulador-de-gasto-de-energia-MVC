using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISolar.Models
{
    [Table("Localidade")]
    public class LocalidadeModel
    {
        [Key]

        public int Id { get; set; }

        public string Local { get; set; }

        public string CepInicial { get; set; }

        public string CepFinal { get; set; }

        public decimal Irradiacao { get; set; }
    }
}
