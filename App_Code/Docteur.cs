using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System;



public class Docteur
{
    #region Constructeurs
    public Docteur()
    { }

    //Ce constructeur permet d'initialiser les propriétés de la classe
    public Docteur(int IDDocteur,
                    string NomDocteur,
                    string PrenomDocteur,
                    int IDSpecialite,
                    string Telephone,
                    string Cellulaire)
              
    {
        this.IDDocteur = IDDocteur;
        this.NomDocteur = NomDocteur.Trim();
        this.PrenomDocteur = PrenomDocteur.Trim();
        this.IDSpecialite = IDSpecialite;
        this.Telephone = Telephone.Trim();
        this.Cellulaire = Cellulaire.Trim();
    }

    ////Ce constructeur permet d'intialiser les propriétés de la classe avec un Datarow
    //public Docteur(DataRow dr)
    //{

    //    this.IDDocteur = int.Parse(dr["IDDocteur"].ToString());
    //    this.NomDocteur = dr["NomDocteur"].ToString();
    //    this.PrenomDocteur = dr["PrenomDocteur"].ToString();
    //    this.Specialite = dr["Specialite"].ToString();
    //    this.Telephone = dr["Telephone"].ToString();
    //    this.Cellulaire = dr["Cellulaire"].ToString();

        
    //}
    #endregion

    #region Propriétés

    public int IDDocteur
    {
        get;
        set;
    }
    public string NomDocteur
    {
        get;
        set;
    }
    public string PrenomDocteur
    {
        get;
        set;
    }
    public int IDSpecialite
    {
        get;
        set;
    }
    public string Telephone
    {
        get;
        set;
    }
    public string Cellulaire
    {
        get;
        set;
    }

    //Ajouter en lazy load une propriété pour obtenir les patients d'un docteur
   

    


    #endregion

    #region Méthodes
    
    #endregion
}
