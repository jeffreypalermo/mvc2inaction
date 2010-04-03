<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Session>>" %>
<%@ Import Namespace="AjaxExamples.Models"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Chapter 12 - Hijax Technique
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="headContent" runat="server">

    <style type="text/css">
        fieldset
        {
	        border: solid 1px #999;
        }

        fieldset legend
        {
	        background-color: Black;
	        color: #fff;
	        font-weight: bold;
        }

        fieldset label
        {
	        display: block;
	        margin-top: 5px;
        }

        fieldset input[type="submit"]
        {
	        float: left;	
	        margin-top: 20px;	
        }

        table#sessions
        {
	        margin: 5px;
	        padding: 2px;	
        }

        table#sessions tr th
        {
	        background-color: #577;
	        color: White;
	        font-weight: normal;
	        font-size: 0.9em;
	        border: solid 1px #366;
        }

        table#sessions tr td
        {
	        padding: 5px;
	        background-color: #eee;
	        border: solid 1px #ccc;
        }
    </style>

    <script src="../../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script type="text/javascript">

        //execute when the DOM has been loaded
        $(document).ready(function() {
            //wire up to the form submit event
            $("form.hijax").submit(function(event) {
                if ($("#use_ajax")[0].checked == false)
                    return;

                event.preventDefault();  //prevent the actual form post
                hijack(this, update_sessions, "html");
            });
        });

        function hijack(form, callback, format) {
            $("#indicator").show();
            $.ajax({
                url: form.action,
                type: form.method,
                dataType: format,
                data: $(form).serialize(),
                completed: $("#indicator").hide(),
                success: callback
            });
        }

        function update_sessions(result) {
            //clear the form
            $("form.hijax")[0].reset();

            //update the table with the resulting HTML from the server
            $("#session-list").html(result);
            $("#message").hide().html("session added")
                .fadeIn('slow', function() {
                    var e = this;
                    setTimeout(function() { $(e).fadeOut('slow'); }, 2000);
                });
                 
        }
    
    </script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Hijax Technique</h2>
    
    <div style="border: solid 3px tan; background-color: #ffe; padding: 6px; margin: 6px">
        This example shows how you can take a regular, functioning form, and apply some JavaScript to it to make the form submit via AJAX instead.
        When you have JavaScript turned on, you'll see the items be added without a page load.  If you turn JavaScript off, the screen will refresh, but the 
        page continues to work.
    </div>
    
    <h4>Here are the sessions for the conference:</h4>
    
    <span id="message" style="float:right; margin-right: 20px; background-color: #333; color: #eee;"></span>
    
    <div id="session-list">        
        <% Html.RenderPartial("_sessionList"); %>
    </div>

    <p>
    </p>

    <% using(Html.BeginForm("add", "sessions", FormMethod.Post, new {@class="hijax"})) { %>
    <fieldset>
        <legend>Propose new session</legend>
        <label for="title">Title</label>
        <input type="text" name="title" />
        
        <label for="description">Description</label>    
        <textarea name="description" rows="3" cols="30"></textarea>
        
        <label for="level">Level</label>
        <select name="level">
            <option selected="selected" value="100">100</option>
            <option value="200">200</option>
            <option value="300">300</option>
            <option value="400">400</option>        
        </select>
        
        <br />
        <input type="submit" value="Add" />
        <span id="indicator" style="display:none"><img src="../../content/load.gif" alt="loading..." /></span>
    </fieldset>
    
    <% } %>
    
    <label>
        <input type="checkbox" id="use_ajax" />
        Use AJAX?
    </label>

</asp:Content>

