using MiApiUdelp.Data;
using MiApiUdelp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MiApiUdelp.Controllers
{
    public class GeodataController : ApiController
    {
        // GET: api/Geodata
        [HttpGet, Route("api/Personalizar/ruta")]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage answer = null;
            EntityResponse response = new EntityResponse();
            try
            {
                EntityGpsData[] myList = null;

                using(DataSet data = GpsData.gpsDataGetAll())
                {
                    if(data != null)
                    {
                        myList = new EntityGpsData[data.Tables[0].Rows.Count];
                        for(int i = 0; i < data.Tables[0].Rows.Count; i++)
                        {
                            EntityGpsData values = new EntityGpsData();
                            values.id = Convert.ToInt32(data.Tables[0].Rows[i][0]);
                            values.dateSystem = Convert.ToString(data.Tables[0].Rows[i][1]);
                            values.androidId = Convert.ToString(data.Tables[0].Rows[i][2]);
                            values.latitude = Convert.ToSingle(data.Tables[0].Rows[i][3]);
                            values.longitude = Convert.ToSingle(data.Tables[0].Rows[i][4]);
                            values.battery = Convert.ToInt32(data.Tables[0].Rows[i][5]);
                            myList[i] = values;
                        }
                    }
                }
                response.values = myList; 
                answer = Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch(Exception ex)
            {
                response.message = ex.ToString();
                answer = Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
            return answer;
        }

        // GET: api/Geodata/5
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage answer = null;
            EntityResponse response = new EntityResponse();
            try
            {
                EntityGpsData[] myList = null;

                using (DataSet data = GpsData.gpsDataGetOne(new EntityGpsData { id = id}))
                {
                    if (data != null && data.Tables[0].Rows.Count == 1)
                    {
                        myList = new EntityGpsData[data.Tables[0].Rows.Count];                        
                        EntityGpsData values = new EntityGpsData();
                        values.id = Convert.ToInt32(data.Tables[0].Rows[0][0]);
                        values.dateSystem = Convert.ToString(data.Tables[0].Rows[0][1]);
                        values.androidId = Convert.ToString(data.Tables[0].Rows[0][2]);
                        values.latitude = Convert.ToSingle(data.Tables[0].Rows[0][3]);
                        values.longitude = Convert.ToSingle(data.Tables[0].Rows[0][4]);
                        values.battery = Convert.ToInt32(data.Tables[0].Rows[0][5]);
                        myList[0] = values;
                        
                    }
                    response.values = myList;
                    answer = Request.CreateResponse(HttpStatusCode.OK, response);
                }
            }
            catch (Exception ex)
            {
                response.message = ex.ToString();
                answer = Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
            return answer;
        }

        // POST: api/Geodata
        public HttpResponseMessage Post([FromBody]EntityGpsData value)
        {
            HttpResponseMessage answer = null;
            EntityResponse response = new EntityResponse();
            try
            {;

                int index = GpsData.gpsDataAdd(value);
                if (index > 0)
                {
                    response.message = index.ToString();
                    answer = Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                {
                    response.message = "No se pudo guardar el registro en la base de datos";
                    answer = Request.CreateResponse(HttpStatusCode.NotAcceptable, response);
                }
            }
            catch (Exception ex)
            {
                response.message = ex.ToString();
                answer = Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
            return answer;
        }

        // PUT: api/Geodata
        public HttpResponseMessage Put([FromBody]EntityGpsData value)
        {
            HttpResponseMessage answer = null;
            EntityResponse response = new EntityResponse();
            try
            {
                int index = GpsData.gpsDataUpdate(value);
                if (index > 0)
                {
                    response.message = index.ToString();
                    answer = Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                {
                    response.message = "No se pudo actualizar el registro en la base de datos";
                    answer = Request.CreateResponse(HttpStatusCode.NotAcceptable, response);
                }
            }
            catch (Exception ex)
            {
                response.message = ex.ToString();
                answer = Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
            return answer;
        }

        // DELETE: api/Geodata/5
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage answer = null;
            EntityResponse response = new EntityResponse();
            try
            {
                int index = GpsData.gpsDataDelete(new EntityGpsData { id = id });
                if (index > 0)
                {
                    response.message = index.ToString();
                    answer = Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                {
                    response.message = "No se pudo eliminar el registro en la base de datos";
                    answer = Request.CreateResponse(HttpStatusCode.NotAcceptable, response);
                }
            }
            catch (Exception ex)
            {
                response.message = ex.ToString();
                answer = Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
            return answer;
        }
    }
}
