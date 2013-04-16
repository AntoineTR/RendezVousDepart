using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Description résumée de SpecialiteDAL
/// </summary>
public class SpecialiteDAL : Specialite
{
	public SpecialiteDAL()
	{
		//
		// TODO: ajoutez ici la logique du constructeur
		//
	}
    public static List<Specialite> GetAllSpec()
    {
        return AccesBD.Current.GetListObject<Specialite>("Select * from Specialite", null, CommandType.Text);
    }
    public static Specialite GetSpecbyID(int pID)
    {
        return AccesBD.Current.GetObject<Specialite>("Select * from Specialite Where IDSpecialite = " + pID, null, CommandType.Text,new Specialite());
    }
}