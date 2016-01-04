<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div class="table-responsive" style="margin-left: 5%; margin-right: 5%;">

            <div class="top-content">

                <div class="inner-bg">
                    <div class="container">
                        <div class="row">

                            <div class="col-sm-8 col-sm-offset-2 text">
                                <h1><strong>Login Form</strong></h1>
                                <div class="description">
                                    <p>
                                        Login to Manage customer.
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6 col-sm-offset-3 form-box">
                                <div class="form-top">
                                    <div class="form-top-left">
                                        <p>Enter your username and password to log on:</p>
                                        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="form-top-right">
                                        <i class="fa fa-key"></i>
                                    </div>
                                </div>
                                <div class="form-bottom">
                                   
                                        <div class="form-group">
                                            <label class="sr-only" for="form-username">Username</label>
                                            <asp:TextBox ID="txtUsername" type="text" name="form-username" placeholder="Username..." class="form-username form-control" runat="server" MaxLength="15"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" ForeColor="Red" Text="Please type in username" ValidationGroup="vgAdd" />

                                        </div>
                                        <div class="form-group">
                                            <label class="sr-only" for="form-password">Password</label>
                                            <asp:TextBox ID="txtPassword" type="password" name="form-password" placeholder="Password..." class="form-password form-control" runat="server" TextMode="Password" MaxLength="15"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ForeColor="Red" Text="Please type in password" ValidationGroup="vgAdd" />
                                        </div>

                                        <asp:Button ID="btnLogin" class="btn btn-info" runat="server" Text="Sign In" OnClick="btnLogin_Click" Width="150px" ValidationGroup="vgAdd"/>
                                        <asp:Button ID="btnRegister" CssClass="btn" runat="server" Text="Register" Width="150px" OnClick="btnRegister_Click"  />
                                 
                                </div>
                            </div>
                        </div>



                    </div>
                </div>

            </div>
        </div>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CompanyConnectionString %>" SelectCommand="SELECT [UserUsername], [UserPassword], [UserHash] FROM [Login]"></asp:SqlDataSource>
    </form>

</body>
</html>
