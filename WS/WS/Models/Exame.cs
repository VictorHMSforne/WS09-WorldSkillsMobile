using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WS.Models
{
    //Nomeando a Tabela
    [Table("Exame")]
    public class Exame
    {
        //Passando as propriedades do construtor
        [PrimaryKey,NotNull,AutoIncrement] 
        public int Id { get; set; }
        public string Nome_Exame { get; set; }
        public int Dias { get; set; }

        //Auxiliando o BD a preencher o Banco
        public Exame() 
        { 
            this.Id = 0;
            this.Nome_Exame = "";
            this.Dias = 0;
        }
    }
}
