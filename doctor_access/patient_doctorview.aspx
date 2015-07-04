<%@ Page Title="" Language="C#" MasterPageFile="~/doctor_access/doctor.Master" AutoEventWireup="true" CodeBehind="patient_doctorview.aspx.cs" Inherits="clinic.doctor_access.patient_doctorview" %>
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
           </tr>
       </table> 
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
                    Patient ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>
                    <asp:Label ID="Labelpatient_ID" runat="server" Text=""></asp:Label>
                </td>
            </tr>

             <tr>
                <td class="style3">
                    First Name:</td>
                <td>
                    <asp:Label ID="Labelfirst_name" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Last Name:</td>
                <td>
                    <asp:Label ID="Labellast_name" runat="server" Text=""></asp:Label>
                </td>
                
             
            </tr>
            <tr>
                <td class="style3">
                    IC No:</td>
                <td>
                    <asp:Label ID="LabelIC" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Passport No:</td>
                <td>
                    <asp:Label ID="Labelpassport" runat="server" Text=""></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="style3">
                    Address:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>
                    <asp:Label ID="Labeladdress" runat="server" Text=""></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="style3">
                    E-mail: </td>
                <td>
                    <asp:Label ID="Labelemail" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Phone:</td>
                <td>
                  
                    <asp:Label ID="Labelphone" runat="server" Text=""></asp:Label>
                </td>
            </tr>
             <tr>
                <td class="style3">
                    Age:</td>
                <td>
                    <asp:Label ID="Labelage" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Gender:</td>
                <td>
                    <asp:Label ID="Labelgender" runat="server" Text=""></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;</td>
            </tr>
            
        </table>
         <br />

</asp:Content>
