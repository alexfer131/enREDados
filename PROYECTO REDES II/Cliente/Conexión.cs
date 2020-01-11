using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Net;
using System.Net.Sockets;

namespace Cliente
{
    class Conexión {

        public static string Conectar(string respuesta)

        {

            Socket miPrimerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // paso 2 - creamos el socket

            IPEndPoint miDireccion = new IPEndPoint(IPAddress.Parse(Form1.enviarIP()), 1500); //paso 3 - Acá debemos poner la Ip del servidor, y el puerto de escucha del servidor

            try

            {

                miPrimerSocket.Connect(miDireccion);// Conectamos      
                miPrimerSocket.Send(transformarStringBytes(respuesta));
                miPrimerSocket.Close();
                return "Conectado con exito";

            }

            catch (Exception error)

            {

                return error.ToString();

            }

        } 

        public static void CrearCarpeta(String peticion)
        {

            byte[] byteRespuesta = new byte[2147483];
            string respuesta;
            int intRespuesta;

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint miDireccion = new IPEndPoint(IPAddress.Parse(Form1.enviarIP()), 1500);
            try
            {
                socket.Connect(miDireccion);// Conectamos      
                socket.Send(transformarStringBytes(peticion));
                intRespuesta = socket.Receive(byteRespuesta);
                Array.Resize(ref byteRespuesta, intRespuesta);
                respuesta = Encoding.Default.GetString(byteRespuesta);
                socket.Close();

            }

            catch (Exception error)
            {
               error.ToString();

            }
        }



        public static byte[] transformarStringBytes(string Datos)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] bytes = Encoding.ASCII.GetBytes(Datos);
            return bytes;
        }
        public static string transformarBytesString(byte[] bytes)
        {
            string Datos = Encoding.ASCII.GetString(bytes);
            return Datos;
        }

        

    }

}
