﻿<%@ Page Title="Products management" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="color:darkslategrey; padding:10px;">
        Products Management
    </h1><br />

    Code <asp:TextBox ID="code" runat="server" /><br />
    <br />
    Name <asp:TextBox ID="name" runat="server" /><br />
    <br />
    Amount <asp:TextBox ID="amount" runat="server" /><br />
    <br />
    Category
    <asp:DropDownList ID="category" runat="server">
        <asp:ListItem>Computing</asp:ListItem>
        <asp:ListItem>Electronics</asp:ListItem>
    </asp:DropDownList><br />
    <br />
    Price <asp:TextBox ID="price" runat="server" /><br />
    <br />
    Creation Date <asp:TextBox ID="creationDate" runat="server" /><br /><br />
    <br />
    <asp:Button ID="create" runat="server" Text="Create" />
    <asp:Button ID="update" runat="server" Text="Update" />
    <asp:Button ID="delete" runat="server" Text="Delete" />
    <asp:Button ID="read" runat="server" Text="Read" />
    <asp:Button ID="readFirst" runat="server" Text="Read First" />
    <asp:Button ID="readPrev" runat="server" Text="Read Prev" />
    <asp:Button ID="readNext" runat="server" Text="Read Next" />

</asp:Content>