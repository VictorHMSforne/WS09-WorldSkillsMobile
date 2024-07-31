using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using WS.Models;

namespace WS.Services
{
    public class ServiceDbExame
    {
        SQLiteConnection conn;
        public ServiceDbExame(string dbPath)
        {
            if (dbPath == "")
                dbPath = App.DbPath;
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Exame>();
        }
        public List<Exame> ListarExame()
        {
            List<Exame> exames = new List<Exame>();
            try
            {
                exames = conn.Table<Exame>().ToList();
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
            return exames;
        }

        public void CadastrarExame(Exame exame)
        {

            try
            {  
                conn.Insert(exame);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}
