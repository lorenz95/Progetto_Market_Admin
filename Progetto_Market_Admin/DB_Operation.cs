using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using static Progetto_Market_Admin.ResponseModel;
using static Progetto_Market_Admin.Modelli;

namespace Progetto_Market_Admin
{
    class DB_Operation
    {
        private static readonly string BASE_DIRECTORY_DATABASE = AppDomain.CurrentDomain.BaseDirectory + @"\DataBase\";
        private static readonly string pathProfili = BASE_DIRECTORY_DATABASE + "Profili.json";
        private static readonly string pathUtenti = BASE_DIRECTORY_DATABASE + "Utenti.json";
        private static readonly string pathFornitori = BASE_DIRECTORY_DATABASE + "Fornitori.json";

        #region Profili
        public static Response_Profili GetListaProfili()
        {
            Response_Profili responseProfili = new Response_Profili();
            try
            {
                if (File.Exists(pathProfili))
                {
                    string infoListaProfili = File.ReadAllText(pathProfili);
                    responseProfili.ListaProfili = JsonConvert.DeserializeObject<List<Profilo>>(infoListaProfili);
                    responseProfili.Errore = string.Empty;
                }
                else
                {
                    responseProfili.ListaProfili = null;
                    responseProfili.Errore = "Non esiste nesun profilo....";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(string.Format("Errore : {0}\n{1}", ex.Message, ex.StackTrace), "Lettura Profili", MessageBoxButtons.OK, MessageBoxIcon.Information);
                responseProfili.ListaProfili = new List<Profilo>();
                responseProfili.Errore = "Errore : \n" + ex.Message + "\n" + ex.Message;
            }
            return responseProfili;
        }

        public static void CreateProfilo(Profilo profilo, out string info)
        {
            info = string.Empty;
            try
            {
                if (File.Exists(pathProfili))
                {
                    string infoListaProfili = File.ReadAllText(pathProfili);
                    var letturaFile = JsonConvert.DeserializeObject<List<Profilo>>(infoListaProfili);

                    //Controllo se il profilo da inserire , esiste gia'
                    var exist = letturaFile.Exists(lf=>lf.Tipo.ToLower() == profilo.Tipo.ToLower());
                    if (exist)
                    {
                        info = string.Format("Il profilo con tipo : {0} esiste gia registrato...", profilo.Tipo);
                    } else {
                        letturaFile.Add(profilo);

                        using (StreamWriter sw = new StreamWriter(pathProfili, false))
                        {
                            sw.WriteLine(JsonConvert.SerializeObject(letturaFile));
                            sw.Close();
                        }
                    }                  
                } else {
                    if (!Directory.Exists(BASE_DIRECTORY_DATABASE))
                    {
                        Directory.CreateDirectory(BASE_DIRECTORY_DATABASE);
                    }
                    File.Create(pathProfili); //.Close();
                    List<Profilo> listaProfili = new List<Profilo>
                    {
                        profilo
                    };
                    using (StreamWriter sw = new StreamWriter(pathProfili, false))
                    {
                        sw.WriteLine(JsonConvert.SerializeObject(listaProfili));
                        sw.Close();
                    }
                }
            } catch (Exception ex) {
                info = "Errore : \n" + ex.Message +"\n"+ ex.StackTrace;
            }
        }

        public static void ModificaProfilo(Profilo profilo, out string info)
        {
            info = string.Empty;
            try
            {
                string infoListaProfili = File.ReadAllText(pathProfili);
                var letturaFile = JsonConvert.DeserializeObject<List<Profilo>>(infoListaProfili);

                //Controllo se il profilo da inserire , esiste gia'
                var exist = letturaFile.Exists(lf => lf.Tipo.ToLower() == profilo.Tipo.ToLower() && lf.ID != profilo.ID);

                if (exist)
                {
                    info = string.Format("Il profilo con tipo : {0} esiste gia registrato...", profilo.Tipo);
                } else {
                    var myProfil = letturaFile.FirstOrDefault(p=>p.ID == profilo.ID);
                    myProfil.Tipo = profilo.Tipo;
                    myProfil.Descrizione = profilo.Descrizione;

                    using (StreamWriter sw = new StreamWriter(pathProfili, false))
                    {
                        sw.WriteLine(JsonConvert.SerializeObject(letturaFile));
                        sw.Close();
                    }
                }
            } catch (Exception ex) {
                info = "Errore : \n" + ex.Message + "\n" + ex.StackTrace;
            }
        }

        public static void EliminazioneProfilo(Profilo profilo, out string info)
        {
            info = string.Empty;
            try
            {
                string infoListaProfili = File.ReadAllText(pathProfili);
                var letturaFile = JsonConvert.DeserializeObject<List<Profilo>>(infoListaProfili);

                letturaFile.RemoveAll(pr=>pr.ID == profilo.ID);

                var ooooo = letturaFile;

                using (StreamWriter sw = new StreamWriter(pathProfili, false))
                {
                    sw.WriteLine(JsonConvert.SerializeObject(letturaFile));
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                info = "Errore : \n" + ex.Message + "\n" + ex.StackTrace;
            }
        }        
        #endregion

        #region Utenti
        public static Response_User GetListaUtenti()
        {
            Response_User responseProfili = new Response_User();
            try
            {
                if (File.Exists(pathUtenti))
                {
                    string infoListaUtenti = File.ReadAllText(pathUtenti);
                    responseProfili.ListaUtenti = JsonConvert.DeserializeObject<List<Utente>>(infoListaUtenti);
                    responseProfili.Errore = string.Empty;
                }
                else
                {
                    responseProfili.ListaUtenti = null;
                    responseProfili.Errore = "Non esiste nesun utente....";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(string.Format("Errore : {0}\n{1}", ex.Message, ex.StackTrace), "Lettura Profili", MessageBoxButtons.OK, MessageBoxIcon.Information);
                responseProfili.ListaUtenti = new List<Utente>();
                responseProfili.Errore = "Errore : \n" + ex.Message + "\n" + ex.Message;
            }
            return responseProfili;
        }

        public static void CreateUser(Utente utente, out string info)
        {
            info = string.Empty;
            try
            {
                if (File.Exists(pathUtenti))
                {
                    string infoListaUtente = File.ReadAllText(pathUtenti);
                    var letturaFile = JsonConvert.DeserializeObject<List<Utente>>(infoListaUtente);

                    //Controllo se il profilo da inserire , esiste gia'
                    var exist = letturaFile.Exists(lf => lf.Utenza.ToLower() == utente.Utenza.ToLower());

                    if (exist)
                    {
                        info = string.Format("Il utente con utenza : {0} esiste gia registrato...", utente.Utenza);
                    } else {
                        letturaFile.Add(utente);
                        using (StreamWriter sw = new StreamWriter(pathUtenti, false))
                        {
                            sw.WriteLine(JsonConvert.SerializeObject(letturaFile));
                            sw.Close();
                        }
                    }
                } else {
                    File.Create(pathUtenti).Close();
                    List<Utente> listaUtenti = new List<Utente>
                    {
                        utente
                    };
                    using (StreamWriter sw = new StreamWriter(pathUtenti, false))
                    {
                        sw.WriteLine(JsonConvert.SerializeObject(listaUtenti));
                        sw.Close();
                    }
                }
            } catch (Exception ex) {
                info = "Errore : \n" + ex.Message + "\n" + ex.StackTrace;
            }
        }
        #endregion 
        
        #region Fornitori
        public static Response_Fornitori GetListaFornitori()
        {
            Response_Fornitori responseFornitori = new Response_Fornitori();
            try
            {
                if (File.Exists(pathFornitori))
                {
                    string infoListaFornitori = File.ReadAllText(pathFornitori);
                    responseFornitori.ListaFornitori = JsonConvert.DeserializeObject<List<Fornitore>>(infoListaFornitori);
                    responseFornitori.Errore = string.Empty;
                }
                else
                {
                    responseFornitori.ListaFornitori = null;
                    responseFornitori.Errore = "Non esiste nesun fornitore....";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(string.Format("Errore : {0}\n{1}", ex.Message, ex.StackTrace), "Lettura Profili", MessageBoxButtons.OK, MessageBoxIcon.Information);
                responseFornitori.ListaFornitori = new List<Fornitore>();
                responseFornitori.Errore = "Errore : \n" + ex.Message + "\n" + ex.Message;
            }
            return responseFornitori;
        }

        public static void CreateFornitore(Fornitore fornitore, out string info)
        {
            info = string.Empty;
            try {
                if (File.Exists(pathFornitori))
                {
                    string infoListaFornitori = File.ReadAllText(pathFornitori);
                    var letturaFile = JsonConvert.DeserializeObject<List<Fornitore>>(infoListaFornitori);

                    //Controllo se il profilo da inserire , esiste gia'
                    var exist = letturaFile.Exists(lf => lf.PIva.ToLower() == fornitore.PIva.ToLower());

                    if (exist)
                    {
                        info = string.Format("Il fornitore con P.IVA : {0} esiste gia registrato...", fornitore.PIva);
                    } else {
                        letturaFile.Add(fornitore);

                        using (StreamWriter sw = new StreamWriter(pathFornitori, false))
                        {
                            sw.WriteLine(JsonConvert.SerializeObject(letturaFile));
                            sw.Close();
                        }
                    }
                }
                else {
                    //File.Create(pathFornitori).Close();
                    File.Create(pathFornitori);
                    List<Fornitore> listaFornitori = new List<Fornitore>
                    {
                        fornitore
                    };
                    using (StreamWriter sw = new StreamWriter(pathFornitori, false))
                    {
                        sw.WriteLine(JsonConvert.SerializeObject(listaFornitori));
                        sw.Close();
                    }
                }
            }
            catch (Exception ex) { info = "Errore : \n" + ex.Message + "\n" + ex.StackTrace; }
        }
        #endregion
        
        public static int GetLastIdUtente()
        {
            //int Id = 0;
            //if (File.Exists(pathUtenti))
            //{
            //    string infoListaUtenti = File.ReadAllText(pathUtenti);
            //    List<Utente> lista = JsonConvert.DeserializeObject<List<Utente>>(infoListaUtenti);
            //    Id = lista.Max(l => l.ID + 1);
            //}
            //return Id+1;
            return GetId(pathUtenti);
        }

        public static int GetLastIdFornitore()
        {
            //int Id = 0;
            //if (File.Exists(pathFornitori))
            //{
            //    string infoListaFornitori = File.ReadAllText(pathFornitori);
            //    List<Fornitore> lista = JsonConvert.DeserializeObject<List<Fornitore>>(infoListaFornitori);
            //    Id = lista.Max(l => l.ID + 1);
            //}
            //return Id + 1;
            return GetId(pathFornitori);

        }

        public static int GetLastIdProfili()
        {
            //int Id = 0;
            //if (File.Exists(pathProfili))
            //{
            //    string infoListaProfili = File.ReadAllText(pathProfili);
            //    List<Profilo> lista = JsonConvert.DeserializeObject<List<Profilo>>(infoListaProfili);
            //    Id = lista.Max(l => l.ID + 1);
            //}
            //return Id + 1;
            return GetId(pathProfili); 
        }

        private static int GetId(string path) {
            int id = 0;
            if (File.Exists(path))
            {   
                string info = File.ReadAllText(path);
                if (path == pathFornitori) {
                    List<Fornitore> listaFornitori = JsonConvert.DeserializeObject<List<Fornitore>>(info);
                    id = listaFornitori.Max(l => l.ID + 1);
                }
                else if (path == pathUtenti)
                {
                    List<Utente> listaUtenti = JsonConvert.DeserializeObject<List<Utente>>(info);
                    id = listaUtenti.Max(l => l.ID + 1);
                }
                else if (path == pathProfili)
                {
                    List<Profilo> listaProfili = JsonConvert.DeserializeObject<List<Profilo>>(info);
                    id = listaProfili.Max(l => l.ID + 1);
                }
            }
            return id+1;
        }        
    }
}
