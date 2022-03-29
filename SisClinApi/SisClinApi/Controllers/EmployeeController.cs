using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SisClinApi.Models;

namespace SisClinApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Retorna lista de Funcionarios
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select EmployeeId, EmployeeName, Department, EmployeeRg, EmployeeCpf, EmployeeStatus from
                            dbo.Employee
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SisClinApiCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        //Criar um novo departamento
        [HttpPost]
        public JsonResult Post(Employee emp)
        {
            string query = @"
                            insert into dbo.Employee
                            values (@EmployeeName, @Department, @EmployeeRg, @EmployeeCpf, @EmployeeStatus)
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SisClinApiCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
                    myCommand.Parameters.AddWithValue("@Department", emp.Department);
                    myCommand.Parameters.AddWithValue("@EmployeeRg", emp.EmployeeRg);
                    myCommand.Parameters.AddWithValue("@EmployeeCpf", emp.EmployeeCpf);
                    myCommand.Parameters.AddWithValue("@EmployeeStatus", emp.EmployeeStatus);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Funcionario Criado com sucesso");
        }

        //Atualiza o Departamento existente
        [HttpPut]
        public JsonResult Put(Employee emp)
        {
            string query = @"
                            update dbo.Employee
                            set EmployeeName= @EmployeeName,
                            Department= @Department,
                            EmployeeRg= @EmployeeRg,
                            EmployeeCpf= @EmployeeCpf,
                            EmployeeStatus= @EmployeeStatus
                            where EmployeeId= @EmployeeId
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SisClinApiCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
                    myCommand.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
                    myCommand.Parameters.AddWithValue("@Department", emp.Department);
                    myCommand.Parameters.AddWithValue("@EmployeeRg", emp.EmployeeRg);
                    myCommand.Parameters.AddWithValue("@EmployeeCpf", emp.EmployeeCpf);
                    myCommand.Parameters.AddWithValue("@EmployeeStatus", emp.EmployeeStatus);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("funcionario Atualizado com sucesso");
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            string query = @"
                            delete dbo.Employee
                            where EmployeeId= @EmployeeId
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SisClinApiCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@EmployeeId", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Funcionario deletado com sucesso");
        }
    }
}
