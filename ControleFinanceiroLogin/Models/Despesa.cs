﻿using System.ComponentModel.DataAnnotations;


namespace ControleFinanceiroLogin.Models
{
    public class Despesa
    {
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public DateTime Data { get; set; }
        public int UsuarioId { get; set; }//chave estrangeira

    }
}
