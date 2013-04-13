using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using System.Text;
using System.Data.Common;
using System.Linq;
/// <summary>
/// Classe d'accés aux données
/// Une seule instance est crée
/// La connexion est ouverte et fermée après chaque execution de commande. pour le mode deconnecté (DataSet) c'est fait par défaut
/// Possibilité de nommer le DataTable (utile pour XML)
/// Même methode pour requete (ou procédure stockée)avec ou sans paramétres . Mettre null lorsque sans paramètre
/// les parametres  pour requete ou procedure stockées sont donnés sous le type (Dictionary<string, Object>) modifié en List<SqlParameter>
/// </summary>
/// 
public class AccesBD
{
#region Propriétés Privées
    private SqlConnection m_connection = new SqlConnection();
 #endregion

#region Propriétés Publiques

        /// <summary>
        ///  chaine de connexion et 
        /// connection
        /// </summary>
        /// 
    public string ConnectionString
    {
        get { return Connection.ConnectionString; }
        set { Connection.ConnectionString = value; }
    }
    public SqlConnection Connection
    {

        get { return m_connection; }
        set
        {
            m_connection = value;
            //if (m_connection.State == ConnectionState.Closed)
            //    m_connection.Open();
        }
    }
        
 #endregion

#region Constructeur (Pattern Singleton)

        private static AccesBD instance;

        /// <summary>
        /// Constructeur static
        /// </summary>
        /// 
        static AccesBD()
        {
            instance = new AccesBD();
            if (instance.ConnectionString == string.Empty)
            {
                //prendre la string dans le Web.config ou le App.config tenir compte de la connexion par defaut de asp.net
                //la connectionString doit porter obligatoirement le nom defaut
                instance.ConnectionString = ConfigurationManager.ConnectionStrings["defaut"].ConnectionString;
                instance.Connection.Open();

            }
        }
       
        /// <summary>
        /// Retour de l'instance en cours
        /// </summary>
        /// <returns></returns>
        public static AccesBD Current
        {
            get
            {        
               return instance;
            }
        }

        #endregion

#region Création d'un SqlCommand 

        /// <summary>
        /// Créer un objet Command
        /// </summary>
        public SqlCommand CreateSqlCommand(String pcommandText, CommandType pcommandType, Dictionary<string, Object> pDictionnaire)
        {
            SqlCommand command = new SqlCommand();
           try
           {
               if (Connection.State != System.Data.ConnectionState.Closed) Connection.Close();
                command.CommandType = pcommandType;
                command.CommandText = pcommandText;
                command.Connection = Connection;
                this.AjouterParametreCommand(command, pDictionnaire);
               
            }
            catch(Exception e)
            {
                Console.Write(e.Message + "\n" + e.Source);
            }
            return command;
        }

#endregion

#region Ajout des paramètres  à une commande
        /// <summary>
        /// Ajouter les paramètres à la commande
        /// </summary>
        /// <param name="pcommand">Commande sql à laquelle on ajoute les paramètres</param>
        /// <param name="pparameters">Dictionnaire de paramètres</param>
        private void AjouterParametreCommand(SqlCommand pCommand, Dictionary<string, Object> pDictionnaire)
        {
            if (pDictionnaire != null)
            {
                SqlParameter param;
                foreach (KeyValuePair<string, Object> key in pDictionnaire)
                {
                    param = new SqlParameter();

                    //Assigner le nom et la valeur au paramètre
                    param.ParameterName = key.Key;
                    param.Value = key.Value;

                    //Si la valeur est null, on la remplace par le null de la BD
                    if (param.Value == null )
                        param.Value = DBNull.Value;

                    //Ajouter le paramètre à la commande SQL
                    pCommand.Parameters.Add(param);
                }

            }
        }
        #endregion

#region Récupération DataReader:ExecuteReader

