using System.Collections.Generic;
using static Progetto_Market_Admin.Modelli;

namespace Progetto_Market_Admin
{
    public class ResponseModel
    {
        public class Response_Serializable
        {
            public string Errore { get; set; }
        }

        public class Response_Profili : Response_Serializable
        {
            public List<Profilo> ListaProfili { get; set; }
        }

        public class Response_User : Response_Serializable
        {
            public List<Utente> ListaUtenti { get; set; }
        }

        public class Response_Fornitori : Response_Serializable
        {
            public List<Fornitore> ListaFornitori { get; set; }
        }
    }
}
