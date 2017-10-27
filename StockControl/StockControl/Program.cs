using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace StockControl
{
    class Program
    {
        static void Main(string[] args)
            
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=ZOE\\SQLEXPRESS;Database=StockControl;Trusted_Connection=true";
                SqlCommand command = new SqlCommand("SELECT * FROM STOCKCONTROL", conn);
                conn.Open();
                command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("The product is called {0}. There are {2} of them. They each weigh {3} and I would describe them as \"{4}\"",
                        // call the objects from their index
                        reader[0], reader[1], reader[2], reader[3], reader[4]));
                        // write the data on to the screen
                        /*                        Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3} \t | {4}",
                                                // call the objects from their index
                                                reader[0], reader[1], reader[2], reader[3], reader[4])); */

                        // guide https://www.codeproject.com/Articles/823854/How-to-connect-SQL-Database-to-your-Csharp-program
                    }
                }
            }
        }
    }
}
