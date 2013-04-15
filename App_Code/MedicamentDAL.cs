using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Description résumée de MedicamentDAL
/// </summary>
public class MedicamentDAL
{
	public MedicamentDAL()
	{
		//
		// TODO: ajoutez ici la logique du constructeur
		//
	}
    public static List<Medicament> GetMedByRDV(int IDRendezVous){
    Dictionary<string, Object> dicParametres = new Dictionary<string, Object>();
        dicParametres.Add("@IDRendezVous",IDRendezVous);
        return AccesBD.Current.GetListObject<Medicament>(
            "SELECT RendezVous.IDRendezVous, Medicaments.NomMedicament, Medicaments.Description FROM MedicamentRendezVous INNER JOIN Medicaments ON MedicamentRendezVous.IDMedicament = Medicaments.IDMedicament INNER JOIN RendezVous ON MedicamentRendezVous.IDRendezVous = RendezVous.IDRendezVous Where RendezVous.IDRendezVous=@IDRendezVous",
            dicParametres, CommandType.Text);
    }
    public static List<Medicament> getMedicamentPatient(int pID)
    {
        return AccesBD.Current.GetListObject<Medicament>("Select * From Medicaments Where IDMedicament in ( Select IDMedicament  From MedicamentRendezVous where IDRendezVous in (Select IDRendezVous From  RendezVous WHERE IDPatient = " + pID + "))", null, System.Data.CommandType.Text);
    }
    public static Medicament getMedbyNAME(string pName)
    {
        String sql = "Select * From Medicaments Where NomMedicament=@NomMedicament";
        Dictionary<string, Object> dicParametres = new Dictionary<string, Object>();
        dicParametres.Add("@NomMedicament", pName);
        return AccesBD.Current.GetObject(sql, dicParametres, CommandType.Text, new Medicament());
        
    }
}