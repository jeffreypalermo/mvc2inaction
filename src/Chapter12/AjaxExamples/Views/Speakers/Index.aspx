<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Speaker>>" %>
<%@ Import Namespace="AjaxExamples.Controllers"%>
<%@ Import Namespace="AjaxExamples.Models"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    JSON Example
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="headContent" runat="server">
    <style type="text/css">

        ul.speakers 
        {
        	float: left;
        }

        ul.speakers li a
        {
	        padding: 2px;
	        margin: 2px;
	        display: block;
	        width: 200px;
	        font-weight: bold;
	        font-size: 1.3em;
	        color: #999;
	        text-decoration: none;
	        border: solid 1px transparent;	
        }

        ul.speakers li a:hover
        {	
	        border: solid 1px #aaa;	
	        color: #777;	        
	        background-color: #fff;
        }

        div.speaker-details
        {
	        top: 0px;
	        left: -3px;
        	
	        padding: 3px;
	        position: absolute;
	        border: solid 1px #aaa;
	        margin:0px;
	        margin-left:210px;	
	        z-index: -1;	
        }
        
        div.selected-speaker 
        {
        	border: solid 2px #999; 
        	float: left; 
        	width: 350px;        	
        	margin: 5px;
        	background-color: #eee;        	
        	padding: 10px;
        }
        
        #indicator 
        {
        	position: absolute;
        	top: 10px;
        	right: 10px;
        }
    </style>

    <script src="../../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            $("ul.speakers a").click(function(e) {
                e.preventDefault();                
                show_details(this);
            });
        });

        function show_details(link) {
            var box = $(".selected-speaker");
            $("#indicator").show();

            $(".selected-speaker:visible").fadeOut();                        
            
            var url = link.href.replace(/.html/, ".json");
            
            $.getJSON(url, null, function(data) {
                loadSpeakerDetails(box, data);
            });
        }

        function loadSpeakerDetails(box, speaker) {
            box.html('');
            
            $('<img/>')
                .attr("src", speaker.PictureUrl)
                .attr("alt", "pic")
                .attr("style", "float:left;margin:5px")
                .appendTo(box);
            $('<span/>')
                .attr("style", "font-size: .8em")
                .html(speaker.Bio).appendTo(box);
            $('<br style="clear:both" />').appendTo(box);
            $(box).fadeIn();
            $("#indicator").hide();
        }
        
    </script>
    
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h1>JSON Example</h1>

   <div style="border: solid 3px tan; background-color: #ffe; padding: 6px; margin: 6px">
    This example shows how to retrieve JSON data dynamically from the server.  These links operate normally in the absense of javascript (they take you to another page). 
    The same action is executed in the Ajax case, however this time JSON data is returned from the server instead of HTML.  It can help to use Firebug to see the 
    data coming back from the ajax requests.
   </div>

<h2>Speakers</h2>


<ul class="speakers">
    <% foreach(var speaker in Model) {%>
    <li>
        <%= Html.ActionLink(speaker.FullName, "details", new{urlKey=speaker.UrlKey, format="html"}) %>                
    </li>
    <% } %>
</ul>

<img id="indicator" src="/content/load.gif" alt="loading..." style="display:none" />

<div class="selected-speaker" style="display:none">
</div>

<br style="clear:both" />

</asp:Content>

