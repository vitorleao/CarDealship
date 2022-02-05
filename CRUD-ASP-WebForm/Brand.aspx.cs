using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

namespace CarDealship
{
    public partial class Brand : Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                using (SqlConnection xSqlConnection = new SqlConnection(connectionString))
                {
                    string cmdText = "SELECT * FROM tblBrand";
                    SqlCommand xSqlCommand = new SqlCommand(cmdText, xSqlConnection);
                    SqlDataAdapter adapter = new SqlDataAdapter(xSqlCommand);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    grvBrand.DataSource = ds;
                    grvBrand.DataBind();
                }
            }
        }
        protected void IdSubmitBtn_Click(object sender, EventArgs e)
        {
            if (hdID.Value == "")
            {
                using (SqlConnection xSqlConnection = new SqlConnection(connectionString))
                {
                    string cmdText = "INSERT INTO tblBrand (BrandName) VALUES(@brandname)";
                    SqlCommand xSqlCommand = new SqlCommand(cmdText, xSqlConnection);

                    xSqlCommand.Parameters.AddWithValue("@brandname", IdtxtBrandName.Text.Trim());

                    xSqlConnection.Open();
                    int isInserted = xSqlCommand.ExecuteNonQuery();
                    xSqlConnection.Close();
                    if (isInserted > 0)
                    {
                        lblMessage.Text = "Data Saved Sucessfully.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMessage.Text = "Data Not Saved.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            else
            {
                using (SqlConnection xSqlConnection = new SqlConnection(connectionString))
                {
                    string cmdText = " UPDATE tblBrand SET BrandName=@brandname WHERE ID=@id";
                    SqlCommand xSqlCommand = new SqlCommand(cmdText, xSqlConnection);

                    xSqlCommand.Parameters.AddWithValue("@id", hdID.Value);
                    xSqlCommand.Parameters.AddWithValue("@brandname", IdtxtBrandName.Text.Trim());

                    xSqlConnection.Open();
                    int isUpdated = xSqlCommand.ExecuteNonQuery();
                    xSqlConnection.Close();
                    if (isUpdated > 0)
                    {
                        lblMessage.Text = "Data Updated Sucessfully.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMessage.Text = "Data Not Updated.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        protected void grvBrand_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int index = row.RowIndex;
            hdID.Value = grvBrand.DataKeys[index].Value.ToString();

            if (e.CommandName == "EditBrand")
            {
                hdID.Value = grvBrand.DataKeys[index].Value.ToString();
                IdtxtBrandName.Text = grvBrand.Rows[index].Cells[0].Text;
            }
            if (e.CommandName == "DeleteBrand")
            {

                bool isDeleted = Delete(Convert.ToInt32(hdID.Value));
                if (isDeleted)
                {
                    lblMessage.Text = "Data Deleted Sucessfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "Data Not Deleted.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        public bool Delete(int ID)
        {
            int isDeleted = 0;
            if (ID != 0)
            {
                using (SqlConnection xSqlConnection = new SqlConnection(connectionString))
                {
                    string cmdText = "DELETE FROM TblBrand WHERE ID=@id";
                    SqlCommand xSqlCommand = new SqlCommand(cmdText, xSqlConnection);

                    xSqlCommand.Parameters.AddWithValue("@id", ID);

                    xSqlConnection.Open();
                    isDeleted = xSqlCommand.ExecuteNonQuery();
                    xSqlConnection.Close();
                }
            }
            return isDeleted>0;
        }
    }
}
