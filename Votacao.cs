using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace MVC_Urna.Models
{
    public class Votacao
    {
        [Key]
        public int Id { get; set; }
        public int Id_Candidato { get; set; }
        [Display(Name = "Data Da Votação" )]
        public DateTime Data_Cadastro { get; set; }
        [Display(Name = "N°")]
        public int CandidatosId { get; set; }
        public Candidatos Candidatos { get; set; }
       
    }
}
