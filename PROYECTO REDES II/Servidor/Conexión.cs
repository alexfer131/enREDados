using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Servidor
{
    using System;
    using System.Activities.Expressions;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;


   public class Conexión
    {
        public static string Conectar()

        {

            string stringPrueba;
            byte[] bytePrueba = new byte[1024];
            int intPrueba;
            string dirCarpeta;

            Socket miPrimerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  

            // paso 2 - creamos el socket

            IPEndPoint miDireccion = new IPEndPoint(IPAddress.Any, 1500);

            //paso 3 -IPAddress.Any significa que va a escuchar al cliente en toda la red

            try

            {
                
                // paso 4
                miPrimerSocket.Bind(miDireccion); // Asociamos el socket a miDireccion     
                miPrimerSocket.Listen(10); // Lo ponemos a escucha

                while (true) 
                {
                    Socket Escuchar = miPrimerSocket.Accept();// crear clase sockethijo y crear hilo con este socket

                    //creamos el nuevo socket, para comenzar a trabajar con él
                    //La aplicación queda en reposo hasta que el socket se conecte a el cliente
                    //Una vez conectado, la aplicación sigue su camino 
                    while (true) {
                        intPrueba = Escuchar.Receive(bytePrueba);

                        Array.Resize(ref bytePrueba, intPrueba);
                        stringPrueba = Encoding.Default.GetString(bytePrueba);

                        Paquete paquete = new Paquete(stringPrueba);
                        dirCarpeta = string.Concat(@"C:\", paquete.Contenido);

                        if (paquete.Comando == "CrearC")
                        {
                            if (Directory.Exists(dirCarpeta) != true)
                            {
                                    Directory.CreateDirectory(dirCarpeta);
                            }
                        }
                        //Aca ponemos todo lo que queramos hacer con el socket, osea antes de
                        // cerrarlo je
                        Escuchar.Close(); //Luego lo cerramos
                        miPrimerSocket.Close();

                        return stringPrueba;
                    }
                }
            }

            catch (Exception error)
            {
                return error.ToString();
            }

        }


    }
   
}