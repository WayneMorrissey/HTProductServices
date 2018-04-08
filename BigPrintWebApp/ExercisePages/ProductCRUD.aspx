<%@ Page Title="Product CRUD" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductCRUD.aspx.cs" Inherits="BigPrintWebApp.ExercisePages.ProductCRUD" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>Product CRUD</h1>
    </div>

    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="Label1" runat="server" Text="Products: "></asp:Label>
            <asp:DropDownList ID="ProductList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
            <asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" CausesValidation="false"/>&nbsp;
            <asp:Button ID="Clear" runat="server" Text="Clear" width="67px" OnClick="Clear_Click" CausesValidation="false"/>&nbsp;
            <asp:Button ID="Add" runat="server" Text="Add" width="67px" OnClick="Add_Click" />&nbsp;
            <br /><br />
            <asp:DataList ID="MessageList" runat="server">
                <ItemTemplate>
                    <%# Container.DataItem %>
                </ItemTemplate>
            </asp:DataList>
            <asp:ValidationSummary ID="ProductValidation" runat="server" HeaderText="Please correct the following issues."/>
            <asp:RequiredFieldValidator ID="RequiredFieldName" runat="server" ErrorMessage="A product name is required." ControlToValidate="Name" Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldModelNumber" runat="server" ErrorMessage="A model number is required." ControlToValidate="ModelNumber" Display="None" SetFocusOnError="true"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareDiscontinuedDate" runat="server" ErrorMessage="Date discontinued must be a valid date." Display="None" ControlToValidate="DiscontinuedDate" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
        </div>
    </div>
    <div class="row">
        <div class="col-md-5">
            <fieldset class="form-horizontal" style="text-align:left">
                <legend>Product Information</legend>
                <asp:Label ID="Label2" runat="server" Text="Product ID" AssociatedControlID="ProductID"></asp:Label>
                <asp:TextBox ID="ProductID" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" Text="Name" AssociatedControlID="Name"></asp:Label>
                <asp:TextBox ID="Name" runat="server"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" Text="Model Number" AssociatedControlID="ModelNumber"></asp:Label>
                <asp:TextBox ID="ModelNumber" runat="server"></asp:TextBox>
                <asp:Label ID="Label5" runat="server" Text="Status" AssociatedControlID="Discontinued"></asp:Label>
                <asp:CheckBox ID="Discontinued" runat="server" Text="Discontinued"/>
                <asp:Label ID="Label6" runat="server" Text="Date Discontinued" AssociatedControlID="DiscontinuedDate"></asp:Label>
                <asp:TextBox ID="DiscontinuedDate" runat="server"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="DiscontinuedDate_CalendarExtender" runat="server" TargetControlID="DiscontinuedDate" Format="dd/MM/yyyy"/>
            </fieldset>
        </div>
    </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>