        /// <summary>
        /// Récupère un jeu d'enregistrement d'une base de donnée depuis une requête ou procédure stockée avec ou sans paramétres
        /// </summary>
        public SqlDataReader GetReader(string pcommandText, Dictionary<string, Object> pparameters, CommandType ptypeCommande)
        {   
            SqlDataReader drdDataReader = null;
            try
            {
                SqlCommand command = CreateSqlCommand(pcommandText,  ptypeCommande, pparameters);
                Connection.Open();
                //la connexion après l'execution
                drdDataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
               


            }
            catch(Exception exc)
            {//le message s'écrit dans le cas projet C#
                
                Console.Write(exc.Message + "\n" + exc.Source);
            }
            finally
            {
               // if (Connection.State != System.Data.ConnectionState.Closed) Connection.Close();
            }
            // Retour du dataReader;

            return drdDataReader;
     }

    //**************************************

       

    //**************************
        //public T GetObject<T>(string pcommandText, Dictionary<string, Object> pparameters, CommandType ptypeCommande, T myClass) where T : new()
        //{
        //    return CreateObject(GetReader(pcommandText, pparameters, ptypeCommande), myClass);

        //}
#endregion 
        
#region Exécution d'un ordre qui ne renvoit que le nbre de lignes affectées :ExecuteNonQuery

             /// <summary>
        /// Exécute requête uo procédure stockée avec ou sans paramétres et renvoit le nombre de lignes affectées
        /// </summary>
        public int ExecuteNonQuery(String pcommandText, Dictionary<string, Object> pparameters, CommandType ptypeCommande)
    {
        int rowAffecte = 0;
        try
        {
            
            SqlCommand command = this.CreateSqlCommand(pcommandText, ptypeCommande, pparameters);
            Connection.Open();
            rowAffecte = command.ExecuteNonQuery();
        }
        catch (Exception exc)
        {
            Console.Write(exc.Message + "\n" + exc.Source);
        }
        finally
        {
            if (Connection.State != System.Data.ConnectionState.Closed) Connection.Close();
        }
        // Retour du résultat;
        return rowAffecte;

    }
#endregion

#region Exécution d'un Ordre qui renvoit une seule valeur:ExecuteScalar

    /// <summary>
        /// Exécute Exécute une requête ou procédure stockée avec ou sans paramétres et renvoit une valeur (objet)
        /// </summary>
        public Object ExecuteScalar(String pcommandText, Dictionary<string, Object> pparameters, CommandType ptypeCommande)
    {
        Object resultat = null;
       
        try
        {
            
            SqlCommand command = this.CreateSqlCommand(pcommandText,ptypeCommande, pparameters);
            Connection.Open();
            resultat = command.ExecuteScalar();
        }
        catch (Exception exc)
        { 
            Console.Write(exc.Message + "\n" + exc.Source);
        }
        finally
        {
            if (Connection.State != System.Data.ConnectionState.Closed) Connection.Close();
        }
        // Retour du résultat;
        return resultat;
    }
#endregion

#region Récupération d'un DataSet
    /// <summary>
    /// 
    /// Retourne un dataset résultat de la commande exécutée avec ou sans paramétres
    /// la fermeture de la connexion est gérée par le DataAdapter
    /// </summary>
    /// <returns>Dataset résultat de la commande</returns>
        public DataSet GetDataSet(string pcommandeText, Dictionary<string, Object> pparameters, CommandType ptypeCommande)
    {
        DataSet dsResultat = new DataSet();
        SqlDataAdapter daResultat = null;
        SqlCommand commande = this.CreateSqlCommand(pcommandeText, ptypeCommande, pparameters);
        try
        {
            daResultat = new SqlDataAdapter();
            daResultat.SelectCommand = commande;
            daResultat.Fill(dsResultat);
        }
        catch (Exception e)
        {
            Console.Write(e.Message + "\n" + e.Source);
            throw e;
        }
        
        return dsResultat;
    }
    /// <summary>
    /// Retourne un dataset résultat de la commande exécutée avec une table nommée
    /// <returns>Dataset résultat de la commande</returns>
    /// </summary>

