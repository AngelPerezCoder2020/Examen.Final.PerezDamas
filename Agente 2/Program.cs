using System;
using System.Threading;
using Google.Cloud.Firestore;
using Experimental.System.Messaging;

namespace Agente2
{
    class Agente2{
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            string opc = "";
            int x = 0;
            int y = 0;
            Console.Clear();
            MessageQueue cola = new MessageQueue(".\\private$\\Nombres.Aleatorios");
            Funcionalidades Funciones = new Funcionalidades();
            FirestoreDb db = FirestoreDb.Create("examenfinal-angelperez");

            do{
                Console.Clear();
                Console.WriteLine("|AGENTE 2 --- ' ENCOLA_FIRE '| \n \nIngrese Una Opción para continuar: \n \n1.ACTIVAR AGENTE \n2.SALIR DEL PROGRAMA");
                opc = Console.ReadLine();
                switch(opc){
                    case "1":
                        Console.WriteLine(" \n \nActivando Funcionalidad...");
                        Thread.Sleep(2000);
                        while(x==0){
                            Console.Clear();
                            await Funciones.EnviarAlaNubeAsync(cola, db);
                            y++;
                            Console.WriteLine($"     |AGENTE 2 --- ' ENCOLA_FIRE '| \n \nMensajes Almacenados en Firebase: {y}");
                            Thread.Sleep(2000);
                        }

                    break;
                    case "2":
                        Console.WriteLine(" \n \nEl agente numero 2 ya se va a dormir... zzZZ");
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
        public String Recibir(MessageQueue Cola){
            Message mensaje = Cola.Receive();
            mensaje.Formatter = new XmlMessageFormatter(new String[] {"System.String,mscorlib"} );
            string x = mensaje.Body.ToString();
            return x;
        }
        public async System.Threading.Tasks.Task EnviarAlaNubeAsync(MessageQueue cola, FirestoreDb db){
            CollectionReference collection = db.Collection("Archivos");
            String archivo = Recibir(cola);
            DocumentReference document = await collection.AddAsync(new {Archivo = archivo});
            DocumentSnapshot snapshot = await document.GetSnapshotAsync();
        }
    }
}