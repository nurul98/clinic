<%@ Page Title="" Language="C#" MasterPageFile="~/admin_access/admin.master" AutoEventWireup="true" CodeBehind="doctorlist.aspx.cs" Inherits="clinic.admin_access.doctorlist" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Doctor List</h1>
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
                        <asp:TemplateField HeaderText="Update">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/edit-icon.png" 
                            onclick="btnEdit_Click" CausesValidation="False" />
                        </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnDelete" runat="server" 
                            ImageUrl="~/images/delete-icon.png" onclick="btnDelete_Click"/>
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
                    <asp:TextBox ID="doctor_ID" runat="server" Width="229px"></asp:TextBox>
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
        </table>
         <br />
&nbsp;<asp:Button ID="update" runat="server" Text="Update" onclick="update_Click" />

<asp:Button ID="btnShowPopup2" runat="server" style="display:none" />
<asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnShowPopup2" PopupControlID="pnlpopup2" BackgroundCssClass="modalBackground"
CancelControlID="canceldelete">
</asp:ModalPopupExtender>
<asp:Panel ID="pnlpopup2" runat="server" BackColor="White" Height="269px" Width="400px" BorderColor="Black" BorderStyle="Ridge" style="display:none">
<table width="100%" style="border:Solid 3px #0000A0; width:100%; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:#0000A0">
<td colspan="2" style=" height:10%; color:Black; font-weight:bold; font-size:larger" align="center">Delete Doctor Details</td>
</tr>
<tr>
<td align="center">
<h4>Are you sure you want to delete 
    <asp:Label ID="DeleteDoctor" runat="server" Text="Doctor"></asp:Label>? </h4>
</td>

</tr>
<tr>
<td align="center">
<asp:Button ID="confirmdelete" runat="server" Text="OK" CssClass="myButton" onclick="confirmdelete_Click" />
<asp:Button ID="canceldelete" runat="server" Text="Cancel" CssClass="myButton" />
</td>
</tr>
</table>
   
</asp:Panel>    

   &nbsp;&nbsp;&nbsp; <asp:Button ID="register_doctor" runat="server" 
        Text="Add New" onclick="register_doctor_Click" />

</asp:Content>

