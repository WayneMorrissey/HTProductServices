<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductregistrationODS.aspx.cs" Inherits="BigPrintWebApp.ExercisePages.ProductregistrationODS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        HT Product Services Exercises: Product Registrations
    </h1>
    <p class="alert alert-info">
        <strong>About:</strong> this page will demonstrate a multiple record query display to a 
        GridView using ObjectDataSource controls. The page will demonstrate
        customization of the GridView covering templates, column selection, column headers, caption
        (with Bootwrap formatting), dataset member referencing(Eval("")) and paging
    </p>
    <asp:DataList ID="MessageList" runat="server">
        <ItemTemplate>
            <%# Container.DataItem %>
        </ItemTemplate>
    </asp:DataList>
    <div class="row" style="margin-left:3px;margin-right:3px;">
        <asp:Label ID="Label1" runat="server" Text="Search part Model Number:"></asp:Label>&nbsp;&nbsp;
        <asp:TextBox ID="ModelNumber" runat="server"></asp:TextBox>&nbsp;&nbsp;
        <asp:Button ID="Search" runat="server" Text="Search" class="btn btn-primary" OnClick="Search_Click"/>
        <br /><br /><br />
        <asp:GridView ID="RegistrationGrid" runat="server" AutoGenerateColumns="False" DataSourceID="RegistrationODS" AllowPaging="True" CssClass="table" GridLines="None" BorderStyle="None" PageSize="5">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="RegistrationID" runat="server" Text='<%# Eval("RegistrationID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Product">
                    <ItemTemplate>
                        <asp:DropDownList ID="ProductList" runat="server" SelectedValue='<%# Eval("ProductID") %>' DataSourceID="ProductODS" DataTextField="DisplayName" DataValueField="ProductID"></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Customer">
                    <ItemTemplate>
                        <asp:DropDownList ID="CustomerList" runat="server" SelectedValue='<%# Eval("CustomerID") %>' DataSourceID="CustomerODS" DataTextField="FullName" DataValueField="CustomerID"></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Serial Number">
                    <ItemTemplate>
                        <asp:Label ID="SerialNumber" runat="server" Text='<%# Eval("SerialNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DofP">
                    <ItemTemplate>
                        <asp:Label ID="DateOfPurchase" runat="server" Text='<%# Eval("DateOfPurchase", "{0:MMM dd, yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Store">
                    <ItemTemplate>
                        <asp:Label ID="PurchasedFrom" runat="server" Text='<%# Eval("PurchasedFrom") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                    No Data Available for supplied product search string
            </EmptyDataTemplate>
            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
        </asp:GridView>
    </div>

    <asp:ObjectDataSource ID="RegistrationODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Registration_GetByModelNumber" TypeName="HTPSSystem.WMorr.BLL.RegistrationController">
        <SelectParameters>
            <asp:ControlParameter ControlID="ModelNumber" PropertyName="Text" DefaultValue="zxzx" Name="modelnumber" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ProductODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Product_List" TypeName="HTPSSystem.WMorr.BLL.ProductController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="CustomerODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Customer_List" TypeName="HTPSSystem.WMorr.BLL.CustomerController"></asp:ObjectDataSource>
    
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>
