<%@ Page Title="" Language="C#" MasterPageFile="~/admin_access/admin.Master" AutoEventWireup="true" CodeBehind="addnewdoctor.aspx.cs" Inherits="clinic.admin_access.addnewdoctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
  <h1>Add New Doctor</h1>
<table class="style1">
              <tr>
                <td class="style3">
                    Username:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>
                    <asp:TextBox ID="doctor_username" runat="server" Width="229px"></asp:TextBox>
                </td>
            </tr>
            

             <tr>
                <td class="style3">
                    Name:</td>
                <td>
                    <asp:TextBox ID="name" runat="server" Width="229px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Speciality:</td>
                <td>
                    <asp:TextBox ID="speciality" runat="server" Width="229px"></asp:TextBox>
                </td>
               
            </tr>  
        </table><br /> <asp:Button ID="register_doctor" runat="server" 
        Text="Add New" onclick="register_doctor_Click" />
</asp:Content>

