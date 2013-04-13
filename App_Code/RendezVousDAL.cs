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
    public static List<RendezVous> GetRDVbyID() { 
    List<RendezVous> lesRDVS = new List<RendezVous>();

    lesRDVS = AccesBD.Current.GetListObject<RendezVous>("Select CategoryID, CategoryName, Description From Categories", null, CommandType.Text);


    return lesRDVS;
    
    }
}