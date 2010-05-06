using System;

namespace Core
{
	public class Visitor
	{
		public virtual Guid Id { get; set; }
		public virtual string PathAndQuerystring { get; set; }
		public virtual string LoginName { get; set; }
		public virtual string Browser { get; set; }
		public virtual DateTime VisitDate { get; set; }
		public virtual string IpAddress { get; set; }
	}
}