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
    public partial class Car : Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                using (SqlConnection xSqlConnection = new SqlConnection(connectionString))
                {
                    string cmdText = "SELECT * FROM tblBrand as B INNER JOIN tblCar as C ON B.Id = C.BrandId";
                    SqlCommand xSqlCommand = new SqlCommand(cmdText, xSqlConnection);
                    SqlDataAdapter adapter = new SqlDataAdapter(xSqlCommand);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    grvCar.DataSource = ds;
                    grvCar.DataBind();
                }
            }
        }
        protected void IdSubmitBtn_Click(object sender, EventArgs e)
        {
            if (Id.Value == "")
            {
                using (SqlConnection xSqlConnection = new SqlConnection(connectionString))
                {
                    string cmdText = "INSERT INTO tblCar (BrandId, Model, Year, Color) VALUES(@brand,@model,@year,@color)";
                    SqlCommand xSqlCommand = new SqlCommand(cmdText, xSqlConnection);

                    xSqlCommand.Parameters.AddWithValue("@brand", IdBrand.Text.Trim());
                    xSqlCommand.Parameters.AddWithValue("@model", IdtxtModel.Text.Trim());
                    xSqlCommand.Parameters.AddWithValue("@year", IdYear.Text.Trim());
                    xSqlCommand.Parameters.AddWithValue("@color", IdtxtColor.Text.Trim());

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
                    string cmdText = " UPDATE tblCar SET BrandId=@brand,Model=@model,Year=@year,Color=@color WHERE ID=@id";
                    SqlCommand xSqlCommand = new SqlCommand(cmdText, xSqlConnection);

                    xSqlCommand.Parameters.AddWithValue("@id", Id.Value);
                    xSqlCommand.Parameters.AddWithValue("@brand", IdBrand.Text.Trim());
                    xSqlCommand.Parameters.AddWithValue("@model", IdtxtModel.Text.Trim());
                    xSqlCommand.Parameters.AddWithValue("@year", IdYear.Text.Trim());
                    xSqlCommand.Parameters.AddWithValue("@color", IdtxtColor.Text.Trim());

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

        protected void grvCar_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int index = row.RowIndex;
            Id.Value = grvCar.DataKeys[index].Value.ToString();

            if (e.CommandName == "EditCar")
            {
                Id.Value = grvCar.DataKeys[index].Value.ToString();
                IdBrand.Text = grvCar.Rows[index].Cells[0].Text;
                IdtxtModel.Text = grvCar.Rows[index].Cells[0].Text;
                IdYear.Text = grvCar.Rows[index].Cells[0].Text;
                IdtxtModel.Text = grvCar.Rows[index].Cells[0].Text;
            }
            if (e.CommandName == "DeleteCar")
            {

                bool isDeleted = Delete(Convert.ToInt32(Id.Value));
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
                    string cmdText = "DELETE FROM TblCar WHERE ID=@id";
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
