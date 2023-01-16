using Microsoft.Data.SqlClient;

namespace CRUD.Models
{
    public class Crud
    {
        Conexion con = new Conexion();

        public List<Persona> SlPersonas()
        {
            List<Persona> nombres = new List<Persona>();

            try
            {
                SqlCommand query = new SqlCommand();
                query.Connection = con.Connect();
                query.CommandText = "SELECT *FROM Personas";
                SqlDataReader consultar = query.ExecuteReader();
                while (consultar.Read())
                {
                    nombres.Add(new Persona()
                    {
                        Cedula = consultar["Cedula"].ToString(),
                        Nombres = consultar["Nombres"].ToString(),
                        Apellidos = consultar["Apellidos"].ToString(),
                        Direccion = consultar["Direccion"].ToString()
                    });
                }
                con.Connect().Close();
                return nombres;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Persona SlPersona(string cedula)
        {
            var persona = new Persona();

            try
            {
                SqlCommand query = new SqlCommand();
                query.Connection = con.Connect();
                query.CommandText = "SELECT *FROM Personas where Cedula = '" + cedula + "'";
                SqlDataReader consultar = query.ExecuteReader();
                while (consultar.Read())
                {
                    persona.Cedula = consultar["Cedula"].ToString();
                    persona.Nombres = consultar["Nombres"].ToString();
                    persona.Apellidos = consultar["Apellidos"].ToString();
                    persona.Direccion = consultar["Direccion"].ToString();

                }
                con.Connect().Close();
                return persona;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool GuardarPer(Persona persona)
        {
            bool result;

            try
            {
                SqlCommand query = new SqlCommand();
                query.Connection = con.Connect();
                query.CommandText = "Insert into Personas VALUES (@Cedula,@Nombres,@Apellidos,@Direccion);";
                query.Parameters.AddWithValue("@Cedula", persona.Cedula);
                query.Parameters.AddWithValue("@Nombres", persona.Nombres);
                query.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                query.Parameters.AddWithValue("@Direccion", persona.Direccion);
                query.ExecuteNonQuery();
                result = true;
                con.Connect().Close();

            }
            catch (Exception ex)
            {
                result = false;
                throw;
            }
            return result;
        }

        public bool EditarPer(Persona persona)
        {
            bool result;

            try
            {
                SqlCommand query = new SqlCommand();
                query.Connection = con.Connect();
                query.CommandText = "UPDATE Personas set Nombres = @Nombres,Apellidos= @Apellidos,Direccion= @Direccion where Cedula = @Cedula";
                query.Parameters.AddWithValue("@Cedula", persona.Cedula);
                query.Parameters.AddWithValue("@Nombres", persona.Nombres);
                query.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                query.Parameters.AddWithValue("@Direccion", persona.Direccion);
                query.ExecuteNonQuery();
                result = true;
                con.Connect().Close();

            }
            catch (Exception ex)
            {
                result = false;
                throw;
            }
            return result;
        }

        public bool EliminarPer(string cedula)
        {
            bool rta;
            var persona = new Persona();

            try
            {
                SqlCommand query = new SqlCommand();
                query.Connection = con.Connect();
                query.CommandText = "DELETE FROM Personas where Cedula = '" + cedula + "'";
                SqlDataReader consultar = query.ExecuteReader();
                con.Connect().Close();
                return rta = true;
            }
            catch (Exception ex)
            {
                return rta = false;
                throw;
            }
        }
    }
}
