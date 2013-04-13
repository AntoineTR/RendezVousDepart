using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System;



public class Patient
{
    #region Constructeurs
    public Patient()
    { }

    //Ce constructeur permet d'initialiser les propriétés de la classe
    public Patient(int IDPatient,
                    string NomPatient,
                    string PrenomPatient,
                    string TelephonePatient)              
    {
        this.IDPatient = IDPatient;
        this.NomPatient = NomPatient.Trim();
        this.PrenomPatient = PrenomPatient.Trim();
        this.TelephonePatient= TelephonePatient.Trim();
    }

    #endregion

  
    #region Propriétés

    public int IDPatient
    {
        get;
        set;
    }
    public string NomPatient
    {
        get;
        set;
    }
    public string PrenomPatient
    {
        get;
        set;
    }
    public string TelephonePatient
    {
        get;
        set;
    }

    //Ajouter en lazy load la propriété MedicamentsPatient
    //Ajouter en lazy load la propriété RendezVousPatient
    #endregion

    #region Méthodes
    
    #endregion
}