        public DataSet GetDataSet(string pcommandeText, Dictionary<string, Object> pparameters, CommandType ptypeCommande, string nomTable)
    {
        DataSet dsResultat = new DataSet();
        SqlDataAdapter daResultat = new SqlDataAdapter();
        SqlCommand commande = this.CreateSqlCommand(pcommandeText, ptypeCommande, pparameters);

        try
        {
            daResultat.SelectCommand = commande;
            daResultat.Fill(dsResultat, nomTable);
        }
        catch (Exception e)
        {
            throw e;
        }
        return dsResultat;
    }
    #endregion

#region Récupération d'un DataTable
    /// <summary>
    /// Retourne une table résultat de la commande exécutée
    /// </summary>
    /// <returns>La table nommée correspondant au résultat de la commande exécutée</returns>
        public DataTable GetDataTable(string pcommandeText, Dictionary<string, Object> pparameters, CommandType ptypeCommande, string nomTable)
    {
        DataSet dsResultat = null;
        try
        {
            dsResultat = this.GetDataSet(pcommandeText, pparameters, ptypeCommande, nomTable);
        }
        catch (Exception e)
        {
            throw e;
        }

        if (dsResultat.Tables.Count == 0 || dsResultat.Tables[0].Rows.Count == 0)
            return null;
        return dsResultat.Tables[nomTable];
    }

    /// <summary>
    /// Retourne une table résultat de la commande exécutée sans nom pour la table
    /// </summary>
    /// <returns>La table correspondant au résultat de la commande exécutée</returns>
        public DataTable GetDataTable(string pcommandeText, Dictionary<string, Object> pparameters, CommandType ptypeCommande)
        {
            DataSet dsResultat = null;
        try
        {
            dsResultat = this.GetDataSet(pcommandeText, pparameters, ptypeCommande);
        }
        catch (Exception e)
        {
            throw e;
        }

        if (dsResultat.Tables.Count == 0 || dsResultat.Tables[0].Rows.Count == 0)
            return null;
        return dsResultat.Tables[0];
    }

        //public List<T> GetListObject<T>(string pcommandeText, Dictionary<string, Object> pparameters, CommandType ptypeCommande, T myClass)
        //{
        //    return CreateListObject<T>(GetDataTable(pcommandeText, pparameters, ptypeCommande));
        //}
   
    #endregion

#region Récupération d'un DataRow
    /// <summary>
    /// Retourne la première ligne DataRow résultat de la commande exécutée
    /// </summary>
    /// <returns>Retourne la première ligne résultat de la commande exécutée</returns>
        public DataRow GetDataRow(string pcommandeText, Dictionary<string, Object> pparameters, CommandType ptypeCommande)
    {
        DataSet dsResultat = null;
        try
        {
            dsResultat = this.GetDataSet(pcommandeText, pparameters, ptypeCommande);
        }
        catch (Exception e)
        {
            throw e;
        }

        if (dsResultat.Tables.Count == 0 || dsResultat.Tables[0].Rows.Count == 0)
            return null;
        return (dsResultat.Tables[0].Rows[0]);
    }

 #endregion

#region Récuperation d'un objet de Type T
        
        /// <summary>
        /// construit un DataRow et retourne un objet de type T
        /// </summary>
        /// <returns>un objet de type T</returns>


        public T GetObject<T>(string pcommandeText, Dictionary<string, Object> pparameters, CommandType ptypeCommande, T myClass) where T : new()
        {

            return CreateObject<T>(GetDataRow(pcommandeText, pparameters, ptypeCommande), myClass);
        }

 #endregion

#region Récupération d'une List<T>
    /// <summary>
    /// Construit une list d'objet de type T. La liste est construite à partir d'un SqlDataReader
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="pcommandeText"></param>
    /// <param name="pparameters"></param>
    /// <param name="ptypeCommande"></param>
    /// <returns></returns>

        public List<T> GetListObject<T>(string pcommandeText, Dictionary<string, Object> pparameters, CommandType ptypeCommande) where T : new()
        {
            T myClass = new T();
            return CreateListObject<T>(GetReader(pcommandeText, pparameters, ptypeCommande), myClass);
        }
        #endregion

#region utilitaires
     
