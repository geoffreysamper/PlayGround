<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="OutputCachingTryouts._Default" %>
<%@OutputCache Duration="300" Location="Server" VaryByParam="contentid;ignore"  %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<div><strong>Server Time:</strong><%= DateTime.Now%></div> <% %>

<ul>
    
    <li><a href="Default.aspx">normal request 1</a></li>
    <li><a href="Default.aspx?&ignore=1">ignore current request 1</a></li>
    
    <li><a href="Default.aspx?contentid=2">normal request 2</a></li>
    <li><a href="Default.aspx?contentid=2&ignore=1">ignore current request</a></li>
</ul>

<%if (!string.IsNullOrEmpty(Request.QueryString["ignore"]))

  {
%>      
<h1>Only visible when ignore param is included in url</h1>      
  <%} %>

<%if (!string.IsNullOrEmpty(Request.QueryString["invalidate"]))

  {
%>      
<h1>Only visible when invalidate param is included in url</h1>      
  <%} %>
  
  <%if (!string.IsNullOrEmpty(Request.QueryString["contentid"]))
    { %>
    <%: Request.QueryString["contentid"] %>
  <% } %>
  <%else
    {%>
      1
        
    <%}%>

</asp:Content>
