using System;
using Google.Cloud.Firestore;
using Experimental.System.Messaging;

namespace Agente2
{
    class Agente2
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.Clear();
            MessageQueue cola = new MessageQueue(".\\private$\\Nombres.Aleatorios");
            Funcionalidades Funciones = new Funcionalidades();
            FirestoreDb db = FirestoreDb.Create("examenfinal-angelperez");
            await Funciones.EnviarAlaNubeAsync(cola, db);
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