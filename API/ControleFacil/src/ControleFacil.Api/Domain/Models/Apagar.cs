using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Domain.Models;

namespace ControleFacil.Api.Models
{
    public class Apagar : Titulo
    {
        [Required(ErrorMessage = "O campo valor pago é obrigatório")]
        public double ValorPago { get; set; }
        public DateTime? DataPagamento { get; set; }
    }
}