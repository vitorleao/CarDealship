<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Car.aspx.cs" Inherits="CarDealship.Car" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Cars Database</h2>
        <asp:GridView ID="grvCar" DataKeyNames="ID" runat="server" AutoGenerateColumns="false" OnRowCommand="grvCar_RowCommand">
            <Columns>
                <asp:BoundField DataField="BrandId" HeaderText="Brand ID" />
                <asp:BoundField DataField="BrandName" HeaderText="Brand" />
                <asp:BoundField DataField="Model" HeaderText="Model" />
                <asp:BoundField DataField="Year" HeaderText="Year" />
                <asp:BoundField DataField="Color" HeaderText="Color" />

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" ID="btnEdit" CausesValidation="false" CommandName="EditCar" Text="Edit" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" ID="btnDelete" CausesValidation="false" CommandName="DeleteCar" Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <a runat="server" href="~/Car">Refresh Table</a>
    </div>
    <br>
    <div id="IdRegistrationForm" runat="server">
        <h2>Create/Edit a Car</h2>
        <table>
            <tr>
                <td>
                    <asp:HiddenField ID="Id" runat="server"></asp:HiddenField>
                </td>
            </tr>
            <tr>
                <td>Brand Id:&nbsp</td>
                <td>
                    <asp:TextBox ID="IdBrand" runat="server"></asp:TextBox>
                </td>
                <td>&nbspModel:&nbsp</td>
                <td>
                    <asp:TextBox ID="IdtxtModel" runat="server"></asp:TextBox>
                </td>
                <td>&nbspYear:&nbsp</td>
                <td>
                    <asp:TextBox ID="IdYear" runat="server"></asp:TextBox>
                </td>
                <td>&nbspColor:&nbsp</td>
                <td>
                    <asp:TextBox ID="IdtxtColor" runat="server"></asp:TextBox>
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
