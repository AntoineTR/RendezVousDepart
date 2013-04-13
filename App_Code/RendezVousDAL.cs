using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Description résumée de RendezVousDAL
/// </summary>
public class RendezVousDAL
{
	public RendezVousDAL()
	{
		
	}
    public static List<RendezVous> GetRDVbyID(int pPatientID) { 
    List<RendezVous> lesRDVS = new List<RendezVous>();
    Dictionary<string, Object> dicParametres = new Dictionary<string, Object>();
    dicParametres.Add("@IDPatient", pPatientID);
    lesRDVS = AccesBD.Current.GetListObject<RendezVous>(
        "Select d.NomDocteur, r.DateDebut, m.NomMedicament as NomMedicament FROM RendezVous r INNER JOIN Docteurs d ON r.IDDocteur = d.IDDocteur INNER JOIN MedicamentRendezVous mr ON mr.IDRendezVous = r.IDRendezVous JOIN Medicaments m ON m.IDMedicament = mr.IDMedicament  WHERE IDPatient = @IDPatient",
        
        dicParametres, CommandType.Text);

   

    return lesRDVS;
    
    }
}