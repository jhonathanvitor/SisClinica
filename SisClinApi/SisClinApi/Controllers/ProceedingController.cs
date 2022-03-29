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
    public class ProceedingController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public ProceedingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Retorna lista de Procedimentos
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select ProceedingId, ProceedingName, ProceedingPrice from
                            dbo.Proceeding
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

        //Criar um novo Cliente
        [HttpPost]
        public JsonResult Post(Proceeding pro)
        {
            string query = @"
                            insert into dbo.Proceeding
                            values (@ProceedingName, @ProceedingPrice)
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SisClinApiCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ProceedingName", pro.ProceedingName);
                    myCommand.Parameters.AddWithValue("@ProceedingPrice", pro.ProceedingPrice);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Procedimento Criado com sucesso");
        }

        //Atualiza o procedimento existente
        [HttpPut]
        public JsonResult Put(Proceeding pro)
        {
            string query = @"
                            update dbo.Proceeding
                            set ProceedingName= @ProceedingName,
                            ProceedingPrice= @ProceedingPrice
                            where ProceedingId= @ProceedingId
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SisClinApiCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ProceedingId", pro.ProceedingId);
                    myCommand.Parameters.AddWithValue("@ProceedingName", pro.ProceedingName);
                    myCommand.Parameters.AddWithValue("@ProceedingPrice", pro.ProceedingPrice);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Procedimento Atualizado com sucesso");
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            string query = @"
                            delete dbo.Proceeding
                            where ProceedingId= @ProceedingId
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SisClinApiCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@ProceedingId", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Procedimento deletado com sucesso");
        }
    }
}
