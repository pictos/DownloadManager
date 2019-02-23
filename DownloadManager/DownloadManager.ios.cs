using System;
using System.IO;

namespace DownloadManager
{
    static partial class DownloadManager
    {
        static string PlataformFolder()
        {
            var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return Path.Combine(docsPath, "..", "Library");
        }
    }
}
