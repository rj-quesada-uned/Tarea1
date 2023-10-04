<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1 class="mb-5">Usuario</h1>
        <div class="table-grid">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="id_type_name" HeaderText="Tipo de identificacion" />
                </Columns>
                <Columns>
                    <asp:BoundField DataField="user_id" HeaderText="ID" />
                </Columns>
                <Columns>
                    <asp:BoundField DataField="user_name" HeaderText="Nombre" />
                </Columns>
                <Columns>
                    <asp:BoundField DataField="user_lastname" HeaderText="Apellido" />
                </Columns>
                <Columns>
                    <asp:BoundField DataField="user_email" HeaderText="Correo Electronico" />
                </Columns>
                <Columns>
                    <asp:BoundField DataField="user_phone" HeaderText="Correo Electronico" />
                </Columns>
                <Columns>
                    <asp:BoundField DataField="province_name" HeaderText="Provincia" />
                </Columns>
                <Columns>
                    <asp:BoundField DataField="canton_name" HeaderText="Canton" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="jumbotron">
        <h1 class="mb-5">Mis Propuestas</h1>
        <div class="table-grid">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" />
                </Columns>
                <Columns>
                    <asp:BoundField DataField="title" HeaderText="Título" />
                </Columns>
                <Columns>
                    <asp:BoundField DataField="description" HeaderText="Description" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
