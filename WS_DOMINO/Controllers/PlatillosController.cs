using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WS_DOMINO.Models;

namespace WS_DOMINO.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PlatillosController : ApiController
    {
        BDController bd = new BDController();
        DataTable dt = new DataTable();
        List<Platillo> platillos = new List<Platillo>();

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("domino/api/platillos")]

        public IEnumerable<Platillo> Platillos()
        {
            try
            {

                //object[] parametros;

                dt = bd.SPRefcursor("PKG_DOMINO.PRC_PLATILLOS", null);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {


                        platillos.Add(
                            new Platillo
                            {
                                Id = int.Parse(item["PLATILLO_ID"].ToString()),
                                Valor = int.Parse(item["VALOR"].ToString()),
                                PromedioPreparacion = int.Parse(item["PROMEDIO_PREPARACION"].ToString()),
                                Descripcion = item["DESCRIPCION"].ToString(),
                                Src = item["SRC"].ToString(),
                                Nombre = item["NOMBRE"].ToString()
                            });
                    }
                }
                return platillos;

            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }
    }
}
