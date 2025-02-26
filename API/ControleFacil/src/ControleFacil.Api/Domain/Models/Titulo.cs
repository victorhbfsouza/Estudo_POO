using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Models;

namespace ControleFacil.Api.Domain.Models
{
    public abstract class Titulo
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public long IdNaturezaDeLancamento { get; set; }
        public NaturezaDeLancamento NaturezaDeLancamento { get; set; }

        [Required(ErrorMessage = "O campo de descrição é obrigatório")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo valor original é obrigatório")]
        public double ValorOriginal { get; set; }
        public string? Observacao { get; set; } = string.Empty;

        [Required]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "O campo data de vencimento é obrigatório")]
        public DateTime DataVencimento { get; set; }
        public DateTime? DataInativacao { get; set; }
        public DateTime? DataReferencia { get; set; }


    }
}