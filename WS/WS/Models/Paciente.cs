using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WS.Models
{
    //Nomeando a Tabela
    [Table("Paciente")]
    public class Paciente
    {
        //Passando as propriedades do construtor
        [PrimaryKey,AutoIncrement,NotNull]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdExame { get; set; }
        public DateTime Data_Exame { get; set; }
        public DateTime Data_Entrega { get; set; }

        //Auxiliando o BD a preencher o Banco
        public Paciente() 
        { 
            this.Id = 0;
            this.Nome = "";
            this.IdExame = 0;
            this.Data_Exame = new DateTime();
            this.Data_Entrega = new DateTime();
        
        }

    }
}
