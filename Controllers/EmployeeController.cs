using System.Data;
using System.Data.SqlClient;
using EmployeePayrollApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePayrollApp.Controllers
{
    
    public class EmployeeController : Controller
    {
        SqlConnection con;
        public EmployeeController()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-BP7OD30\SQLEXPRESS;Initial Catalog=Emp_Payroll;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //[Route("AllEmployee")]
        public JsonResult EmployeeList()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            con.Open();
            using(SqlCommand cmd = new SqlCommand("GetData",con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        EmployeeModel employee = new EmployeeModel()
                        {
                            Id = (int)reader["ID"],
                            Name = reader["Name"].ToString(),
                            State = reader["state"].ToString(),
                            City = reader["City"].ToString(),
                            Salary =(decimal) reader["Salary"]

                        };
                        employees.Add(employee);
                    }
                }
            }
            con.Close();
            return new JsonResult(employees);
        }

        [HttpPost]
        public JsonResult AddEmployee(EmployeeModel employee)
        {
            
            
                con.Open();
                using (SqlCommand cmd = new SqlCommand("InsertData", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@State", employee.State);
                    cmd.Parameters.AddWithValue("@City", employee.City);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);

                    cmd.ExecuteNonQuery();
                }
                con.Close();
                return new JsonResult("Data is Saved");
           
        }
        public JsonResult Delete(int id)
        {
            try
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand("DeleteById",con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                }
                con.Close();
                return new JsonResult("Data Deleted");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public JsonResult Edit(int id)
        {
            try
            {
                con.Open();
                EmployeeModel employee=new EmployeeModel();
                using (SqlCommand cmd= new SqlCommand("GetById",con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            employee = new EmployeeModel()
                            {
                                Id = (int)reader["ID"],
                                Name = reader["Name"].ToString(),
                                State = reader["state"].ToString(),
                                City = reader["City"].ToString(),
                                Salary = (decimal)reader["Salary"]

                            };
                            con.Close();
                            
                        }
                    }

                }
                return new JsonResult(employee);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public JsonResult Update(EmployeeModel employee)
        {
            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UpdateData", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", employee.Id);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@State", employee.State);
                    cmd.Parameters.AddWithValue("@City", employee.City);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);

                    cmd.ExecuteNonQuery();
                }
                con.Close();
                return new JsonResult("Data Updated");
            }
            catch( Exception ex )
            {
                throw ex;
            }
        }
    }
}
