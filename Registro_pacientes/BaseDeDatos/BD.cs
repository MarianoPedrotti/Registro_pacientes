using Microsoft.EntityFrameworkCore;
using Registro_pacientes.Models;
using System.Data.SqlClient;

namespace Registro_pacientes.BaseDeDatos
{
    public class BD:DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ACADEMICA-30;Initial Catalog=Hospital;Persist Security Info=True;User ID=sa;Password=utn;Encrypt=True;TrustServerCertificate=True");
        }
        DbSet<ObraSocial> ObrasSociales { get; set; }
        DbSet<Paciente> Pacientes { get; set;}
        private string conexion = "Data Source=ACADEMICA-30;Initial Catalog=Hospital;Persist Security Info=True;User ID=sa;Password=utn;Encrypt=True;TrustServerCertificate=True"
;
        public List<Paciente> listarPacientes(int id = 0)
        {
            List<Paciente> lista = new List<Paciente>();
            using (SqlConnection con = new SqlConnection(conexion))
            {
                string query = @"SELECT p.Id, p.Nombre, p.Edad, p.Sintomas, p.ObraSocialId, o.Nombre AS ObraSocialNombre
                                FROM Pacientes p
                                JOIN ObrasSociales o ON p.ObraSocialId = o.Id";
                if (id > 0)               
                    query += "WHERE p.Id = " + id;
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Paciente
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Edad = Convert.ToInt32(reader["Edad"]),
                        Sintomas = reader["Sintomas"].ToString(),
                        ObraSocialId = Convert.ToInt32(reader["ObraSocialId"]),
                        obraSocial = new ObraSocial {Nombre = reader["ObraSocialNombre"].ToString() }
                        
                    });
                }
            }
            return lista;
        }
        public  string crearPaciente(Paciente pacienteNuevo)
        {
            try
            {
                using(SqlConnection con = new SqlConnection(conexion))
                {
                    string query = $"INSERT INTO Pacientes (Nombre, Edad, Sintomas, ObraSocialId) VALUES ('{pacienteNuevo.Nombre}', {pacienteNuevo.Edad},'{pacienteNuevo.Sintomas}'), {pacienteNuevo.ObraSocialId})";
                    con.Open();
                    SqlCommand cmd = new SqlCommand (query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    return "";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        
    }
    
    
}
