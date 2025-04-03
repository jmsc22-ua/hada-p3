using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace library
{
    internal class CADProduct
    {
        private string _constring;

        public CADProduct()
        {
            _constring = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        public bool Create(ENProduct en)
        {
            bool hecho = false;
            SqlConnection conn = null;
            SqlCommand com = null;

            try
            {
                conn = new SqlConnection(_constring);
                conn.Open();

                string sql = "INSERT INTO Products (name, code, amount, price, category, creationDate)" +
                             " VALUES (@name, @code, @amount, @price, @category, @creationDate)";

                com = new SqlCommand(sql, conn);
                com.Parameters.AddWithValue("@name", en.Name);
                com.Parameters.AddWithValue("@code", en.Code);
                com.Parameters.AddWithValue("@amount", en.Amount);
                com.Parameters.AddWithValue("@price", en.Price);
                com.Parameters.AddWithValue("@category", en.Category+1);
                com.Parameters.AddWithValue("@creationDate", en.CreationDate);

                com.ExecuteNonQuery();
                hecho = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error creando producto: " + ex.Message);
            }
            finally
            {
                if (com != null) com.Dispose();
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }

            return hecho;
        }

        public bool Update(ENProduct en)
        {
            bool hecho = false;
            try
            {
                using (SqlConnection c = new SqlConnection(_constring))
                {
                    c.Open();
                    string sql = @"UPDATE Products 
                           SET name = @name, 
                               amount = @amount, 
                               price = @price, 
                               category = @category, 
                               creationDate = @creationDate
                           WHERE code = @code"; 

                    using (SqlCommand com = new SqlCommand(sql, c))
                    {
                        com.Parameters.AddWithValue("@name", en.Name);
                        com.Parameters.AddWithValue("@code", en.Code);
                        com.Parameters.AddWithValue("@amount", en.Amount);
                        com.Parameters.AddWithValue("@price", en.Price);
                        com.Parameters.AddWithValue("@category", en.Category);
                        com.Parameters.AddWithValue("@creationDate", en.CreationDate);

                        int rowsAffected = com.ExecuteNonQuery();
                        hecho = rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product update has failed. Error: {0}", ex.Message);
                hecho = false;
            }

            return hecho;
        }

        public bool Delete(ENProduct en)
        {
            bool borrado = false;
            try
            {
                using(SqlConnection c = new SqlConnection(_constring))
                {
                    c.Open();
                    string sql = "DELETE FROM Products WHERE code = @code";
                    using(SqlCommand com = new SqlCommand(sql, c))
                    {
                        com.Parameters.Add("@code", System.Data.SqlDbType.NVarChar, 16).Value = en.Code;
                        com.ExecuteNonQuery();
                    }
                    borrado = true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                borrado = false;
            }

            return borrado;
        }
        public bool Read(ENProduct en)
        {
            bool leido = false;
            try
            {
                using(SqlConnection c = new SqlConnection(_constring))
                {
                    c.Open();
                    string sql = "SELECT name, code, amount, price, category, creationDate " +
                        "FROM Products WHERE code = @code";
                    using (SqlCommand com = new SqlCommand(sql, c))
                    {
                        com.Parameters.Add("@code", System.Data.SqlDbType.NVarChar, 16).Value = en.Code;
                        using(SqlDataReader r = com.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                en.Name = r["name"].ToString();
                                en.Amount = Convert.ToInt32(r["amount"]);
                                en.Price = (float)Convert.ToDecimal(r["price"]);
                                en.Category = Convert.ToInt32(r["category"]);
                                en.CreationDate = Convert.ToDateTime(r["creationDate"]);
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
        public bool ReadFirst(ENProduct en)
        {
            bool leido = false;
            try
            {
                using (SqlConnection c = new SqlConnection(_constring))
                {
                    c.Open();
                    string sql = "SELECT TOP 1 name, code, amount, price, category, creationDate " +
                        "FROM Products ORDER BY code ASC";
                    using (SqlCommand com = new SqlCommand(sql, c))
                    {
                        using (SqlDataReader r = com.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                en.Code = r["code"].ToString();
                                en.Name = r["name"].ToString();
                                en.Amount = Convert.ToInt32(r["amount"]);
                                en.Price = (float)Convert.ToDecimal(r["price"]);
                                en.Category = Convert.ToInt32(r["category"]);
                                en.CreationDate = Convert.ToDateTime(r["creationDate"]);
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
        public bool ReadNext(ENProduct en)
        {
            bool leido = false;
            try
            {
                using (SqlConnection c = new SqlConnection(_constring))
                {
                    c.Open();
                    string sql = "SELECT TOP 1 id, name, code, amount, price, category, creationDate" +
                        "FROM Products WHERE code > @code ORDER BY code ASC";
                    using (SqlCommand com = new SqlCommand(sql, c))
                    {
                        com.Parameters.Add("@code", System.Data.SqlDbType.NVarChar, 16).Value = en.Code;
                        using (SqlDataReader r = com.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                en.Name = r["name"].ToString();
                                en.Amount = Convert.ToInt32(r["amount"]);
                                en.Price = (float)Convert.ToDecimal(r["price"]);
                                en.Category = Convert.ToInt32(r["category"]);
                                en.CreationDate = Convert.ToDateTime(r["creationDate"]);
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
        public bool ReadPrev(ENProduct en)
        {
            bool leido = false;
            try
            {
                using (SqlConnection c = new SqlConnection(_constring))
                {
                    c.Open();
                    string sql = "SELECT TOP 1 id, name, code, amount, price, category, creationDate" +
                        "FROM Products WHERE code < @code ORDER BY code DESC";
                    using (SqlCommand com = new SqlCommand(sql, c))
                    {
                        com.Parameters.Add("@code", System.Data.SqlDbType.NVarChar, 16).Value = en.Code;
                        using (SqlDataReader r = com.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                en.Name = r["name"].ToString();
                                en.Amount = Convert.ToInt32(r["amount"]);
                                en.Price = (float)Convert.ToDecimal(r["price"]);
                                en.Category = Convert.ToInt32(r["category"]);
                                en.CreationDate = Convert.ToDateTime(r["creationDate"]);
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
    }
}
