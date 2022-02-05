<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Brand.aspx.cs" Inherits="CarDealship.Brand" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Brand Names Database</h2>
        <asp:GridView ID="grvBrand" DataKeyNames="ID" runat="server" AutoGenerateColumns="false" OnRowCommand="grvBrand_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="BrandName" HeaderText="Names" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" ID="btnEdit" CausesValidation="false" CommandName="EditBrand" Text="Edit" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" ID="btnDelete" CausesValidation="false" CommandName="DeleteBrand" Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <a runat="server" href="~/Brand">Refresh Table</a>
    </div>
    <br>
    <div id="IdRegistrationForm" runat="server">
        <h2>Create/Edit a Brand</h2>
        <table>
            <tr>
                <td>
                    <asp:HiddenField ID="hdID" runat="server"></asp:HiddenField>
                </td>
            </tr>
            <tr>
                <td>Brand Name:&nbsp</td>
                <td>
                    <asp:TextBox ID="IdtxtBrandName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="IdSubmitBtn" OnClick="IdSubmitBtn_Click" runat="server" Text="Submit" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
