<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Create.aspx.cs" Inherits="Proposals_Create" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h1>Crear una nueva propuesta legislativa</h1>
    <div>
        <div class="form-group">
            <label>Título:</label>
            <asp:TextBox CssClass="form-control form-control-lg w-100" ID="Title" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Title"
                    CssClass="text-danger" ErrorMessage="El campo titulo es obligatorio." />
        </div>

        <div class="form-group">
            <label>Contenido:</label>
            <asp:TextBox CssClass="form-control form-control-lg" ID="Content" runat="server" TextMode="MultiLine" MaxLength="200" MinLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Content"
                    CssClass="text-danger" ErrorMessage="El campo descripcion es obligatorio." />
        </div>
        <asp:Button ID="Create" runat="server" Text="Crear Propuesta" OnClick="Create_Click" />
    </div>
</asp:Content>
