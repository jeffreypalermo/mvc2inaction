using System;
using System.Data;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using ICSharpCode.SharpZipLib.Zip;

using Krystalware.SlickUpload;
using Krystalware.SlickUpload.Providers;
using Krystalware.SlickUpload.Configuration;

namespace SamplesCS.CustomUploadStreamProvider
{
	/// <summary>
	/// An <see cref="IUploadStreamProvider" /> that streams each file into its own .zip file.
	/// </summary>
	public class ZipUploadStreamProvider : UploadStreamProviderBase
	{
		/// <summary>
		/// The <see cref="UploadedFile.LocationInfo" /> key used to store the server filename value.
		/// </summary>
		public const string FileNameKey = "fileName";

		public override Stream GetInputStream(UploadedFile file)
		{
			FileStream fileS = null;
			ZipInputStream zipS = null;

			try
			{
				string path = GetZipPath(file);

				fileS = File.OpenRead(path);
				zipS = new ZipInputStream(fileS);

				zipS.GetNextEntry();

				return zipS;
			}
			catch
			{
				if (fileS != null)
					fileS.Close();

				if (zipS != null)
					zipS.Close();

				return null;
			}
		}

		public override Stream GetOutputStream(UploadedFile file)
		{
			FileStream fileS = null;
			ZipOutputStream zipS = null;

			try
			{
				string outputPath = GetZipPath(file);

				Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

				fileS = File.OpenWrite(outputPath);
				zipS = new ZipOutputStream(fileS);

				zipS.SetLevel(5);

				zipS.PutNextEntry(new ZipEntry(file.ClientName));

				file.LocationInfo[FileNameKey] = outputPath;

				return zipS;
			}
			catch
			{
				if (fileS != null)
					fileS.Close();

				if (zipS != null)
					zipS.Close();

				return null;
			}
		}

		public override void RemoveOutput(UploadedFile file)
		{
			string path = GetZipPath(file);

			if (File.Exists(path))
				File.Delete(path);
		}

		string GetZipPath(UploadedFile file)
		{
			string location = SlickUploadConfiguration.UploadStreamProvider["location"];

			if (location == null || location.Length == 0)
				location = "~/Files/";

			return Path.Combine(HttpContext.Current.Server.MapPath(location), Path.GetFileNameWithoutExtension(file.ClientName) + ".zip");
		}
	}
}