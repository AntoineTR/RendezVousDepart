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
        return AccesBD.Current.GetListObject<Docteur>("SELECT * " +
                     "FROM Docteurs d " +
                     "ORDER BY d.NomDocteur, d.PrenomDocteur"
            , null, CommandType.Text);
    }
    public static int Update(Docteur doc)
    {
        Dictionary<string, Object> dicParam = new Dictionary<string, Object>();
        dicParam.Add("@IDDocteur", doc.IDDocteur);
        dicParam.Add("@NomDocteur", doc.NomDocteur);
        dicParam.Add("@PrenomDocteur", doc.PrenomDocteur);
        dicParam.Add("@Telephone", doc.Telephone);
        dicParam.Add("@Cellulaire", doc.Cellulaire);
        dicParam.Add("@IDSpecialite", doc.IDSpecialite);

        return AccesBD.Current.ExecuteNonQuery("UPDATE Docteurs SET NomDocteur=@NomDocteur, PrenomDocteur=@PrenomDocteur, Telephone=@Telephone, Cellulaire=@Cellulaire, IDSpecialite=@IDSpecialite WHERE IDDocteur=@IDDocteur",
            dicParam, CommandType.Text);
    }
}