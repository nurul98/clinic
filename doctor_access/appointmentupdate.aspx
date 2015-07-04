<%@ Page Title="" Language="C#" MasterPageFile="~/doctor_access/doctor.Master" AutoEventWireup="true" CodeBehind="appointmentupdate.aspx.cs" Inherits="clinic.doctor_access.appointmentupdate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<h2>Availability</h2>
 <asp:GridView ID="gridslot" runat="server" AutoGenerateColumns="False" CellPadding="4" CellSpacing="10" ForeColor="#333333" GridLines="None">
                   <Columns>
                       <asp:BoundField DataField="availability_ID" HeaderText="ID" 
                     SortExpression="availability_ID" />
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
<td align="right">
<h4>Date: </h4>
</td>
<td>
&nbsp; &nbsp; &nbsp;
    <asp:TextBox ID="txtAppointmentDate" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td align="right">
<h4>Slot: </h4>
</td>
<td >
    &nbsp; &nbsp; &nbsp;
    <asp:DropDownList ID="txtAppointmentTime" runat="server">
       <asp:ListItem>11:00</asp:ListItem>
       <asp:ListItem>13:00</asp:ListItem>
       <asp:ListItem>15:00</asp:ListItem>
       <asp:ListItem>17:00</asp:ListItem>
       <asp:ListItem>19:00</asp:ListItem>
    </asp:DropDownList>
</td>
</tr>
<tr>
<td align="right" style=" width:45%">
<h4>Dr Name:</h4> 
</td>
<td>
&nbsp; &nbsp; &nbsp;
    <asp:Label ID="drpDrName" runat="server" Text="Doctor Name"></asp:Label>
   
</td>
</tr>
<tr>
<td align="center">
<asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="myButton" onclick="btnUpdate_Click" />
<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="myButton" />

</td>
</tr>
</table>
    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtAppointmentDate" Format="dd-MMM-yyyy">
    </asp:CalendarExtender>

</asp:Panel>

<asp:Button ID="btnShowPopup2" runat="server" style="display:none" />
<asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnShowPopup2" PopupControlID="pnlpopup2" BackgroundCssClass="modalBackground"
CancelControlID="canceldelete1">
</asp:ModalPopupExtender>
<asp:Panel ID="pnlpopup2" runat="server" BackColor="White" Height="269px" Width="400px" BorderColor="Black" BorderStyle="Ridge" style="display:none">
<table width="100%" style="border:Solid 3px #0000A0; width:100%; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:#0000A0">
<td colspan="2" style=" height:10%; color:Black; font-weight:bold; font-size:larger" align="center">Delete Appointment Details</td>
</tr>
<tr>
<td align="center">
<h4>Are you sure to delete? </h4>
</td></tr><tr>
 <td align="right">
<h4>Date: </h4>
</td>
<td>
&nbsp; &nbsp; &nbsp;
    <asp:TextBox ID="DeleteDate" runat="server" Enabled="False"></asp:TextBox>
</td>
</tr>
<tr>
<td align="right">
<h4>Slot: </h4>
</td>
<td >
    &nbsp; &nbsp; &nbsp;
   <asp:TextBox ID="DeleteSlot" runat="server" Enabled="False"></asp:TextBox>
</td>
</tr>
<tr>
<td align="right" style=" width:45%">
<h4>Dr Name:</h4> 
</td>
<td>
&nbsp; &nbsp; &nbsp;
      <asp:TextBox ID="DeleteDr" runat="server" Enabled="False"></asp:TextBox>
   
</td>
</tr>
<tr>
<td align="center">
<asp:Button ID="confirmdelete1" runat="server" Text="OK" CssClass="myButton" onclick="confirmdelete_Click" />
<asp:Button ID="canceldelete1" runat="server" Text="Cancel" CssClass="myButton" />
</td>
</tr>
</table>
   
</asp:Panel>    
</asp:Content>
