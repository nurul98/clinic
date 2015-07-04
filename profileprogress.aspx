<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="profileprogress.aspx.cs" Inherits="clinic.profileprogress" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 248px;
        }
        .style2
        {
            font-size: small;
            width: 128px;
        }
        .style3
        {
            width: 105px;
        }
 </style> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Patient Profile</h1><br />
        <table class="style1">
              <tr>
                 <td class="style2">
                    Patient ID:</td>
                <td>
                    <asp:Label ID="patient_ID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    First Name:</td>
                <td>
                    <asp:Label ID="first_name" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Last Name:</td>
                <td>
                    <asp:Label ID="last_name" runat="server"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td class="style2">
                    IC No:</td>
                <td>
                    <asp:Label ID="IC" runat="server"></asp:Label>
                </td> 
            </tr>
            <tr>
                <td class="style2">
                    Passport No:</td>
                <td>
                    <asp:Label ID="passport" runat="server"></asp:Label>
                </td> 
            </tr>
            
            <tr>
                <td class="style2">
                    Address:</td>
                <td>
                    <asp:Label ID="address" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    E-Mail:</td>
                <td>
                    <asp:Label ID="email" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Phone:</td>
                <td>
                    <asp:Label ID="phone" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Age:</td>
                <td>
                    <asp:Label ID="age" runat="server"></asp:Label>
                    &nbsp;yrs</td>
            </tr>
            <tr>
                <td class="style2">
                    Gender:</td>
                <td>
                    <asp:Label ID="gender" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
    <asp:Button ID="update_profile" runat="server" Text="Update Profile" PostBackUrl="~/profileupdate.aspx" />
        <br />
   <h2>Your Booking</h2><br />  
      <asp:GridView ID="appointment" runat="server" AutoGenerateColumns="False" CellPadding="4" CellSpacing="10" ForeColor="#333333" GridLines="None">
                   <Columns>
                    <asp:BoundField DataField="appointment_ID" HeaderText="ID" 
                     SortExpression="appointment_ID" />
                     <asp:TemplateField HeaderText="Doctor Name" SortExpression="dr_name">
                        <ItemTemplate>
                            <asp:Label ID="txtdrname" runat="server" Enabled="False" 
                                Text='<%# Bind("dr_name") %>'></asp:Label>
                        </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Appointment Date" SortExpression="appointment_date">
                           <ItemTemplate>
                           <asp:Label ID="txtappointmentdate" runat="server" Text='<%# Bind("appointment_date","{0:d}") %>' Enabled="False"></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Appointment Time" SortExpression="appointment_time">
                           <ItemTemplate>
                           <asp:Label ID="txtappointmenttime" runat="server" Text='<%# Bind("appointment_time") %>' Enabled="False"></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Medical Notes" SortExpression="medi_note">
                           <ItemTemplate>
                           <asp:Label ID="medinotes" runat="server" Text='<%# Bind("medi_note") %>' Enabled="False"></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="Approval Status" SortExpression="approval_status">
                           <ItemTemplate>
                           <asp:Label ID="approvalstatus" runat="server" Text='<%# Bind("approval_status") %>' Enabled="False"></asp:Label>
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
                    <h2>Available Slot</h2><br />
                    

    <table><tr> <td class="style3">
            <asp:Button ID="Schedule" runat="server" Text="Schedule for : " 
                onclick="Schedule_Click" Width="96px" />
            </td>
           <td>
               &nbsp;&nbsp;<asp:DropDownList ID="DropDownSchedule" runat="server" 
                   DataSourceID="SqlDataSource3" DataTextField="dr_name" 
                   DataValueField="dr_name">
                  
               </asp:DropDownList> 
           </td>  <td>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Search" runat="server" Text="Sort By : " 
                onclick="Search_Click" />
            </td>
           <td>
            
               &nbsp; &nbsp;<asp:DropDownList ID="DropDownSearch" runat="server">
                   <asp:ListItem>Date</asp:ListItem>
                   <asp:ListItem>Slot</asp:ListItem>
                   <asp:ListItem>Doctor</asp:ListItem>
               </asp:DropDownList> 
               
           </td></tr>  
              </table><br /><asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                   ConnectionString="<%$ ConnectionStrings:Table_Connection %>" 
                   SelectCommand="SELECT [dr_name] FROM [doctor]"></asp:SqlDataSource>
 <asp:GridView ID="gridslot" runat="server" AutoGenerateColumns="False" CellPadding="4" CellSpacing="10" ForeColor="#333333" GridLines="None">
                   <Columns>
                       <asp:TemplateField HeaderText="ID" SortExpression="availability_ID">
                           <ItemTemplate>
                           <asp:Label ID="txtid" runat="server" Text='<%# Bind("availability_ID") %>' Enabled="False"></asp:Label>
                           </ItemTemplate>
                       </asp:TemplateField>
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
<h4>Appointment Date: </h4>
</td>
<td>
&nbsp; &nbsp; &nbsp;
    <asp:TextBox ID="txtAppointmentDate" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td align="right">
