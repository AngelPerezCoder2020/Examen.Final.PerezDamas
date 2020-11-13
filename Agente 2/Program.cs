using System;
using Experimental.System.Messaging;

namespace Agente2
{
    class Agente2
    {
        static void Main(string[] args)
        {
            Console.Clear();
            string archivo = ""; 
            MessageQueue cola = new MessageQueue(".\\private$\\Nombres.Aleatorios");
            Funcionalidades Funciones = new Funcionalidades();
            archivo = Funciones.Recibir(cola, archivo);
            Console.WriteLine(archivo);
        }
    }
    public class Funcionalidades{
        public String Recibir(MessageQueue Cola, string x){
            Message mensaje = Cola.Receive();
            mensaje.Formatter = new XmlMessageFormatter(new String[] {"System.String,mscorlib"} );
            x = mensaje.Body.ToString();
            return x;
        }
    }
}