using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Medicament
/// </summary>
public class Medicament
{
    #region Constructeurs
    
   
	public Medicament()
	{  }
    public Medicament(int pIDMedicament,string pNomMedicament,string pDescription)
    {
        IDMedicament = pIDMedicament;
        NomMedicament = pNomMedicament;
        Description = pDescription;
    }

    #endregion

    #region Propriétés
    public int IDMedicament 
    {  
        get;
        set;
    }
     public string NomMedicament 
    {  
        get;
        set;
    }
    public string Description
    {  
        get;
        set;
    }
    #endregion


    #region Méthodes
    
    #endregion
}