<%@ Page Title="" Language="C#" MasterPageFile="~/doctor_access/doctor.Master" AutoEventWireup="true" CodeBehind="availablelist_doctorview.aspx.cs" Inherits="clinic.doctor_access.availablelist_doctorview" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
        .style1
        {
            width: 52px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
 <h2>Availability</h2>

   <table><tr> <td class="style3">&nbsp;<asp:Button ID="Schedule" runat="server" Text="Schedule for : " 
                onclick="Schedule_Click" Width="96px" />
            </td>
           <td>
               &nbsp;&nbsp;<asp:DropDownList ID="DropDownSchedule" runat="server" 
                   DataSourceID="SqlDataSource3" DataTextField="dr_name" 
                   DataValueField="dr_name">
                  
               </asp:DropDownList> 
             &nbsp;
           </td>  <td>&nbsp;&nbsp;
            <asp:Button ID="Search" runat="server" Text="Sort By : " 
                onclick="Search_Click" />
            </td>
           <td>
            
               &nbsp;&nbsp;<asp:DropDownList ID="DropDownSearch" runat="server">
                   <asp:ListItem>Date</asp:ListItem>
                   <asp:ListItem>Slot</asp:ListItem>
                   <asp:ListItem>Doctor</asp:ListItem>
               </asp:DropDownList> 
               </td> <td> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="change" runat="server" Text="Change Appointment" 
        onclick="change_click" Width="147px"  /></td>
           </tr></table> <br /> <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                   ConnectionString="<%$ ConnectionStrings:Table_Connection %>" 
                   SelectCommand="SELECT [dr_name] FROM [doctor]"></asp:SqlDataSource>
   
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

                    <br /><br /> 
  <table >
            
            <tr>
                <td >
                    Date :</td>
                <td>
                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                </td><td class="style1"></td>
                <td >
                    Time :</td>
                <td>
                    <asp:DropDownList ID="txtTime" runat="server">
                        <asp:ListItem>11:00</asp:ListItem>
                        <asp:ListItem>13:00</asp:ListItem>
                        <asp:ListItem>15:00</asp:ListItem>
                        <asp:ListItem>17:00</asp:ListItem>
                        <asp:ListItem>19:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            
        </table><br />&nbsp; &nbsp;
        <asp:Button ID="assign" runat="server" Text="Assign Slot" onclick="assign_Click" Width="85px"  />
        <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
        TargetControlID="txtDate" Format="dd-MMM-yyyy">
    </asp:CalendarExtender>
        &nbsp;&nbsp;&nbsp;&nbsp;
       
        </asp:Content>

