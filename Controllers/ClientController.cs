using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using api_davivienda_cliente.Utils;

namespace api_davivienda_cliente.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private string connection = Environment.GetEnvironmentVariable("connection_string");
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Models.Client> clients = null;
            FormatResponse response = new FormatResponse();
            try
            {

                using (var db = new MySqlConnection(connection))
                {
                    var sqlQuery = "SELECT * FROM Cliente";
                    clients = db.Query<Models.Client>(sqlQuery);
                }
                response.state = true;
                response.message = "Obteniendo todos los cliente de manera correcta.";
                response.Data = clients;
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public IActionResult Post(Models.Client client)
        {
            FormatResponse response = new FormatResponse();
            int result = 0;
            try
            {
                using (var db = new MySqlConnection(connection))
                {
                    var sqlQuery = "INSERT INTO Cliente(idIdentificacion, nombre, direccion, telefono) " + "values(@idIdentificacion, @nombre, @direccion, @telefono)";
                    result = db.Execute(sqlQuery, client);
                }
                response.state = true;
                response.message = "Cliente creado de manera correcta.";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.state = false;
                response.message = ex.Message;
                return Ok(response);
                
            }

        }

        [HttpPut]
        public IActionResult Put(Models.Client client)
        {
            int result = 0;
            FormatResponse response = new FormatResponse();
            try
            {
                using (var db = new MySqlConnection(connection))
                {
                    var sqlQuery = "UPDATE Cliente set idIdentificacion=@idIdentificacion, nombre=@nombre, direccion=@direccion, telefono=@telefono " + "where idIdentificacion = @idIdentificacion";
                    result = db.Execute(sqlQuery, client);
                    if (result == 0)
                    {
                        response.state = true;
                        response.message = "El cliente que desea modificar no existe";
                        return Ok(response);
                    }
                }
                response.state = true;
                response.message = "Cliente modificado correctamente";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.state = false;
                response.message = ex.Message;
                return Ok(response);
            }
 
        }

        [HttpDelete]
        public IActionResult Delete(Models.Client client)
        {
            int result = 0;
            FormatResponse response = new FormatResponse();
            try
            {
                using (var db = new MySqlConnection(connection))
                {
                    var sqlQuery = "DELETE FROM Cliente where idIdentificacion=@idIdentificacion";
                    result = db.Execute(sqlQuery, client);
                    if (result == 0)
                    {
                        response.state = true;
                        response.message = "El cliente que desea borrar no existe";
                        return Ok(response);
                    }
                }
                response.state = true;
                response.message = "Cliente borrado correctamente";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.state = false;
                response.message = ex.Message;
                return Ok(response);
            }
           


        }
    }
}
