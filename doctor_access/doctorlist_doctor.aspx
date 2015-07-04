<%@ Page Title="" Language="C#" MasterPageFile="~/doctor_access/doctor.Master" AutoEventWireup="true" CodeBehind="doctorlist_doctor.aspx.cs" Inherits="clinic.doctor_access.doctorlist_doctor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   <h1>Doctor List</h1><br />
<asp:GridView ID="griddoctor" runat="server" AutoGenerateColumns="False" CellPadding="4" CellSpacing="10" ForeColor="#333333" GridLines="None">
                   <Columns>
                       <asp:BoundField DataField="dr_ID" HeaderText="ID" 
                     SortExpression="dr_ID" />
                       <asp:TemplateField HeaderText="Username" SortExpression="username">
                           <ItemTemplate>
                           <asp:Label ID="username" runat="server" Text='<%# Bind("username") %>' Enabled="False"></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Doctor Name" SortExpression="dr_name">
                           <ItemTemplate>
                           <asp:Label ID="txtname" runat="server" Text='<%# Bind("dr_name") %>' Enabled="False"></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Speciality" SortExpression="dr_speciality">
                        <ItemTemplate>
                            <asp:Label ID="txtspeciality" runat="server" Text='<%# Bind("dr_speciality") %>' Enabled="False" ></asp:Label>
                        </ItemTemplate>
                       </asp:TemplateField>
                        <asp:TemplateField HeaderText="View">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit-icon.png" 
                            onclick="btnEdit_Click" CausesValidation="False" />
                        </ItemTemplate>
                       </asp:TemplateField>
                      
                   </Columns>
                    <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>   <br /><br />
<table class="style1">
             <tr>
                <td class="style3">
                    Doctor ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>
                    <asp:Label ID="Lbldoctor_ID" runat="server" Text=""></asp:Label>
                </td>
            </tr>

             <tr>
                <td class="style3">
                    Name:</td>
                <td>
                    <asp:Label ID="Lblname" runat="server" Text=""></asp:Label>
                  </td>
            </tr>
            <tr>
                <td class="style3">
                    Speciality:</td>
                <td>
                    <asp:Label ID="Lblspeciality" runat="server" Text=""></asp:Label>
                </td>
            </tr>  
        </table>
         <br />
&nbsp;<asp:Button ID="btnShowPopup2" runat="server" style="display:none" />
</asp:Content>

