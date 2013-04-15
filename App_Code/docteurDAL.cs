using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Description résumée de docteurDAL
/// </summary>
public class docteurDAL : Docteur
{
	public docteurDAL()
	{
		//
		// TODO: ajoutez ici la logique du constructeur
		//
	}
    public static List<Docteur> GetAllDoc() {
        return AccesBD.Current.GetListObject<Docteur>("Select * from Docteurs", null, CommandType.Text);
    }
}