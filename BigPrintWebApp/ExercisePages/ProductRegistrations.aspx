<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductRegistrations.aspx.cs" Inherits="BigPrintWebApp.ExercisePages.ProductRegistrations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        HT Product Services Exercises: Product Registrations
    </h1>
    <p class="alert alert-info">
        <strong>About:</strong> this page will demonstrate a multiple record query display to a 
        GridView using code behind wihtout using ObjectDataSource controls. The page will demonstrate
        customization of the GridView covering templates, column selection, column headers, caption
        (with Bootwrap formatting), dataset member referencing(Eval("")) and paging. The page will 
        demonstrate the implementation of the paging event PageIndexChanging()
    </p>
    <asp:DataList ID="MessageList" runat="server">
        <ItemTemplate>
            <%# Container.DataItem %>
        </ItemTemplate>
    </asp:DataList>
    <div class="row" style="margin-left:3px;margin-right:3px;">
        <asp:Label ID="Label1" runat="server" Text="Products:"></asp:Label>&nbsp;&nbsp;
        <asp:DropDownList ID="ProductList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
        <asp:Button ID="Search" runat="server" Text="Search" class="btn btn-primary" OnClick="Search_Click"/>
        <br /><br /><br />
    </div>
    <div class="row" style="margin-left:3px;margin-right:3px;">
        <div class="col-md-8 col-md-offset-2">
            <fieldset class="form-horizontal">
                <legend>Product</legend>
                <asp:Label ID="Label2" runat="server" Text="Product:" AssociatedControlID="ProductName"></asp:Label>
                <asp:Label ID="ProductName" runat="server"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text="Model Number:" AssociatedControlID="ModelNumber"></asp:Label>
                <asp:Label ID="ModelNumber" runat="server"></asp:Label>
                <asp:Label ID="Label6" runat="server" Text="Discontinued:" AssociatedControlID="Discontinued"></asp:Label>
                <asp:CheckBox ID="Discontinued" runat="server" Text=" " Enabled="false"></asp:CheckBox>
                <asp:Label ID="Label8" runat="server" Text="Discontinued Date:" AssociatedControlID="DiscontinuedDate"></asp:Label>
                <asp:Label ID="DiscontinuedDate" runat="server"></asp:Label>
                <br /><br />
                <p style="text-align:center">
                    Registrations
                </p>
                <asp:GridView ID="RegistrationsGrid" runat="server" AutoGenerateColumns="False" CssClass="table" AllowPaging="True" PageSize="5" OnPageIndexChanging="RegistrationsGrid_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField Visible="false">
                            <ItemTemplate>
                            <asp:Label ID="RegistrationID" runat="server" Text='<%# Eval("RegistrationID") %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Serial Number">
                            <ItemTemplate>
                                <asp:Label ID="SerialNumber" runat="server" Text='<%# Eval("SerialNumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:Label ID="DateOfPurchase" runat="server" Text='<%# Eval("DateOfPurchase", "{0:MMM dd, yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Source">
                            <ItemTemplate>
                                <asp:Label ID="PurchasedFrom" runat="server" Text='<%# Eval("PurchasedFrom") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Province">
                            <ItemTemplate>
                                <asp:Label ID="PurchaseProvince" runat="server" Text='<%# Eval("PurchaseProvince") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                    No data available for product selection
                    </EmptyDataTemplate>
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="3" />
                </asp:GridView>
            </fieldset>
        </div>
    </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>
