using DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class PageToSync_artistDetails : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		string artistID = Request.QueryString["artistID"];
		// Create an instance of your database helper class or access the existing instance
		SQL dbHelper = new SQL("admin");
		dbHelper.OpenConnection();

		// Call the necessary methods to retrieve data using the SQL object
		DataTable artistData = dbHelper.ExecuteStoredProcedureDT("dbo.GetArtistDetails", true);
		dbHelper.CloseConnection();

		List<dynamic> artistList = artistData.ToDynamic().ToList();

		var filteredList = artistList.Where(rows => rows.artistID == artistID).Select(rows => new ArtistDetails
		{
			ArtistId = rows.artistID,
			DateCreation = rows.dateCreation,
			Title = rows.title,
			BioGraphy = rows.biography,
			ImgUrl = rows.imageURL,
			heroUrl = rows.heroURL,
		}).ToList();		
		 		
	
	}
}