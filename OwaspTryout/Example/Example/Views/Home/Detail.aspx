<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" Inherits="System.Web.Mvc.ViewPage<System.Data.DataRow>" %>
<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <script type="text/javascript">
        var isnCode = "<%=Request["message"] %>";

    </script>
    <h1><%=Model.Field<string>("CompanyName") %></h1>
    <div>
        Industry: <%=Model.Field<string>("Industry") %>

    </div>
    <div>
        ISIN: <%=Model.Field<string>("CompanyName") %>

    </div>
    <div>
        Symbol :<%=Model.Field<string>("Symbol") %>

    </div>
    </asp:Content>
