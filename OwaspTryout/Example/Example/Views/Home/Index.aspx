<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<System.Data.DataTable>" MasterPageFile="../Shared/Master.Master" %>
<%@ Import Namespace="System.Data" %>
<asp:Content runat="server" ContentPlaceHolderID="Content">
    
    <ul>
    <%foreach(DataRow row in Model.AsEnumerable())
      {%>
          <li><a href="<%= Url.Action("Detail",new {id= row.Field<string>("ISINCode")}) %>"><%=row.Field<string>("CompanyName") %></a></li>
          
      <%}%>
      </ul>
      
</asp:Content>