using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace qunatumkey
{
    
    public class Database
    {
        string constr = "server=localhost;uid=sa;pwd=abc123;database=quantumkey;";
                
        //Insert into database
        public void insert(string qry)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(qry,con);
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch(Exception ex)
        {
            string ss=ex.Message;            
        }
        con.Close();
        }

        //view 
        public string[] view(string qry)
        {
            string[] a = new string[100];
            int i = 1;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    a[i] = dr[0].ToString();
                    i++;
                }
                a[0] = i.ToString();
            }
            catch (Exception ex)
            {
                string ss=ex.Message;

            }
            return a;
        }

        public string[] selectQuery(String query)
        {
            String[] resultString = new String[10];
            
            SqlConnection connection = new SqlConnection(constr);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    resultString[0] = dataReader[0].ToString();
                    resultString[1] = dataReader[1].ToString();

                }
            }
            catch (Exception ex)
            {
                String ss = ex.Message;
            }

            return resultString;
        }


    }
     
}
