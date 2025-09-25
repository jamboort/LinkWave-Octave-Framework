using Azure;
using Azure.Storage.Files.Shares;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace lc_octvmarsh
{
    public static class AzureFileShareUploader
    {
        /// <summary>
        /// Uploads text content as a file to an Azure File Share.
        /// </summary>
        /// <param name="connectionString">Storage account connection string (use environment var or config).</param>
        /// <param name="shareName">File share name.</param>
        /// <param name="directoryPath">Directory inside the share (can be null or empty for root).</param>
        /// <param name="fileName">File name to create.</param>
        /// <param name="content">UTF-8 text content to upload.</param>
        public static async Task UploadTextAsync(string connectionString, string shareName, string directoryPath, string fileName, string content)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentException("connectionString is required", nameof(connectionString));
            if (string.IsNullOrWhiteSpace(shareName)) throw new ArgumentException("shareName is required", nameof(shareName));
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentException("fileName is required", nameof(fileName));

            ShareClient shareClient = new ShareClient(connectionString, shareName);
            await shareClient.CreateIfNotExistsAsync();

            ShareDirectoryClient directoryClient;
            if (string.IsNullOrEmpty(directoryPath))
            {
                directoryClient = shareClient.GetRootDirectoryClient();
            }
            else
            {
                directoryClient = shareClient.GetDirectoryClient(directoryPath);
                await directoryClient.CreateIfNotExistsAsync();
            }

            ShareFileClient fileClient = directoryClient.GetFileClient(fileName);
            byte[] bytes = Encoding.UTF8.GetBytes(content ?? string.Empty);

            using (var ms = new MemoryStream(bytes))
            {
                // Create the file with size
                await fileClient.CreateAsync(bytes.Length);
                // Upload the entire range starting at 0
                await fileClient.UploadRangeAsync(new HttpRange(0, bytes.Length), ms);
            }
        }
    }
}

