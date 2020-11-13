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
            string opc = "";
            int y = 0;
            Console.Clear();
            int x = 0;
            string archivo = ""; 
            MessageQueue cola = new MessageQueue(".\\private$\\Nombres.Aleatorios");
            Funcionalidades Funciones = new Funcionalidades();
            do{
                Console.Clear();
                Console.WriteLine("|AGENTE 1 --- ' EncolaWindow '| \n \nIngrese Una Opción para continuar: \n \n1.ACTIVAR AGENTE \n2.SALIR DEL PROGRAMA");
                opc = Console.ReadLine();
                switch(opc){
                    case "1":
                        Console.WriteLine(" \n \nActivando Funcionalidad...");
                        Thread.Sleep(2000);
                        while(x==0){
                            Console.Clear();
                            archivo = Funciones.Generar_Archivo(archivo);
                            Funciones.Encolar_Mensage(archivo,cola);
                            y++;
                            Console.WriteLine($"     |AGENTE 1 --- ' EncolaWindow '| \n \nMensajes Encolados a las colas locales de Windows: {y}");
                            Thread.Sleep(3000);
                        }
                    break;
                    case "2":
                        Console.WriteLine(" \n \nEl agente numero 1 ya se va a dormir... zzZZ");
                        Console.ReadKey();
                    break;
                    default:
                        Console.WriteLine($" \n \nLa opcion '{opc}' no existe, por favor presione Enter e intentelo de nuevo");
                        Console.ReadKey();
                    break;
                }
            }while(opc != "2");
        }
    }
    public class Funcionalidades{
        public string Generar_Archivo(string x){
            x = Path.GetRandomFileName();
            return x;
        }
        public void Encolar_Mensage(string x, MessageQueue y){
            Message msg = new Message();
            msg.Label = "Archivo";
            msg.Body = x; 
            y.Send(msg);           
        }
    }
}