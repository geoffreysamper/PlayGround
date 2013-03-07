<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ArticleNestedMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content3" ContentPlaceHolderID="LeftContent" runat="server">
    
    <%Html.RenderPartial("DisplayMessage","this message should appear on the left "); %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RightContent" runat="server">
    <%Html.RenderPartial("DisplayMessage","this message should appear on the right "); %>
</asp:Content>
