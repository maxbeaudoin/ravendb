﻿// -----------------------------------------------------------------------
//  <copyright file="ChangesCurrentDatabaseForwardingHandler.cs" company="Hibernating Rhinos LTD">
//      Copyright (c) Hibernating Rhinos LTD. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using System.Web;
using Raven.Abstractions.Util;
using Raven.Database.Server;
using Raven.Database.Server.Abstractions;

namespace Raven.Web
{
	public class ChangesCurrentDatabaseForwardingHandler : IHttpAsyncHandler
	{
		private readonly HttpServer server;

		public ChangesCurrentDatabaseForwardingHandler(HttpServer server)
		{
			this.server = server;
		}

		public Task ProcessRequestAsync(HttpContext context)
		{
			return server.HandleChangesRequest(new HttpContextAdapter(HttpContext.Current, server.Configuration));
		}

		public void ProcessRequest(HttpContext context)
		{
			ProcessRequestAsync(context).Wait();
		}

		public bool IsReusable
		{
			get { return false; }
		}

		public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
		{
			return ProcessRequestAsync(context)
				.ContinueWith(task => cb(task));
		}

		public void EndProcessRequest(IAsyncResult result)
		{
			var task = result as Task;
			if (task != null)
				task.Wait(); // ensure we get proper errors
		}
	}
}