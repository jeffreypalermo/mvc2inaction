<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="head" ContentPlaceHolderID="headContent" runat="server">
    <script type="text/javascript">
        function getXmlHttpRequest() {
            var xhr;
            //check for IE implementation(s)
            if (typeof ActiveXObject != 'undefined') {
                try {
                    xhr = new ActiveXObject("Msxml2.XMLHTTP");
                } catch (e) {
                    xhr = new ActiveXObject("Microsoft.XMLHTTP");
                }
            } else if (XMLHttpRequest) {
                //this works for Firefox, Safari, Opera
                xhr = new XMLHttpRequest();
            } else {
                alert("Sorry, your browser doesn't support ajax");
            }

            return xhr;
        }

        function getMessage() {
            //get our xml http request object
            var xhr = getXmlHttpRequest();

            //prepare the request
            xhr.open("GET", "get_message.html", true)

            //setup the callback function
            xhr.onreadystatechange = function() {
	            //readyState 4 means we're done
	            if(xhr.readyState != 4) return;

	            //populate the page with the result
	            document.getElementById('result').innerHTML = xhr.responseText;
            };

            //fire our request
            xhr.send(null);
        }
    </script>
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Custom Ajax</h2>
    <p>
        This sample doesn't use any features of ASP.NET MVC or any javascript library.  It simply references a javascript file (scripts/custom_ajax.js) in order to
        fire off the ajax request.
    </p>
    <p><strong>Click the button to issue an ajax request to the server: </strong>
        <button type="button" onclick="getMessage()">Get the Message</button>
    </p>
    <div id="result"></div>
</asp:Content>
