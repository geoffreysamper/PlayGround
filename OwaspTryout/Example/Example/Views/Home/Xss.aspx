
<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

<h2>Xss</h2>
<a href="/Home/Detail/INE001A01036?message=21%22;window.alert('ddddd');//">click here</a>
</asp:Content>
