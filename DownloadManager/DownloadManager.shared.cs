using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Pipes;

namespace DownloadManager
{
    public static partial class DownloadManager
    {
        static HttpClient Client = new HttpClient();

        public static void UseCustomHttpClient(HttpClient client)
        {
            if (client is null)
                throw new ArgumentNullException($"The {nameof(client)} can't be null.");

            Client.Dispose();
            Client = null;
            Client = client;
        }

        public static async Task<string> DownloadAsync(
            string file,
            string url,
            IProgress<double> progress = default(IProgress<double>), 
            CancellationToken token = default(CancellationToken))
        {
            if (!(file.IsValidString() && url.IsValidString()))
                throw new ArgumentNullException($"the {nameof(file)} and {nameof(url)} parameters can't be null.");

            //TODO colocar isso dentro de alguma pasta
            var path = PlataformFolder();

            using (var response = await Client.GetAsync(url,HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Erro in download: {response.StatusCode}");

                var total = response.Content.Headers.ContentLength ?? -1L;

                using (var streamToReadFrom = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    var totalRead = 0L;
                    var buffer = new byte[1024];
                    var isMoreToRead = true;
                    var fileWriteTo = Path.Combine(path, file);
                    var output = new FileStream(fileWriteTo, FileMode.Create);
                    do
                    {
                        token.ThrowIfCancellationRequested();

                        var read = await streamToReadFrom.ReadAsync(buffer, 0, buffer.Length, token);

                        if (read == 0)
                            isMoreToRead = false;

                        else
                        {
                            var data = new byte[read];
                            buffer.ToList().CopyTo(0, data, 0, read);

                            await output.WriteAsync(buffer, 0, read);

                            totalRead += read;

                            progress.Report((totalRead * 1d) / (total * 1d) * 100);
                        }

                    } while (isMoreToRead);

                    output.Close();
                    return fileWriteTo;
                }
            }
        }
    }
}
