using NLog;
using GenericRest.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GenericRest.Controllers
{
    //[Authorize]
    public class AmericaGisController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/AmericaGis/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        [Route("api/AmericaGis")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]RequestAmericaGis value)
        {
            try
            {
                //value = null;
                logger.Info("Datos recibidos -> Post([FromBody]string value) " + value.ToString());
                RequestAmericaGis item = value;// Newtonsoft.Json.JsonConvert.DeserializeObject<Request>(value);
                logger.Info("Serialize Datos recibidos -> { JsonConvert.SerializeObject(item) " + value.ToString());
                logger.Info("Resultado -> " + InsertValues(item));
                return Ok("Salio OK");
            }
            catch (Exception ex)
            {
                logger.Info("Error -> " + ex.Message);
                throw;
            }
        }

        // PUT api/AmericaGis/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/AmericaGis/5
        public void Delete(int id)
        {
        }

        private static string InsertValues(RequestAmericaGis request)
        {
            try
            {
                string connetionString = null;
                SqlConnection connection;
                SqlDataAdapter adapter;
                SqlCommand command = new SqlCommand();
                SqlParameter param;
                SqlParameter paramReturnErrorCode;
                SqlParameter paramReturnErrorMessage;
                string strResponse;
                string longitud;
                string latitud;

                ConnectionStringSettings mySetting = ConfigurationManager.ConnectionStrings["cnnAmericaGis"];
                if (mySetting == null || string.IsNullOrEmpty(mySetting.ConnectionString))
                    throw new Exception("Fatal error: missing connecting string in web.config file");
                connetionString = mySetting.ConnectionString;

                connection = new SqlConnection(connetionString);

                connection.Open();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_AddGpsHistoricoMovilesActuales";

                param = new SqlParameter("@patente", request.licensePlate??"");
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                command.Parameters.Add(param);

                if (!request.longitude.ToString().Contains(InitSepDecimal()))
                {
                    longitud = request.longitude.ToString().Replace(OtroSepDecimal(), InitSepDecimal());
                }
                else
                {
                    longitud = request.longitude.ToString();
                }
                if (!request.latitude.ToString().Contains(InitSepDecimal()))
                {
                    latitud = request.latitude.ToString().Replace(OtroSepDecimal(), InitSepDecimal());
                }
                else
                {
                    latitud = request.latitude.ToString();
                }

                param = new SqlParameter("@latitud", Convert.ToDecimal(latitud));
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = new SqlParameter("@longitud", Convert.ToDecimal(longitud));
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.Decimal;
                command.Parameters.Add(param);

                param = new SqlParameter("@fecHorTransmision", request.reportDate);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.DateTime;
                command.Parameters.Add(param);

                paramReturnErrorCode = new SqlParameter("@errorCode", " ");
                paramReturnErrorCode.Direction = ParameterDirection.Output;
                paramReturnErrorCode.DbType = DbType.String;
                command.Parameters.Add(paramReturnErrorCode);

                paramReturnErrorMessage = new SqlParameter("@errorMessage", SqlDbType.VarChar, 100);
                paramReturnErrorMessage.Direction = ParameterDirection.Output;
                paramReturnErrorMessage.DbType = DbType.String;
                command.Parameters.Add(paramReturnErrorMessage);

                command.ExecuteNonQuery();
                adapter = new SqlDataAdapter(command);

                if (paramReturnErrorCode.Value.ToString() == string.Empty)
                {
                    strResponse = "Se inserto el registro correactamente: " + request.licensePlate;
                }
                else
                {
                    strResponse = "Se inserto el registro con error: " + request.licensePlate + " - " + paramReturnErrorMessage.Value.ToString();
                }

                connection.Close();
                return strResponse;


            }
            catch (Exception e)
            {

                logger.Error(e);
                return e.Message;
            }
        }

        private static string InitSepDecimal()
        {
            string wSepDecimal;

            if (Convert.ToDecimal("2.5") > 3)
                wSepDecimal = ",";
            else
                wSepDecimal = ".";


            return wSepDecimal;

        }

        private static string OtroSepDecimal()
        {
            string wSepDecimal;

            if (Convert.ToDecimal("2.5") > 3)
                wSepDecimal = ".";
            else
                wSepDecimal = ",";


            return wSepDecimal;

        }
    }
}
