using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System;



public class Patient
{
    #region Constructeurs
    public Patient()
    { }

    //Ce constructeur permet d'initialiser les propri�t�s de la classe
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

  
    #region Propri�t�s

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

    //Ajouter en lazy load la propri�t� MedicamentsPatient
    //Ajouter en lazy load la propri�t� RendezVousPatient
    #endregion

    #region M�thodes
    
    #endregion
}
