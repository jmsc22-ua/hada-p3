<%@ Page Title="Products management" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="hada_p3.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="color:darkslategrey; padding:10px;">
        Products Management
    </h1>

    Code <asp:TextBox ID="code" runat="server" /><br />
    <br />
    Name <asp:TextBox ID="name" runat="server" /><br />
    <br />
    Amount <asp:TextBox ID="amount" runat="server" /><br />
    <br />
    Category
    <asp:DropDownList ID="category" runat="server">
        <asp:ListItem Text="Seleccione una opción"/>
        <asp:ListItem Text="Computing" Value="0" />
        <asp:ListItem Text="Telephony" Value="1" />
        <asp:ListItem Text="Gaming" Value="2" />
        <asp:ListItem Text="Home appliances" Value="3" />
    </asp:DropDownList>

    <br /><br />
    Price <asp:TextBox ID="price" runat="server" /><br />
    <br />
    Creation Date <asp:TextBox ID="creationDate" runat="server" /><br /><br />
    <br />
    <asp:Button ID="create" runat="server" Text="Create" OnClick="create_Click" />
    <asp:Button ID="update" runat="server" Text="Update" OnClick="update_Click" />
    <asp:Button ID="delete" runat="server" Text="Delete" OnClick="delete_Click"/>
    <asp:Button ID="read" runat="server" Text="Read" OnClick="read_Click"/>
    <asp:Button ID="readFirst" runat="server" Text="Read First" OnClick="readFirst_Click" />
    <asp:Button ID="readPrev" runat="server" Text="Read Prev" OnClick="readPrev_Click"/>
    <asp:Button ID="readNext" runat="server" Text="Read Next" OnClick="readNext_Click"/>

    <asp:Label ID="lblError" runat="server" ForeColor="Red" />

</asp:Content>