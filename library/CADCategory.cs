using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    internal class CADCategory
    {
        private string _constring;
        public CADCategory()
        {
            _constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        public bool Read(ENCategory en)
        {
            bool leido = false;
            try
            {
                using (SqlConnection c = new SqlConnection(_constring))
                {
                    c.Open();
                    string sql = "SELECT id, name " +
                        "FROM Categories WHERE id = @id";
                    using (SqlCommand com = new SqlCommand(sql, c))
                    {
                        com.Parameters.Add("@id", System.Data.SqlDbType.NVarChar, 16).Value = en.Id;
                        using (SqlDataReader r = com.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                en.Id = Convert.ToInt32(r["id"]);
                                en.Name = r["name"].ToString();
                                leido = true;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                leido = false;
            }

            return leido;
        }

        public List<ENCategory> ReadAll()
        {
            List<ENCategory> categorias = new List<ENCategory>();

            try
            {
                using (SqlConnection c = new SqlConnection(_constring))
                {
                    c.Open();
                    string sql = "SELECT id, name FROM Categories";
                    using (SqlCommand com = new SqlCommand(sql, c))
                    {
                        using (SqlDataReader r = com.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                ENCategory cat = new ENCategory();
                                cat.Id = Convert.ToInt32(r["id"]);
                                cat.Name = r["name"].ToString();
                                categorias.Add(cat);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return categorias;
        }


    }
}
