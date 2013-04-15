using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System;



public class RendezVous
{
    #region Constructeurs
    public RendezVous()
    { }

    //Ce constructeur permet d'initialiser les propri�t�s de la classe
    public RendezVous(   int IDRendezVous,
                         int IDDocteur,
                         string NomDocteur,
                         int IDPatient,
                         DateTime DateDebut,
                         DateTime DateFin)
    {
        this.IDRendezVous=IDRendezVous;
        this.NomDocteur = NomDocteur;
        this.IDDocteur=IDDocteur;
        this.IDPatient=IDPatient;
        this.DateDebut=DateDebut;
        this.DateFin=DateFin;
    }

   
    #endregion

    #region Propri�t�s
    public int IDRendezVous
    {
        get;
        set;
    }
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
    public int IDPatient
    {
        get;
        set;
    }
    public DateTime DateDebut
    {
        get;
        set;
    }
    public DateTime DateFin
    {
        get;
        set;
    }

    //Ajouter une propri�t�s en lazy load pour obtenir la liste des m�dicaments pr�scrits lors d'un rendez-vous
    private List<Medicament> MedRDV;
    public List<Medicament> MedicamentsRDV
    {
        get
        {
            if (MedRDV == null)
                MedRDV = MedicamentDAL.GetMedByRDV(IDRendezVous);

            return MedRDV;
        }
        set
        {
            MedRDV = value;
        }
    }


   
#endregion

    #region M�thodes

    #endregion
}
