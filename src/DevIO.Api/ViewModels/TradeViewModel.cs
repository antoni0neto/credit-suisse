﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.ViewModels
{
    public class TradeViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string ClientSector { get; set; }

        public int Value { get; set; }
    }
}