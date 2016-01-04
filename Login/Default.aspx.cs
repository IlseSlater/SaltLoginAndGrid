using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    string strConnString = ConfigurationManager.ConnectionStrings["CompanyConnectionString"].ConnectionString;
    SqlCommand com;
    SqlDataAdapter sqlda;
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            //BindGrid();
            GridView1.DataBind();
        }
        errorMsg.Visible = false;
    }

    private void BindGrid()
    {
        string CompanyConnectionString = ConfigurationManager.ConnectionStrings["CompanyConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CompanyConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("InsertUpdateDeleteCustomer"))
            {
                cmd.Parameters.AddWithValue("@Action", "SELECT");

                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView1.DataSourceID = null;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }
    }
    /*##########################################################################################*/

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        bool IsAdded = false;
        string name = txtCustomerName.Text;
        string surname = txtCustomerSurname.Text;
        string IDNum = txtCustomerIDNum.Text;
        string CompanyConnectionString = ConfigurationManager.ConnectionStrings["CompanyConnectionString"].ConnectionString;

        try
        {
            using (SqlConnection con = new SqlConnection(CompanyConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertUpdateDeleteCustomer"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "INSERT");
                    cmd.Parameters.AddWithValue("@ID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Surname", surname);
                    cmd.Parameters.AddWithValue("@ID_Number", IDNum);
                    cmd.Parameters.AddWithValue("@Details", DBNull.Value);

                    cmd.Connection = con;
                    con.Open();
                    IsAdded = cmd.ExecuteNonQuery() > 0;
                    con.Close();
                }
            }


            if (IsAdded)
            {
                lblMsg.Text = "'" + name + " " + surname + "' was successfully added!";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                errorMsg.Visible = true;
                BindGrid();
            }
            else
            {
                lblMsg.Text = "Error while adding '" + name + " " + surname + "' ";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                errorMsg.Visible = true;
            }
            ResetAll();//to reset all form controls


        }
        catch (Exception ex)
        {

            lblMsg.Text = ex.ToString(); ;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtCustomerName.Text))
        {
            lblMsg.Text = "Please select record to update";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            errorMsg.Visible = true;
            return;
        }
        bool IsUpdated = false;
        string name = txtCustomerName.Text;
        string surname = txtCustomerSurname.Text;
        string IDNum = txtCustomerIDNum.Text;
        string CompanyConnectionString = ConfigurationManager.ConnectionStrings["CompanyConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CompanyConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("InsertUpdateDeleteCustomer"))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", "Update");
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtCustomerID.Text));
                cmd.Parameters.AddWithValue("@Name", txtCustomerName.Text.Trim());
                cmd.Parameters.AddWithValue("@Surname", txtCustomerSurname.Text.Trim()); ;
                cmd.Parameters.AddWithValue("@ID_Number", txtCustomerIDNum.Text.Trim());
                cmd.Parameters.AddWithValue("@Details", DBNull.Value);


                cmd.Connection = con;
                con.Open();
                IsUpdated = cmd.ExecuteNonQuery() > 0;
                con.Close();
            }
        }
        if (IsUpdated)
        {
            lblMsg.Text = "'" + name + " " + surname + "' was successfully updated!";
            lblMsg.ForeColor = System.Drawing.Color.Green;
            errorMsg.Visible = true;
            BindGrid();
        }
        else
        {
            lblMsg.Text = "Error while updating '" + name + " " + surname + "' ";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            errorMsg.Visible = true;
        }
        GridView1.EditIndex = -1;
        BindGrid();
        ResetAll();//to reset all form controls
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtCustomerID.Text))
        {
            lblMsg.Text = "Please select record to delete";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            errorMsg.Visible = true;
            return;
        }
        bool IsDeleted = false;
        int CusID = Convert.ToInt32(txtCustomerID.Text);
        string CusName = txtCustomerName.Text.Trim();
        string CompanyConnectionString = ConfigurationManager.ConnectionStrings["CompanyConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CompanyConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("InsertUpdateDeleteCustomer"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Delete");
                cmd.Parameters.AddWithValue("@ID", CusID);
                cmd.Parameters.AddWithValue("@Name", DBNull.Value);
                cmd.Parameters.AddWithValue("@Surname", DBNull.Value);
                cmd.Parameters.AddWithValue("@ID_Number", DBNull.Value);
                cmd.Parameters.AddWithValue("@Details", DBNull.Value);
                cmd.Connection = con;
                con.Open();
                IsDeleted = cmd.ExecuteNonQuery() > 0;
                con.Close();
            }
        }
        if (IsDeleted)
        {
            lblMsg.Text = "'" + CusName + "' deleted successfully!";
            lblMsg.ForeColor = System.Drawing.Color.Green;
            errorMsg.Visible = true;
            BindGrid();
        }
        else
        {
            lblMsg.Text = "Error while deleting '" + CusName + "'  details";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            errorMsg.Visible = true;
        }
        ResetAll();//to reset all form controls
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ResetAll();
    }
    private void ResetAll()
    {
        btnInsert.Visible = true;
        txtCustomerID.Text = "";
        txtCustomerName.Text = "";
        txtCustomerSurname.Text = "";
        txtCustomerIDNum.Text = "";
        this.BindGrid();

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCustomerID.Text = GridView1.DataKeys[GridView1.SelectedRow.RowIndex].Value.ToString();
        txtCustomerName.Text = (GridView1.SelectedRow.FindControl("lblName") as Label).Text;
        txtCustomerSurname.Text = (GridView1.SelectedRow.FindControl("lblSurname") as Label).Text;
        txtCustomerIDNum.Text = (GridView1.SelectedRow.FindControl("lblIDNum") as Label).Text;
        //make invisible Insert button during update/delete
        //btnInsert.Visible = false;
    }
}