<h4>Appointment Time: </h4>
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
  <asp:DropDownList ID="drpDrName" runat="server"  AppendDataBoundItems="True" DataSourceID="SqlDataSource2" 
        DataTextField="dr_name" DataValueField="dr_name"> 
    </asp:DropDownList>

    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Table_Connection %>" 
        SelectCommand="SELECT [dr_name] FROM [doctor]"></asp:SqlDataSource>
    
</td>
</tr>
<tr>
<td align="right">
<h4>Medical Notes: </h4>
</td>
<td>
&nbsp; &nbsp; &nbsp;
    <asp:TextBox ID="txtMediNotes" runat="server" TextMode="MultiLine"></asp:TextBox>
</td>
</tr>
<tr>
<td align="center">
<asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="myButton" onclick="btnUpdate_Click" />
<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="myButton" />
<asp:Button ID="btnUpdateNotes" runat="server" Text="Update Medi Notes" CssClass="myButton" onclick="btnUpdateNotes_Click" />

</td>
</tr>
</table>
    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtAppointmentDate" Format="dd-MMM-yyyy">
    </asp:CalendarExtender>

    </asp:Panel>

<asp:Button ID="btnShowPopup2" runat="server" style="display:none" />
<asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnShowPopup2" PopupControlID="pnlpopup2" BackgroundCssClass="modalBackground"
CancelControlID="canceldelete">
</asp:ModalPopupExtender>
<asp:Panel ID="pnlpopup2" runat="server" BackColor="White" Height="269px" Width="400px" BorderColor="Black" BorderStyle="Ridge" style="display:none">
<table width="100%" style="border:Solid 3px #0000A0; width:100%; height:100%" cellpadding="0" cellspacing="0">
<tr style="background-color:#0000A0">
<td colspan="2" style=" height:10%; color:Black; font-weight:bold; font-size:larger" align="center">Delete Appointment Details</td>
</tr>
<tr>
<td align="center">
<h4>Are you sure you want to delete? </h4>
</td>
</tr>
<tr>
<td align="right">
<h4>Appointment Date: </h4>
</td>
<td>
&nbsp; &nbsp; &nbsp;
    <asp:TextBox ID="DeleteDate" runat="server" Enabled="False"></asp:TextBox>
</td>
</tr>
<tr>
<td align="right">
<h4>Appointment Time: </h4>
</td>
<td >
    &nbsp; &nbsp; &nbsp;
    <asp:TextBox ID="DeleteTime" runat="server" Enabled="False"></asp:TextBox>
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
<td align="right">
<h4>Medical Notes: </h4>
</td>
<td>
&nbsp; &nbsp; &nbsp;
    <asp:TextBox ID="DeleteNotes" runat="server" TextMode="MultiLine" Enabled="False"></asp:TextBox>
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

