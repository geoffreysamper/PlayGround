<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" Inherits="System.Web.Mvc.ViewPage<Example.Models.MassAssignmentModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

<h2>Edit</h2>
<div>
<strong>Name:</strong><%: Model.Name %>
</div>

<div>
<strong>Secret</strong> <%:Model.Secret %>   
</div>



</asp:Content>