    /// <summary>
    /// Créer un objet de type T à partir d'un SqlDataReader (en utilisant le 1ier record)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="record"></param>
    /// <param name="myClass"></param>
    /// <returns></returns>
    protected static T CreateObject<T>(SqlDataReader record, T myClass)
        {
            PropertyInfo[] propertyInfos = typeof(T).GetProperties();
            if (!record.IsClosed && record != null)
                for (int i = 0; i < record.FieldCount; i++)
                {
                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        if (propertyInfo.Name == record.GetName(i))
                        {
                            propertyInfo.SetValue(myClass, ChangeMonType(record.GetValue(i), propertyInfo.PropertyType), null);
                            break;
                        }
                    }
                }
            return myClass;
        }


        //2ième surcharge
    /// <summary>
    /// Créer un objet de type T à partir d'un DataRow 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="record"></param>
    /// <param name="myClass"></param>
    /// <returns></returns>
    protected static T CreateObject<T>(DataRow row, T myClass)
        {
            PropertyInfo[] propertyInfos = typeof(T).GetProperties();
            if (row != null)
                for (int i = 0; i < row.Table.Columns.Count; i++)
                {
                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        if (propertyInfo.Name == row.Table.Columns[i].ColumnName)
                        {
                            
                            propertyInfo.SetValue(myClass, ChangeMonType(row[i], propertyInfo.PropertyType), null);
                            break;
                        }
                    }
                } 
        return myClass;

        }



        //retourne un objet correspondant  la valeur d'un champs . Tient compte des valeur null obtenues de la BD
    protected static object ChangeMonType(object value, Type conversionType)
        {

            //try
            {//tester si c'est un type Nullable
                if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition() == typeof(Nullable<>))

                //if (conversionType.Name == "Nullable`1") //bizare mais c'est ça le name d'un type nullable ???      ce test ne fonctionne pas   .Equals(typeof(Nullable))) 
                {
                    if (value == DBNull.Value) return null;

                    conversionType = Nullable.GetUnderlyingType(conversionType);
                }
                return Convert.ChangeType(value, conversionType);
            }
            //catch (InvalidCastException ex)
            //{
            //    Console.Write(ex.Message + "\n" + ex.Source);
            //    return null;
                
            //}
        }

    /// <summary>
        ///  Crée une list d'objet de type T à partir d'un SqlDataReader
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="pSqldataReader"></param>
    /// <param name="myClass"></param>
    /// <returns></returns>

    protected static List<T> CreateListObject<T>(SqlDataReader pSqldataReader, T myClass) where T : new()
        {
            List<T> lstObjet = new List<T>();
            if (pSqldataReader != null)
                while (!pSqldataReader.IsClosed && pSqldataReader.Read())
                {
                   T objRetourne= new T();


                    lstObjet.Add(CreateObject(pSqldataReader, objRetourne));
                }

            return lstObjet;
        }

    /// <summary>
    /// Crée une list d'objet de type T à partir d'un DataTable
    /// </summary>
    /// <typeparam name="T"> type généric</typeparam>
    /// <param name="dtb"> un DataTable</param>
    /// <returns></returns>

    protected static List<T> CreateListObject<T>(DataTable dtb, T myClass) where T : new()
        {
            List<T> lstObjet = new List<T>();
            foreach (DataRow row in dtb.Rows)
            {
                //T objRetourne = default(T);

                lstObjet.Add(CreateObject(row, myClass));
            }

            return lstObjet;
        }

    /// <summary>
    /// créer un dictionnaire correspondant aux paramètres d'une requête
    /// PEUT ÊTRE UTILISÉE pour Insert et UpDate (Pas assez testée)
    /// </summary>
    /// <param name="myClass"></param>
    /// <returns></returns>
        public  Dictionary<string, Object> CreateParameter(Object myClass)
        {
            Dictionary<string, Object> dicParam = new Dictionary<string, object>();
            PropertyInfo[] propertyInfos = myClass.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
                dicParam.Add("@" + propertyInfo.Name, propertyInfo.GetValue(myClass, null));


            return dicParam;
        }

        #endregion

}


 


    
