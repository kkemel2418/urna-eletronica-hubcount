using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace MVC_Urna.Models
{
    public class Candidatos
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Data é obrigatório")]
        [Display(Name = "Data De Cadastro")]
        public DateTime Data_Cadastro { get; set; }

        [Required(ErrorMessage = "O campo Legenda é obrigatório")]
        [Display(Name = "Legenda do partido")]
        public int Legenda { get; set; }

     ///   public List<Votacao> Votacao { get; set; }

    }
}
