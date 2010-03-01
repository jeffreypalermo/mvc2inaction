using System;
using System.Web;
using Core;
using StructureMap;

namespace Website.Rules
{
   public class UnitOfWorkModule : IHttpModule
   {
      public void Init(HttpApplication context)
      {
         context.BeginRequest += context_BeginRequest;
         context.EndRequest += context_EndRequest;
      }

      public void Dispose()
      {
      }

      void context_BeginRequest(object sender, EventArgs e)
      {
         var instance = GetUnitOfWork();
         instance.Begin();
      }

      IUnitOfWork GetUnitOfWork()
      {
         return ObjectFactory.GetInstance<IUnitOfWork>();
      }

      void context_EndRequest(object sender, EventArgs e)
      {
         var instance = GetUnitOfWork();
         try
         {
            instance.Commit();
         }
         catch
         {
            instance.RollBack();
            throw;
         }
      }
   }
}