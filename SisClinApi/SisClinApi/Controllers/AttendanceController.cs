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
    public class AttendanceController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AttendanceController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Retorna lista de atendimento
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select AttendanceId, AttendanceDate, AttendanceEmployee, AttendancePerson, AttendanceProceeding from
                            dbo.Attendance
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

        //Criar um novo Atendimento
        [HttpPost]
        public JsonResult Post(Attendance att)
        {
            string query = @"
                            insert into dbo.Attendance
                            values (@AttendanceDate, @AttendanceEmployee, @AttendancePerson, @AttendanceProceeding)
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SisClinApiCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@AttendanceDate", att.AttendanceDate);
                    myCommand.Parameters.AddWithValue("@AttendanceEmployee", att.AttendanceEmployee);
                    myCommand.Parameters.AddWithValue("@AttendancePerson", att.AttendancePerson);
                    myCommand.Parameters.AddWithValue("@AttendanceProceeding", att.AttendanceProceeding);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Atendimento Criado com sucesso");
        }

        //Atualiza o atendimento existente
        [HttpPut]
        public JsonResult Put(Attendance att)
        {
            string query = @"
                            update dbo.Attendance
                            set AttendanceDate= @AttendanceDate,
                            AttendanceEmployee = @AttendanceEmployee,
                            AttendancePerson= @AttendancePerson,
                            AttendanceProceeding= @AttendanceProceeding
                            where AttendanceId= @AttendanceId
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SisClinApiCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@AttendanceId", att.AttendanceId);
                    myCommand.Parameters.AddWithValue("@AttendanceDate", att.AttendanceDate);
                    myCommand.Parameters.AddWithValue("@AttendanceEmployee", att.AttendanceEmployee);
                    myCommand.Parameters.AddWithValue("@AttendancePerson", att.AttendancePerson);
                    myCommand.Parameters.AddWithValue("@AttendanceProceeding", att.AttendanceProceeding);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Atendimento Atualizado com sucesso");
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            string query = @"
                            delete dbo.Attendance
                            where AttendanceId= @AttendanceId
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SisClinApiCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@AttendanceId", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Atendimento deletado com sucesso");
        }
    }
}
