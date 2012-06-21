<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

<h2>AntiXss</h2>

<table>
    <tr>
    <th>method</th>
    <th></th>
    </tr>
    <% foreach (KeyValuePair<string,string> entry in Model)
       {%>
 <tr>
     <td><%:entry.Key %></td>
     <td><%: entry.Value %></td>
 </tr> 
<%       } %>
    

</table>




</asp:Content>
