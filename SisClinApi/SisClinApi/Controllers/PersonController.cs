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
    public class PersonController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public PersonController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Retorna lista de Clientes
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select PersonId, PersonName, PersonRg, PersonCpf, PersonAndress from
                            dbo.Person
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
        public JsonResult Post(Person per)
        {
            string query = @"
                            insert into dbo.Person
                            values (@PersonName, @PersonRg, @PersonCpf, @PersonAndress)
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SisClinApiCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@PersonName", per.PersonName);
                    myCommand.Parameters.AddWithValue("@PersonRg", per.PersonRg);
                    myCommand.Parameters.AddWithValue("@PersonCpf", per.PersonCpf);
                    myCommand.Parameters.AddWithValue("@PersonAndress", per.PersonAndress);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Funcionario Criado com sucesso");
        }

        //Atualiza o cliente existente
        [HttpPut]
        public JsonResult Put(Person per)
        {
            string query = @"
                            update dbo.Person
                            set PersonName= @PersonName,
                            PersonRg= @PersonRg,
                            PersonCpf= @PersonCpf,
                            PersonAndress= @PersonAndress
                            where PersonId= @PersonId
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SisClinApiCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@PersonId", per.PersonId);
                    myCommand.Parameters.AddWithValue("@PersonName", per.PersonName);
                    myCommand.Parameters.AddWithValue("@PersonRg", per.PersonRg);
                    myCommand.Parameters.AddWithValue("@PersonCpf", per.PersonCpf);
                    myCommand.Parameters.AddWithValue("@PersonAndress", per.PersonAndress);
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
                            delete dbo.Person
                            where PersonId= @PersonId
                            ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SisClinApiCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@PersonId", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Cliente deletado com sucesso");
        }
    }
}
