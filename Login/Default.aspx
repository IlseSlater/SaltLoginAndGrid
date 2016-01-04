<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <style type="text/css">
        .AlignCentre {
            text-align: center;
        }
    </style>
    <div class="pannel">
        <h1>Manage Customers</h1>
    </div>

    <div class="table-responsive" style="margin-left: 5%; margin-right: 5%;">
        <div runat="server" id="errorMsg" class="alert alert-success">
            <a href="#" class="close" data-dismiss="alert">×</a>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>

        <br />
        <br />
        <div class="panel panel-default and panel-title and panel-body" style="background-color: #C0C8E4;">Customers</div>
        <div class="panel-body"    style=" background-color: rgba(192, 200, 228, 0.15);">
            
               <div class="col-lg-6">
        <table class="table table-bordered tbl-checkout" style="align-items: center">
            <tr style="visibility: hidden">
                <td aria-hidden="True">Customer Id:
                </td>
                <td aria-hidden="True">
                    <asp:TextBox ID="txtCustomerID" runat="server" Enabled="false" />
                </td>
            </tr>
            <tr>
                <td style="white-space: nowrap">
                    <asp:Label ID="lblCustomerName" runat="server" Text="Name:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerName" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvCustomerName" runat="server" ControlToValidate="txtCustomerName" ForeColor="Red" Text="Please type in Customer Name" ValidationGroup="vgAdd" />
                </td>
            </tr>
            <tr>
                <td style="white-space: nowrap">
                    <asp:Label ID="lblCustomerSurname" runat="server" Text="Surname:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerSurname" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCustomerSurname" runat="server" ControlToValidate="txtCustomerSurname" ForeColor="Red" Text="Please type in Customer Surname" ValidationGroup="vgAdd" />
                </td>
            </tr>
            <tr>
                <td style="white-space: nowrap">
                    <asp:Label ID="lblCustomerIDNum" runat="server" Text="ID Number:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCustomerIDNum" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCustomerIDNum" runat="server" ControlToValidate="txtCustomerIDNum" ForeColor="Red" Text="South African ID Number Required" ValidationGroup="vgAdd" />
                    <asp:RegularExpressionValidator ID="revCustomerIDNum" runat="server" ControlToValidate="txtCustomerIDNum" ForeColor="Red" Text="Supply South African ID Number" ValidationExpression="(((\d{2}((0[13578]|1[02])(0[1-9]|[12]\d|3[01])|(0[13456789]|1[012])(0[1-9]|[12]\d|30)|02(0[1-9]|1\d|2[0-8])))|([02468][048]|[13579][26])0229))(( |-)(\d{4})( |-)(\d{3})|(\d{7}))" ValidationGroup="vgAdd" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button type="button" class="btn btn-success" ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" ValidationGroup="vgAdd" />
                    <asp:Button type="button" class="btn btn-info" ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" ValidationGroup="vgAdd" />
                    <asp:Button type="button" class="btn btn-danger" ID="btnDelete" runat="server" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete this record?')" Text="Delete" ValidationGroup="vgAdd" />
                    <asp:Button type="button" class="btn btn-warning" ID="btnCancel" runat="server" CausesValidation="false" OnClick="btnCancel_Click" Text="Cancel" />
                </td>
            </tr>
        </table>
    </div>
    <br />

    <div class="col-lg-6">
        <asp:GridView CssClass="table table-striped table-bordered table-hover" Width="100%" ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton type="button" class="btn btn-info btn-xs" ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Select" Text="Select"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ID" InsertVisible="False" SortExpression="ID" Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name" SortExpression="Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Surname" SortExpression="Surname">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtSurname" runat="server" Text='<%# Bind("Surname") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblSurname" runat="server" Text='<%# Bind("Surname") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ID Number" SortExpression="ID_Number">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtIDNum" runat="server" Text='<%# Bind("ID_Number") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblIDNum" runat="server" Text='<%# Bind("ID_Number") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False" Visible="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" CommandArgument='<%# Eval("ID") %>' Text="Update"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
        
        </div>
    </div>


    <div class="row">
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CompanyConnectionString %>" SelectCommand="SELECT [ID], [Name], [Surname], [ID_Number] FROM [Customer]" DeleteCommand="DELETE FROM [Customer] WHERE [ID] = @original_ID AND [Name] = @original_Name AND [Surname] = @original_Surname AND [ID_Number] = @original_ID_Number" InsertCommand="INSERT INTO [Customer] ([Name], [Surname], [ID_Number]) VALUES (@Name, @Surname, @ID_Number)" UpdateCommand="UPDATE [Customer] SET [Name] = @Name, [Surname] = @Surname, [ID_Number] = @ID_Number WHERE [ID] = @original_ID AND [Name] = @original_Name AND [Surname] = @original_Surname AND [ID_Number] = @original_ID_Number" OldValuesParameterFormatString="original_{0}" ConflictDetection="CompareAllValues">
        <DeleteParameters>
            <asp:Parameter Name="original_ID" Type="Int32" />
            <asp:Parameter Name="original_Name" Type="String" />
            <asp:Parameter Name="original_Surname" Type="String" />
            <asp:Parameter Name="original_ID_Number" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Surname" Type="String" />
            <asp:Parameter Name="ID_Number" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Surname" Type="String" />
            <asp:Parameter Name="ID_Number" Type="String" />
            <asp:Parameter Name="original_ID" Type="Int32" />
            <asp:Parameter Name="original_Name" Type="String" />
            <asp:Parameter Name="original_Surname" Type="String" />
            <asp:Parameter Name="original_ID_Number" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <br />
    <table>
    </table>
    </div>
    </form>
</body>
</html>
