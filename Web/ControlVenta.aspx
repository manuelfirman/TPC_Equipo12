<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ControlVenta.aspx.cs" Inherits="Web.ControlVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="card">
            <div class="card-body">
                <h1 class="card-title">Compra ID <%= Compra.IDVenta %></h1>
            </div>
        </div>
    </div>
</asp:Content>
