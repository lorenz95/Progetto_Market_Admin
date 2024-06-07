namespace Progetto_Market_Admin
{
    public class Modelli
    {
        public class Serializable {
            public int ID { get; set; }
        }

        public class Profilo : Serializable
        {
            //public int ID { get; set; }
            public string Tipo { get; set; }
            public string Descrizione { get; set; }
        }

        public class Utente : Serializable
        {
            //public int ID { get; set; }
            public string Nome { get; set; }
            public string Cognome { get; set; }
            public string Utenza { get; set; }
            public string Passaparola { get; set; }
            public int Profilo { get; set; }
            public bool Attivo { get; set; }
        }
        public class Fornitore : Serializable
        {
            //public int ID { get; set; }
            public string PIva { get; set; }
            public string RagSoc { get; set; }
            public string NumTel { get; set; }
            public string Email { get; set; }
            public string Indirizzo { get; set; }
            public bool Attivo { get; set; }
        }
    }
}
