<%@ Page Title="" Language="C#" MasterPageFile="~/admin_access/admin.Master" AutoEventWireup="true" CodeBehind="bookingadmin.aspx.cs" Inherits="clinic.admin_access.bookingadmin" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   <br />
    <h2>Pending Booking</h2>
  
    <asp:GridView ID="gdvPending" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" CellSpacing="10" ForeColor="#333333" GridLines="None" 
        ShowFooter="True">
        <Columns>
            <asp:BoundField DataField="appointment_ID" HeaderText="Appointment ID" />
            <asp:BoundField DataField="username" HeaderText="Patient Name" />
            <asp:BoundField DataField="dr_name" HeaderText="Doctor" />
            <asp:BoundField DataField="appointment_date" HeaderText="Date" DataFormatString="{0:d}"/>
            <asp:BoundField DataField="appointment_time" HeaderText="Slot" />
            <asp:BoundField DataField="medi_note" HeaderText="Notes" />
            <asp:BoundField DataField="approval_status" HeaderText="Approval Status" />
            
            <asp:TemplateField HeaderText="Verify">
                <FooterTemplate>
                    <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" 
                        Text="Verify Booking" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="drpdwnDecision" runat="server" DataValueField="decision" 
                        Height="18px" Width="99px">
                        <asp:ListItem Value="1">Pending</asp:ListItem>
                        <asp:ListItem Value="2">Approved</asp:ListItem>
                        <asp:ListItem Value="3">Rejected</asp:ListItem> 
                    </asp:DropDownList>
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
<br />
 <h2>Approved Booking</h2>
<asp:GridView ID="gdvApproved" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" CellSpacing="10" ForeColor="#333333" GridLines="None" 
        ShowFooter="True">
        <Columns>
            <asp:BoundField DataField="appointment_ID" HeaderText="Appointment ID" />
            <asp:BoundField DataField="username" HeaderText="Patient Name" />
            <asp:BoundField DataField="dr_name" HeaderText="Doctor" />
            <asp:BoundField DataField="appointment_date" HeaderText="Date" DataFormatString="{0:d}"/>
            <asp:BoundField DataField="appointment_time" HeaderText="Slot" />
            <asp:BoundField DataField="medi_note" HeaderText="Notes" />
            <asp:BoundField DataField="approval_status" HeaderText="Approval Status" />
            
            <asp:TemplateField HeaderText="Verify">
                <FooterTemplate>
                    <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" 
                        Text="Verify Booking" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="drpdwnDecision" runat="server" DataValueField="decision" 
                        Height="18px" Width="99px">
                        <asp:ListItem Value="1">Approved</asp:ListItem>
                        <asp:ListItem Value="2">Rejected</asp:ListItem>
                        <asp:ListItem Value="3">Pending</asp:ListItem>
                    </asp:DropDownList>
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
    <br />
     <h2>Rejected Booking</h2>
    <asp:GridView ID="gdvRejected" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" CellSpacing="10" ForeColor="#333333" GridLines="None" 
        ShowFooter="True">
        <Columns>
            <asp:BoundField DataField="appointment_ID" HeaderText="Appointment ID" />
            <asp:BoundField DataField="username" HeaderText="Patient Name" />
            <asp:BoundField DataField="dr_name" HeaderText="Doctor" />
            <asp:BoundField DataField="appointment_date" HeaderText="Date" DataFormatString="{0:d}"/>
            <asp:BoundField DataField="appointment_time" HeaderText="Slot" />
            <asp:BoundField DataField="medi_note" HeaderText="Notes" />
            <asp:BoundField DataField="approval_status" HeaderText="Approval Status" />
            
            <asp:TemplateField HeaderText="Verify">
                <FooterTemplate>
                    <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" 
                        Text="Verify Booking" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="drpdwnDecision" runat="server" DataValueField="decision" 
                        Height="18px" Width="99px">
                        <asp:ListItem Value="1">Rejected</asp:ListItem>
                        <asp:ListItem Value="2">Approved</asp:ListItem>
                        <asp:ListItem Value="3">Pending</asp:ListItem>
                    </asp:DropDownList>
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
</asp:Content>

