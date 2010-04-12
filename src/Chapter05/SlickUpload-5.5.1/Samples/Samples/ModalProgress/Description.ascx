<%@ Control Language="C#" %>
<p>
    The SlickUpload progress display is templatable and customizable, meaning it can easily be shown in an AJAX style modal if desired.
    This sample shows a simple modal, but any modal library could be used, including something like jQuery thickbox or the AjaxControlToolkit ModalPopupExtender.
</p>
<p>The simple modal shown here consists of a mask layer and modal container, styled to provide the modal look and feel:</p>
<kw:Source runat="server" Type="Html">
<div id="modal-mask" style="position:absolute;left:0;top:0;right:0;bottom:0;background-color:#000;opacity:.5;filter: alpha(opacity=50);-moz-opacity: .5;"></div>
<div id="modal" style="position:absolute;border:solid 1px #888;width:50%;background-color:#fff;padding:1em">
</kw:Source>
<p>To position the modal, we add a handler to the control that fires when the upload has been started:</p>
<kw:Source runat="server" Type="Html">
<kw:SlickUpload ... OnClientUploadStarted="showProgressModal" ... />
</kw:Source>
<p>In this example, the code in the showProgressModal just positions the simple modal. If you were using a different modal library, this would be where you could invoke the modal dialog to wrap the progress div.</p>
