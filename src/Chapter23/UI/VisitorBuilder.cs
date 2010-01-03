using System;
using System.Web;
using Core;

namespace UI
{
	public class VisitorBuilder
	{
		private readonly HttpRequestBase _httpRequest;
		private readonly DateTime _currentDate;

		public VisitorBuilder(HttpRequestBase httpRequest, DateTime currentDate)
		{
			_httpRequest = httpRequest;
			_currentDate = currentDate;
		}

		public VisitorBuilder() : this(
			new HttpContextWrapper(HttpContext.Current).Request, DateTime.Now)
		{
		}

		public Visitor BuildVisitor()
		{
			var visitor = new Visitor
    		{
    			PathAndQuerystring = _httpRequest.Url.PathAndQuery,
    			Browser = _httpRequest.UserAgent,
    			IpAddress = _httpRequest.UserHostAddress,
    			LoginName = _httpRequest.LogonUserIdentity.Name,
    			VisitDate = _currentDate
    		};
			return visitor;
		}
	}
}