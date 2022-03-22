using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace adoproject.Models
{
    public class EmployeeDataAccess
    {
        DBconnection dconnection;
        public EmployeeDataAccess()
        {
            dconnection = new DBconnection();
        }
        public List<Employee> GetEmployees()
        {
            string sp = "sp_employees";
            SqlCommand sql = new SqlCommand(sp, dconnection.connection);
            sql.Parameters.AddWithValue("@action", "select_join");
            sql.CommandType = CommandType.StoredProcedure;
            if (dconnection.connection.State==ConnectionState.Closed)
            {
                dconnection.connection.Open();
            }

            SqlDataReader dr = sql.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (dr.Read())
            {
                Employee emp = new Employee();
                emp.id = (int)dr["id"];
                emp.Fname = dr["fname"].ToString();
                emp.Lname = dr["lname"].ToString();
                emp.Email = dr["email"].ToString();
                emp.Mobile = dr["mobile"].ToString();
                emp.Gender = dr["gender"].ToString();
                emp.Department = dr["dname"].ToString();
                employees.Add(emp);
            }
            dconnection.connection.Close();
            return employees;
            
        }
        
        public Employee GetEmployeesbyid(int id)
        {
            string sp = "sp_employees";
            SqlCommand sql = new SqlCommand(sp, dconnection.connection);
            sql.Parameters.AddWithValue("@action", "selectid");
            sql.Parameters.AddWithValue("@id", id);
            sql.CommandType = CommandType.StoredProcedure;
            if (dconnection.connection.State==ConnectionState.Closed)
            {
                dconnection.connection.Open();
            }

            SqlDataReader dr = sql.ExecuteReader();
            dr.Read();
            
                Employee emp = new Employee();
                emp.id = (int)dr["id"];
                emp.Fname = dr["fname"].ToString();
                emp.Lname = dr["lname"].ToString();
                emp.Email = dr["email"].ToString();
                emp.Mobile = dr["mobile"].ToString();
                emp.Gender = dr["gender"].ToString();
                emp.deptid = (int)dr["deptid"];
               
            
            dconnection.connection.Close();
            return emp;
            
        }
        
        public bool createEmployees(Employee emp)
        {
            
            string sp = "sp_employees";
            SqlCommand sql = new SqlCommand(sp, dconnection.connection);
            sql.Parameters.AddWithValue("@action", "create");
            sql.Parameters.AddWithValue("@fname", emp.Fname);
            sql.Parameters.AddWithValue("@lname", emp.Lname);
            sql.Parameters.AddWithValue("@email",emp.Email );
            sql.Parameters.AddWithValue("@mobile",emp.Mobile );
            sql.Parameters.AddWithValue("@gender",emp.Gender );
            sql.Parameters.AddWithValue("@deptid", emp.deptid);
            sql.CommandType = CommandType.StoredProcedure;
            if (dconnection.connection.State==ConnectionState.Closed)
            {
                dconnection.connection.Open();
            }

            int i = sql.ExecuteNonQuery();
           
            dconnection.connection.Close();
            return Convert.ToBoolean(i);
            
        }
        public bool DeleteEmployees(int id)
        {
            
            string sp = "sp_employees";
            SqlCommand sql = new SqlCommand(sp, dconnection.connection);
            sql.Parameters.AddWithValue("@action", "delete");
            sql.Parameters.AddWithValue("@id",id);
           
            sql.CommandType = CommandType.StoredProcedure;
            if (dconnection.connection.State==ConnectionState.Closed)
            {
                dconnection.connection.Open();
            }

            int i = sql.ExecuteNonQuery();
           
            dconnection.connection.Close();
            return Convert.ToBoolean(i);
            
        }
        public bool updateEmployees(Employee emp)
        {
            
            string sp = "sp_employees";
            SqlCommand sql = new SqlCommand(sp, dconnection.connection);
            sql.Parameters.AddWithValue("@action", "update");
            sql.Parameters.AddWithValue("@id", emp.id);
            sql.Parameters.AddWithValue("@fname", emp.Fname);
            sql.Parameters.AddWithValue("@lname", emp.Lname);
            sql.Parameters.AddWithValue("@email",emp.Email );
            sql.Parameters.AddWithValue("@mobile",emp.Mobile );
            sql.Parameters.AddWithValue("@gender",emp.Gender );
            sql.Parameters.AddWithValue("@deptid", emp.deptid);
            sql.CommandType = CommandType.StoredProcedure;
            if (dconnection.connection.State==ConnectionState.Closed)
            {
                dconnection.connection.Open();
            }

            int i = sql.ExecuteNonQuery();
           
            dconnection.connection.Close();
            return Convert.ToBoolean(i);
            
        }
    }
}
