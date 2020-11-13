using System;
using System.Threading;
using System.IO;
using Experimental.System.Messaging;

namespace Agentes
{
    class Program
    {
        static void Main(string[] args)
        {
            int y = 0;
            Console.Clear();
            int x = 0;
            string archivo = ""; 
            MessageQueue cola = new MessageQueue(".\\private$\\Nombres.Aleatorios");
            Funcionalidades Funciones = new Funcionalidades();
            do{
                y++;
                Console.Clear();
                archivo = Funciones.Generar_Archivo(archivo);
                Message w = Funciones.Crear_Mensage(archivo);
                Funciones.Enviar(w, cola);
                Console.WriteLine("Trabajando... \n");
                Console.WriteLine($"Mensajes Encolados: {y}");
                Thread.Sleep(3000);
            }while(x == 0);
        }
    }
    public class Funcionalidades{
        public string Generar_Archivo(string x){
            x = Path.GetRandomFileName();
            return x;
        }
        public Message Crear_Mensage(string x){
            Message msg = new Message();
            msg.Label = "Archivo";
            msg.Body = x; 
            return msg;           
        }
        public void Enviar(Message x, MessageQueue y){
            y.Send(x);
        }
    }
}