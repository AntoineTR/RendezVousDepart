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
            "SELECT RendezVous.IDRendezVous, Medicaments.NomMedicament, Medicaments.Description FROM MedicamentRendezVous INNER JOIN Medicaments ON MedicamentRendezVous.IDMedicament = Medicaments.IDMedicament INNER JOIN RendezVous ON MedicamentRendezVous.IDRendezVous = RendezVous.IDRendezVous",
            dicParametres, CommandType.Text);
    }
}