using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System;



public class Specialite
{
    #region Constructeurs
    public Specialite()
    { }
    public Specialite(int IDSpecialite, string nomSpecialite)
    {
        this.IDSpecialite = IDSpecialite;
        this.NomSpecialite = nomSpecialite; 
    }

    #endregion

    #region Propriétés

    public int IDSpecialite
    {
        get;
        set;
    }

    public string NomSpecialite
    {
        get;
        set;
    }
    #endregion

    #region Méthodes
    
    #endregion
}
