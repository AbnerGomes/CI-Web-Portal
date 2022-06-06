using System;

namespace CofreInteligente.Models
{
    public class Deposito
    {
        public int IdLote { get; set; }

        public int IdUsuario { get; set; }

        public int IdDeposito { get; set; }   

        public DateTime DataDeposito { get; set; }  
    }
}