using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.ViewModels
{
    public class TradeViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public int Value { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Sector Sector { get; set; }
        public Category Category { get; set; }
    }
}