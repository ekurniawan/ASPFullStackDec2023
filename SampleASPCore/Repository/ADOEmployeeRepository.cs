using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SampleASPCore.Models;

namespace SampleASPCore.Repository
{
    public class ADOEmployeeRepository : IEmployee
    {
        private readonly IConfiguration _config;
        public ADOEmployeeRepository(IConfiguration config)
        {
            _config = config;
        }

        public Employee Add(Employee employee)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"insert into Employees(FullName,Email) values(@FullName,@Email);
                                select @@identity";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@FullName", employee.FullName);
                cmd.Parameters.AddWithValue("@Email", employee.Email);

                try
                {
                    conn.Open();
                    int empID = Convert.ToInt32(cmd.ExecuteScalar());
                    employee.EmployeeID = empID;

                    return employee;
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Error: {sqlEx.Message}");
                }
            }
        }

        public void AddEmployeeWithDepartment()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"delete from Employees where EmployeeID=@EmployeeID";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Error: {sqlEx.Message} - {sqlEx.Number}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"{ex.Message}");
                }
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            List<Employee> lstEmployees = new List<Employee>();
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Employees order by FullName asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lstEmployees.Add(new Employee
                        {
                            EmployeeID = Convert.ToInt32(dr["EmployeeID"]),
                            FullName = dr["FullName"].ToString(),
                            Email = dr["Email"].ToString()
                        });
                    }
                }
                dr.Close();
                return lstEmployees;
            }
        }

        public Employee GetById(int id)
        {
            Employee employee = new Employee();
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Employees where EmployeeID=@EmployeeID";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", id);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    employee.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                    employee.FullName = dr["FullName"].ToString();
                    employee.Email = dr["Email"].ToString();
                }
                dr.Close();
                return employee;
            }
        }

        public IEnumerable<Employee> GetEmployeeWithProject()
        {
            throw new NotImplementedException();
        }

        public void Update(Employee employee)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"update Employees set FullName=@FullName,Email=@Email 
                                  where EmployeeID=@EmployeeID";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@FullName", employee.FullName);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);

                try
                {
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result != 1)
                        throw new Exception($"Error: gagal update data {employee.EmployeeID}");
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Error: {sqlEx.Message}");
                }
            }
        }

        private string GetConnStr()
        {
            return _config.GetConnectionString("SQLServerConnectionString");
        }


    }
}