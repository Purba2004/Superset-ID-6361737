using System;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeByDepartmentApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string connectionString = @"Data Source=localhost;Initial Catalog=sp_GetEmployeeCountByDepartment;Integrated Security=True";

            Console.Write("Enter Department ID to view employees: ");

            if (!int.TryParse(Console.ReadLine(), out int departmentId))
            {
                Console.WriteLine("Invalid input. Department ID must be a number.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetEmployeesByDepartment", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DepartmentID", departmentId);

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            Console.WriteLine("\nEmployee Details:");
                            Console.WriteLine(new string('-', 80));

                            // Print column headers
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write($"{reader.GetName(i),-20}");
                            }
                            Console.WriteLine("\n" + new string('-', 80));

                            // Print rows
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write($"{reader[i],-20}");
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No employees found in this department.");
                        }

                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
