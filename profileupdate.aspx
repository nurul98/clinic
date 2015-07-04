<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="profileupdate.aspx.cs" Inherits="clinic.profileupdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
        .style1
        {
            width: 193px;
        }
        .style2
        {
        }
        .style3
        {
            width: 350px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
 <br /><h3>Your Profile</h3>
    <br />
<table class="style1">
             <tr>
                <td class="style3">
                    Patient ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>
                    <asp:TextBox ID="patient_ID" runat="server" Width="229px"></asp:TextBox>
                </td>
            </tr>

             <tr>
                <td class="style3">
                    First Name:</td>
                <td>
                    <asp:TextBox ID="first_name" runat="server" Width="229px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Last Name:</td>
                <td>
                    <asp:TextBox ID="last_name" runat="server" Width="229px"></asp:TextBox>
                </td>
                
             
            </tr>
            <tr>
                <td class="style3">
                    IC No:</td>
                <td>
                    <asp:TextBox ID="IC" runat="server" Width="178px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Passport No:</td>
                <td>
                    <asp:TextBox ID="passport" runat="server" Width="178px"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="style3">
                    Address:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>
                    <asp:TextBox ID="address" runat="server" Width="229px" Height="85px" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="style3">
                    E-mail: </td>
                <td>
                    <asp:TextBox ID="email" runat="server" Width="178px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Phone:</td>
                <td>
                    <asp:TextBox ID="phone" runat="server" Width="178px" ></asp:TextBox>
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Edit-icon (1).png" 
                        style="z-index: 1; left: 75%; top: 350px; position: absolute" />
                </td>
            </tr>
             <tr>
                <td class="style3">
                    Age:</td>
                <td>
                    <asp:TextBox ID="age" runat="server"  
                        CssClass="style2" Width="65px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Gender:</td>
                <td>
                    <asp:DropDownList ID="gender" runat="server">
                        <asp:ListItem>Female</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;</td>
            </tr>
            
        </table>
    <br />
&nbsp;<asp:Button ID="update" runat="server" Text="Update" onclick="update_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    &nbsp;<asp:ChangePassword ID="ChangePassword1" runat="server">
    </asp:ChangePassword>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
</asp:Content>

