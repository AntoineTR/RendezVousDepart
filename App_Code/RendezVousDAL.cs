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
    //public static List<RendezVous> GetRDVbyID(int pPatientID)
    //{
    //    List<RendezVous> lesRDVS = new List<RendezVous>();
    //    Dictionary<string, Object> dicParametres = new Dictionary<string, Object>();
    //    dicParametres.Add("@IDPatient", pPatientID);
    //    lesRDVS = AccesBD.Current.GetListObject<RendezVous>(

    //        "SELECT        RendezVous.DateDebut, MedicamentRendezVous.IDMedicament as IDMedicament, Medicaments.Description, Docteurs.NomDocteur FROM RendezVous INNER JOIN MedicamentRendezVous ON RendezVous.IDRendezVous = MedicamentRendezVous.IDRendezVous INNER JOIN Medicaments ON MedicamentRendezVous.IDMedicament = Medicaments.IDMedicament INNER JOIN Docteurs ON RendezVous.IDDocteur = Docteurs.IDDocteur WHERE IDPatient = @IDPatient",
    //        dicParametres, CommandType.Text);



    //    return lesRDVS;

    //}
    public static List<RendezVous> GetRDVbyID(int pID)
    {
        return AccesBD.Current.GetListObject<RendezVous>("SELECT Docteurs.NomDocteur, RendezVous.* FROM            RendezVous INNER JOIN Docteurs ON RendezVous.IDDocteur = Docteurs.IDDocteur Where IDPatient = " + pID, null, System.Data.CommandType.Text);
    }
    public static List<RendezVous> Getrdvandname(DateTime dt)
    {
        Dictionary<string, Object> par = new Dictionary<string, Object>();
        par.Add("@DateDebut", dt);

        return AccesBD.Current.GetListObject<RendezVous>( "SELECT * FROM RendezVous r INNER JOIN Docteurs d ON r.IDDocteur = d.IDDocteur WHERE YEAR(DateDebut)=YEAR(@DateDebut) AND MONTH(DateDebut)=MONTH(@DateDebut) AND DAY(DateDebut)=DAY(@DateDebut) ORDER BY r.DateDebut"
            , par, CommandType.Text);
    }
    public static List<RendezVous> GetRDVbyDate(DateTime dt)
    {
        

        Dictionary<string, Object> par = new Dictionary<string, Object>();
        par.Add("@DateDebut", dt);

        return AccesBD.Current.GetListObject<RendezVous>("SELECT * FROM RendezVous WHERE YEAR(DateDebut)=YEAR(@DateDebut) AND MONTH(DateDebut)=MONTH(@DateDebut) AND DAY(DateDebut)=DAY(@DateDebut) ORDER BY DateDebut", par, CommandType.Text);
    }
}