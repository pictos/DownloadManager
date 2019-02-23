using Windows.Storage;

namespace DownloadManager
{
    static partial class DownloadManager
    {
        static string PlataformFolder()
        {
            string localfolder = ApplicationData.Current.LocalFolder.Path;
            return localfolder;
        }
    }
}
