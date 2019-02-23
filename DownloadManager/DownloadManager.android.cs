namespace DownloadManager
{
    static partial class DownloadManager
    {
        static string PlataformFolder() =>
            Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).Path;
    }
}
