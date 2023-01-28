using System;
using System.IO;

namespace EDSystems.Domain.Entities;

public class S3Object
{
	/// <summary>
	/// Name
	/// </summary>
	public string Name { get; set; } = null!;

    /// <summary>
    /// InputStream
    /// </summary>
    public MemoryStream InputStream { get; set; } = null!;

	/// <summary>
	/// BucketName
	/// </summary>
	public string BucketName { get; set; } = null!;
}

