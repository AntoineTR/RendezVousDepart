using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Description résumée de PatientDAL
/// </summary>
public class PatientDAL : Patient
{
	public PatientDAL() 
	{
		//
		// TODO: ajoutez ici la logique du constructeur
		//
	}
    public static DataTable GetDTAllPatients()
    {
        return AccesBD.Current.GetDataTable("Select * From Patient", null, CommandType.Text);


    }
    public static int ModifierPatient(Patient pPatient)
    {
        Dictionary<string, Object> dicParametres = new Dictionary<string, Object>();
        dicParametres = AccesBD.Current.CreateParameter(pPatient);

        return AccesBD.Current.ExecuteNonQuery("Update Patient Set TelephonePatient = @TelephonePatient  Where IDPatient = @IDPatient", dicParametres, CommandType.Text);

    }

}