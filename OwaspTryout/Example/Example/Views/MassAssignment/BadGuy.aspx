<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <h2>
        BadGuy MassAssignment</h2>
    <form action="/MassAssignment/Edit" method="post">
    <fieldset>
        <legend>has the problem</legend>
        <div>
            <label>
                Name:</label>
            <input id="Name" name="Name" type="text" value="" />
        </div>
        <div>
            <label>
                Secret:</label>
            <input id="Secret" name="Secret" type="text" value="" />
        </div>
        <div>
            <input type="submit" value="save" />
        </div>
    </fieldset>
    </form>
</asp:Content>
