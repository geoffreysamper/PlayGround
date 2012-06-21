<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" Inherits="System.Web.Mvc.ViewPage<Example.Models.MassAssignmentModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <h2>
        MassAssignment</h2> <a href="<%=Url.Action("BadGuy") %>"></a>
    <% using (Html.BeginForm("Edit","MassAssignment"))
       {%>
    <fieldset>
        <legend>has the problem</legend>
        <div>
            <label>
                Name:</label>
            <%= Html.TextBoxFor(x=>x.Name) %>
        </div>
        <div>
            <input type="submit" value="save" />
        </div>
    </fieldset>
    <%}  %>
</asp:Content>
