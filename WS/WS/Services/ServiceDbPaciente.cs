using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using WS.Models;

namespace WS.Services
{
    public class ServiceDbPaciente
    {
        SQLiteConnection conn;

        public ServiceDbPaciente(string dbPath) 
        {
            if (dbPath == "")
                dbPath = App.DbPath;
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Paciente>();
        }

        public List<Paciente> ListarPaciente()
        {
            Paciente paciente = new Paciente();
            paciente.IdExame.ToString();
            List<Paciente> pacientes = new List<Paciente>();
            try
            {
                
                pacientes = conn.Table<Paciente>().ToList();
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
            return pacientes;
        }

        public void CadastrarPaciente(Paciente paciente)
        {
            
            try
            {
                conn.Insert(paciente);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}
