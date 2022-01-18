using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Web_Conformidad.Controllers
{
    
    public class HomeController : Controller
    {
        public string GeneraToken()
        {
            var grant_type = "password";
            var scope = "https://api.sunat.gob.pe";
            var client_id = "97dee99e-984b-4369-a72e-fb03a6c3defa";
            var client_secret = "caWpscwQt8zFaK5t1kgftg==";
            var username = "20601647649EFACT001";
            var password = "factu2018";

            var request = (HttpWebRequest)WebRequest.Create("https://api-seguridad.sunat.gob.pe/v1/clientessol/" + client_id + "/oauth2/token/");
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;

            var postData = "grant_type=" + grant_type + "&scope=" + scope + "&client_id=" + client_id + "&client_secret=" + client_secret + "&username=" + username + "&password=" + password;
            var data = Encoding.ASCII.GetBytes(postData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            string resp = "";
            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                string responseString = "";
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null)
                        {
                            return resp;
                        }

                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            responseString = objReader.ReadToEnd();
                        }
                    }
                }

                var token = new JavaScriptSerializer().Deserialize<dynamic>(responseString);
                resp = token["access_token"];

                
            }
            catch (ArgumentException ae)
            {
                resp = "Error: " + ae.Message;
            }
            catch (ProtocolViolationException pve)
            {
                resp = "Error: " + pve.Message;
            }
            catch (InvalidOperationException ioe)
            {
                resp = "Error: " + ioe.Message;
            }
            catch (NotSupportedException nse)
            {
                resp = "Error: " + nse.Message;
            }

            
            return resp;

        }

        public object ConsultaDocumentosPND()
        {
            string token = GeneraToken();


            var client = new RestClient("https://api-cpe.sunat.gob.pe/v1/contribuyente/controlcpe/comprobantes?indFechaFiltro=FE&codCpe=01&fecInicio=2021-12-01&fecFin=2022-12-31&numPag=1&numRegPag=50&codEstado=01&codTipTransaccion=&codMoneda=PEN&numSerie=&numCpe=&numRuc=&codTipoDocAdqui=&numDocAdqui=&indContribuyente=C");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + token);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);

            return response.Content;
        }

        public object ConsultaTickets()
        {
            string token = GeneraToken();


            var client = new RestClient("https://api-cpe.sunat.gob.pe/v1/contribuyente/controlcpe/enviosmasivo?indTipoRegistro=01&fecEnvioInicial=2022-01-01&fecEnvioFinal=2022-01-10&numPag=1&numRegPag=20&codTicketMasivo=");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + token);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);

            return response.Content;
        }

        public object EnviaConformidad(string rutaArchivo)
        {
            string token = GeneraToken();

            var client = new RestClient("https://api-cpe.sunat.gob.pe/v1/contribuyente/controlcpe/enviosmasivo/01");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddFile("archivo", @rutaArchivo);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);

            return response.Content;
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult GetToken()
        {
            string token = GeneraToken();
            return Json(token, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetDocumntosPND()
        {
            var objRes = ConsultaDocumentosPND();

            return Json(objRes, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetTicketsPND()
        {
            var objRes = ConsultaTickets();

            return Json(objRes, JsonRequestBehavior.AllowGet);
        }
       
        [HttpPost]
        public JsonResult PostConformidad(string rutaArchivo)
        {
            var objRes = EnviaConformidad("");

            return Json(objRes, JsonRequestBehavior.AllowGet);
        }

    }
}