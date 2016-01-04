using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GridAndSalt;


public partial class Login : System.Web.UI.Page
{
    // Connection to database
    string strConnString = ConfigurationManager.ConnectionStrings["CompanyConnectionString"].ConnectionString;
    SqlCommand com;
    SqlDataAdapter sqlda;
    DataSet ds;

    static DBUserRepository userRepo = new DBUserRepository();

    // Let us use the Password manager class to generate the password ans salt
    static PasswordManager pwdManager = new PasswordManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        { 
        }
    }


   

    public void SimulateLogin()
    {
        SqlDataReader dr = null;
        string userid = txtUsername.Text;


        string password = txtPassword.Text;

        // Let us retrieve the values from the database
       // User user2 = userRepo.GetUser(userid);
        
          string UserId ;
          string PasswordHash;
          string Salt;

          List<string> numbersList;

        string CompanyConnectionString = ConfigurationManager.ConnectionStrings["CompanyConnectionString"].ConnectionString;
       
        using (SqlConnection con = new SqlConnection(CompanyConnectionString))
            
        {
            string sql = string.Format("  SELECT [ID],[UserUsername],UserTextPassword ,[UserPassword],[UserHash] FROM [Company].[dbo].[Login] where [UserUsername] = '"+userid+"' AND UserTextPassword = '"+ password +"'");
            using (SqlCommand cmd = new SqlCommand(sql,con))
            {
                numbersList = new List<string>();
                con.Open();
               
                 dr = cmd.ExecuteReader();                
                while (dr.Read())
                {
          
                   UserId = dr.GetString(1);
                   PasswordHash = dr.GetString(3);
                   Salt = dr.GetString(4);
                   numbersList.Add(dr.GetString(1));
                   numbersList.Add(dr.GetString(2));
                   numbersList.Add(dr.GetString(3)); 
                   numbersList.Add( dr.GetString(4));

                }
                
                dr.Close();
                ((IDisposable)dr).Dispose();
                
            }
            
        }
string[] numbersArray = numbersList.ToArray();


bool result = pwdManager.IsPasswordMatch(password, numbersArray[3], numbersArray[2]);

        if (result == true)
        {
            lblMsg.Text="Password Matched";
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            lblMsg.Text = "Password not Matched";
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {       
        SimulateLogin(); 
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Register.aspx");
    }
}
