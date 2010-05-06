﻿using System;
using System.IO;

using Krystalware.SlickUpload;
using Krystalware.SlickUpload.Providers;

namespace SamplesCS.FileNameGenerator
{
	/// <summary>
	/// An <see cref="IFileNameGenerator" /> that puts each file into a folder named for the first character
	/// in the file name.
	/// </summary>
	public class PrefixFolderFileNameGenerator : IFileNameGenerator
	{
		public string GenerateFileName(UploadedFile file)
		{
			return Path.Combine(file.ClientName.Substring(0, 1), file.ClientName);
		}
	}
}