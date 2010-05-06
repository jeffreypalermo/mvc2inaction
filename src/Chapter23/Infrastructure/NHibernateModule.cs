using System;
using System.Web;

namespace Infrastructure
{
	public class NHibernateModule : IHttpModule
	{
		private static bool _startupComplete = false;
		private static readonly object _locker = new object();

		public void Init(HttpApplication context)
		{
			context.BeginRequest += context_BeginRequest;
			context.EndRequest += context_EndRequest;
		}

		private void context_BeginRequest(object sender, EventArgs e)
		{
			EnsureStartup();
			new DataConfig().StartSession();
		}

		private void context_EndRequest(object sender, EventArgs e)
		{
			new DataConfig().EndSession();
		}

		private void EnsureStartup()
		{
			if (!_startupComplete)
			{
				lock (_locker)
				{
					if (!_startupComplete)
					{
						new DataConfig().PerformStartup();
						_startupComplete = true;
					}
				}
			}
		}

		public void Dispose()
		{
		}
	}
}