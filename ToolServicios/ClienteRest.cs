using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
namespace ToolServicios
{
    public class ClienteRest<T>
    {
        public string url { get; set; }
        public string metodo { get; set; }
        public RespuestaRestLista<T> respuesta { get; set; }

        public ClienteRest()
        {
            url = string.Empty;
            metodo = "GET";
        }

        public RespuestaRestLista<T> ObtenerRESTreporte()
        {
            RespuestaRestLista<T> respuesta = new RespuestaRestLista<T>();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = metodo.ToString();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode != HttpStatusCode.OK)
            {

            }
            else
            {
                Stream resultadoResponse = response.GetResponseStream();
                StreamReader lector = new StreamReader(resultadoResponse);
                string cadena = lector.ReadToEnd();
                MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(cadena));
                DataContractJsonSerializer conversion = new DataContractJsonSerializer(typeof(RespuestaRestLista<T>));

                respuesta = (RespuestaRestLista<T>)conversion.ReadObject(ms);
            }
            return respuesta;

        }
        public RespuestaRestArray ObtenerRESTArreglo()
        {
            RespuestaRestArray respuesta = new RespuestaRestArray();

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = metodo.ToString();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {

                }
                else
                {
                    Stream resultadoResponse = response.GetResponseStream();
                    StreamReader lector = new StreamReader(resultadoResponse);
                    string cadena = lector.ReadToEnd();
                    MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(cadena));
                    DataContractJsonSerializer conversion = new DataContractJsonSerializer(typeof(RespuestaRestArray));

                    respuesta = (RespuestaRestArray)conversion.ReadObject(ms);
                }
            }
            catch (Exception ex)  
            {
                respuesta.respuesta = 0;
                respuesta.aviso = ex.Message;
                respuesta.mensaje = null;
            }
            finally {
                    
            }

               return respuesta;
        }
        public RespuestaRestArray ObtenerRESTInsertaModifica(T entidad)
        {
            RespuestaRestArray respuesta = new RespuestaRestArray();

            try
            {
                //Forma cadena DATA en base a una entidad T
                //---------------------------------------------------
                DataContractJsonSerializer comunicacionServicio = new DataContractJsonSerializer(typeof(T));
                MemoryStream mensaje = new MemoryStream();
                comunicacionServicio.WriteObject(mensaje, entidad);
                string formarData = Encoding.UTF8.GetString(mensaje.ToArray(), 0, (int)mensaje.Length);
                //---------------------------------------------------

                //Forma solicitu POST, pase de DATA y Respuesta servicio 
                //-----------------------------------------------
                //Se forma DATA
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] data = encoding.GetBytes(formarData);

                //Se crea comunicacion con servicio
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = metodo.ToString();
                request.ContentType = "application/json; charset=utd-8";
                request.ContentLength = data.Length;
                Stream newStream = request.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();

                //Se recibe respuesta JSON
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {

                }
                else
                {
                    Stream resultadoResponse = response.GetResponseStream();
                    StreamReader lector = new StreamReader(resultadoResponse);
                    string cadena = lector.ReadToEnd();
                    MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(cadena));
                    DataContractJsonSerializer conversion = new DataContractJsonSerializer(typeof(RespuestaRestArray));

                    respuesta = (RespuestaRestArray)conversion.ReadObject(ms);
                }


            }
            catch
            {
                respuesta.respuesta = 0;
                respuesta.aviso = "";
                respuesta.mensaje = null;
            }
            finally {
                    
            }

            return respuesta;
        }

    }
}
