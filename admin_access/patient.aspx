<%@ Page Title="" Language="C#" MasterPageFile="~/admin_access/admin.master" AutoEventWireup="true" CodeBehind="patient.aspx.cs" Inherits="clinic.admin_access.patient" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h2>Patient List</h2>
    <table><tr> <td class="style3">&nbsp;Search By ID : 
            </td>
           <td>
               &nbsp;&nbsp;<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
             &nbsp;
           </td> <td> 
               <asp:Button ID="Search" runat="server" Text="Search" onclick="Search_Click" /> </td>
           </tr></table> 
<asp:GridView ID="gridpatient" runat="server" AutoGenerateColumns="False" CellPadding="4" CellSpacing="10" ForeColor="#333333" GridLines="None">
                   <Columns>
                       <asp:BoundField DataField="pat_ID" HeaderText="ID" 
                     SortExpression="pat_ID" />
                       <asp:TemplateField HeaderText="Username" SortExpression="pat_username">
                           <ItemTemplate>
                           <asp:Label ID="txtusername" runat="server" Text='<%# Bind("pat_username") %>' Enabled="False"></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="First Name" SortExpression="pat_firstname">
                           <ItemTemplate>
                           <asp:Label ID="txtfirstname" runat="server" Text='<%# Bind("pat_firstname") %>' Enabled="False"></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Last Name" SortExpression="pat_lastname">
                        <ItemTemplate>
                            <asp:Label ID="txtlastname" runat="server" Enabled="False" 
                                Text='<%# Bind("pat_lastname") %>'></asp:Label>
                        </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Phone" SortExpression="pat_phone">
                        <ItemTemplate>
                            <asp:Label ID="txtphone" runat="server" Enabled="False" 
                                Text='<%# Bind("pat_phone") %>'></asp:Label>
                        </ItemTemplate>
                         </asp:TemplateField>
                        <asp:TemplateField HeaderText="E-Mail" SortExpression="pat_email">
                        <ItemTemplate>
                            <asp:Label ID="txtemail" runat="server" Enabled="False" 
                                Text='<%# Bind("pat_email") %>'></asp:Label>
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

<asp:Button ID="btnShowPopup2" runat="server" style="display:none" />
<asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnShowPopup2" PopupControlID="pnlpopup2" BackgroundCssClass="modalBackground"
CancelControlID="canceldelete">
</asp:ModalPopupExtender>
<asp:Panel ID="pnlpopup2" runat="server" BackColor="White" Height="269px" Width="400px" BorderColor="Black" BorderStyle="Ridge" style="display:none">
<table width="100%" style="border:Solid 3px #0000A0; width:100%; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:#0000A0">
<td colspan="2" style=" height:10%; color:Black; font-weight:bold; font-size:larger" align="center">Delete Patient Details</td>
</tr>
<tr>
<td align="center">
<h4>Are you sure to delete 
    <asp:Label ID="DeletePatient" runat="server" Text="Patient"></asp:Label>? </h4>
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

</asp:Content>

