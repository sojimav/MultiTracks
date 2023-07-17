using DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class PageToSync_artistDetails : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		string artistID = Request.QueryString["id"];
		// Create an instance of your database helper class or access the existing instance
		SQL dbHelper = new SQL("admin");
		dbHelper.OpenConnection();

		// Call the necessary methods to retrieve data using the SQL object
		DataTable artistData = dbHelper.ExecuteStoredProcedureDT("dbo.GetArtistDetails", true);
		
		dbHelper.CloseConnection();
		List<dynamic> artistList = artistData.ToDynamic().ToList();

		var filteredList = artistList.FirstOrDefault(rows => Convert.ToString(rows.artistID) == artistID);

		

		if (artistID != null)
		{
			string artistTitle = filteredList.title;
			string biography  = filteredList.biography;	
			//string imageUrl = filteredList.imageUrl;

			// Use the retrieved values to populate your page controls
			lblTitle.Text = artistTitle;
			lblbiography.Text = biography;
			//imgArtist.ImageUrl = imageUrl;
		}
	
		//else
		//	{
		//		// Throw a custom exception with a specific error message
		//		throw new HttpException(404, "Page Not Found - Artist Not Found");
		//	}



			////lblTitle.Text = artistData[0][Title]

			//lblTitle.Text = (string)result["Title"]; /*(string)artistData.Rows[0]["Title"];*/


		}
}