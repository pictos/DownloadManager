# DownloadManager

Download manager plugin to Xamarin.


|Service  | Status |
|---------|---------|
|AzureDevops  |[![Build status](https://pictos.visualstudio.com/DownloadManager/_apis/build/status/DownloadManager-CI)](https://pictos.visualstudio.com/DownloadManager/_build/latest?definitionId=5) |
|Nuget| [![NuGet](https://img.shields.io/nuget/vpre/DownloadManager.svg?label=NuGet)](https://www.nuget.org/packages/DownloadManager) |


## Usage

Actually the file is save in static folder, for next version this gonna be changed. This method returns the path where the file will be  saved.

```csharp
 
 Progress<double> progress = new Progress<double>();
 
 var path = await DownloadManager.DownloadManager.DownloadAsync("teste.jpg", "https://upload.wikimedia.org/wikipedia/commons/2/2d/Snake_River_%285mb%29.jpg", progress);

```

The progress shows the percentagem proccess of download. Juss assing the event, and read the `e` argument.

```csharp
void Progress_ProgressChanged(object sender, double e)
{
    proglbl.Text = e.ToString();
}
```
