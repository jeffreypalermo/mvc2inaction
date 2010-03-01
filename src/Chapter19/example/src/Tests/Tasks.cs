using System;
using System.IO;
using NUnit.Framework;

namespace Tests
{
   public class Tasks
   {
      public void DeleteStorageYam()
      {
         if (File.Exists(@"..\..\..\Website\App_Data\storage.yam"))
         {
            File.Delete(@"..\..\..\Website\App_Data\storage.yam");
            Console.WriteLine("Deleted File");
         }

         Assert.That(!File.Exists(@"..\..\..\Website\App_Data\storage.yam"));
      }
   }
}