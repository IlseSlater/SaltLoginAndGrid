using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GridAndSalt;

public partial class Register : System.Web.UI.Page
{
    // Connection to database
    string strConnString = ConfigurationManager.ConnectionStrings["CompanyConnectionString"].ConnectionString;
    SqlCommand com;
    SqlDataAdapter sqlda;
    DataSet ds;

    static PasswordManager pwdManager = new PasswordManager();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
       string firstPassword = txtPassword.Text;
       string secondPassword = txtPassword2.Text;
       string username = txtUsername.Text;
        
        if(firstPassword == secondPassword)
        {
            string salt = SimulateUserCreation();
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            lblMsg.Text = "Password did not match !";
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
        
        
    }
    public string SimulateUserCreation()
    {

        string userid = txtUsername.Text;


        string password = txtPassword.Text;

        string salt = null;

        string passwordHash = pwdManager.GeneratePasswordHash(password, out salt);

        // Let us save the values in the database

       
           
       

        // Add the User to the database
        bool IsAdded = false;
        string CompanyConnectionString = ConfigurationManager.ConnectionStrings["CompanyConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CompanyConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("LoginInsert"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "INSERT");
                cmd.Parameters.AddWithValue("@UserUsername", userid);
                cmd.Parameters.AddWithValue("@UserTextPassword", password);
                cmd.Parameters.AddWithValue("@UserPassword", passwordHash);
                cmd.Parameters.AddWithValue("@UserHash", salt);

                cmd.Connection = con;
                con.Open();
                IsAdded = cmd.ExecuteNonQuery() > 0;
                con.Close();
            }
        }

        if (IsAdded)
        {
            lblMsg.Text = "'" + userid + " was successfully added!";
            lblMsg.ForeColor = System.Drawing.Color.Green;


        }
        else
        {
            lblMsg.Text = "Error while adding '" + userid + " ' ";
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }

        return salt;
    }
}