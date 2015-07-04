<%@ Page Title="" Language="C#" MasterPageFile="~/Login.master" AutoEventWireup="true" CodeBehind="booking.aspx.cs" Inherits="clinic.booking" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Availability</h1><br />
    
           
    <table><tr> 
     <td>
            <asp:Button ID="Schedule" runat="server" Text="Schedule for : " 
                onclick="Schedule_Click" />
            </td>
           <td>
               &nbsp;&nbsp; &nbsp;<asp:DropDownList ID="DropDownSchedule" runat="server" 
                   DataSourceID="scheduledr" DataTextField="dr_name" DataValueField="dr_name">
                  
               </asp:DropDownList> 
              
           </td> <td>&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Search" runat="server" Text="Sort By : " 
                onclick="Search_Click" />
            </td>
           <td>
            
               &nbsp;&nbsp;<asp:DropDownList ID="DropDownSearch" runat="server">
                   <asp:ListItem>Date</asp:ListItem>
                   <asp:ListItem>Slot</asp:ListItem>
                   <asp:ListItem>Doctor</asp:ListItem>
               </asp:DropDownList> 
               
           </td></tr></table> <asp:SqlDataSource ID="scheduledr" runat="server" 
                   ConnectionString="<%$ ConnectionStrings:Table_Connection %>" 
                   SelectCommand="SELECT [dr_name] FROM [doctor]"></asp:SqlDataSource>
<br />


 <asp:GridView ID="appointment" runat="server" AutoGenerateColumns="False" CellPadding="4" CellSpacing="10" ForeColor="#333333" GridLines="None">
                   <Columns>
                       <asp:TemplateField HeaderText="Date" SortExpression="appointment_date">
                           <ItemTemplate>
                           <asp:Label ID="txtappointmentdate" runat="server" Text='<%# Bind("appointment_date","{0:d}") %>' Enabled="False"></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Slot" SortExpression="appointment_time">
                           <ItemTemplate>
                           <asp:Label ID="txtappointmenttime" runat="server" Text='<%# Bind("appointment_time") %>' Enabled="False"></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Doctor Name" SortExpression="dr_name">
                        <ItemTemplate>
                            <asp:Label ID="txtdrname" runat="server" Enabled="False" 
                                Text='<%# Bind("dr_name") %>'></asp:Label>
                        </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Book">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" 
                            ImageUrl="~/images/edit-icon.png" onclick="btnEdit_Click" 
                                CausesValidation="False"/>
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
                    </asp:GridView>    
                    
<asp:Button ID="btnShowPopup" runat="server" style="display:none" />
<asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup" BackgroundCssClass="modalBackground"
CancelControlID="btnCancel">
</asp:ModalPopupExtender>
<asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="269px" Width="400px" BorderColor="Black" BorderStyle="Ridge" style="display:none">
<table width="100%" style="border:Solid 3px #0000A0; width:100%; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:#0000A0">
<td colspan="2" style=" height:10%; color:Black; font-weight:bold; font-size:larger" align="center">Change Appointment Details</td>
</tr>
<tr>
<td align="right" style=" width:45%">
<h4>Date:</h4> 
</td>
<td>
&nbsp; &nbsp; &nbsp;
    <asp:Label ID="txtDate" runat="server" TextMode="SingleLine"></asp:Label>
</td>
</tr>
<tr>
<td align="right" style=" width:45%">
<h4>Time:</h4> 
</td>
<td>
&nbsp; &nbsp; &nbsp;
    <asp:Label ID="txtTime" runat="server" TextMode="SingleLine"></asp:Label>
</td>
</tr>
<tr>
<td align="right" style=" width:45%">
<h4>Doctor Name:</h4> 
</td>
<td>
&nbsp; &nbsp; &nbsp;
    <asp:Label ID="txtDrName" runat="server" TextMode="SingleLine"></asp:Label>
</td>
</tr>
<tr>
<td align="right" style=" width:45%">
<h4>Medical Notes:</h4> 
</td>
<td>
&nbsp; &nbsp; &nbsp;
    <asp:TextBox ID="txtMedicalNotes" runat="server" TextMode="MultiLine"></asp:TextBox>
</td>
</tr>

<tr>
<td align="center">
<asp:Button ID="btnBook" runat="server" Text="Book" CssClass="myButton" onclick="btnBook_Click" />
<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="myButton" />

</td>
</tr>
</table>
    
</asp:Panel>  

</asp:Content>

