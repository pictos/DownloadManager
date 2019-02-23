namespace DownloadManager
{
    public static class Extentions
    {
        public static bool IsNullOrEmpty(this string s) => string.IsNullOrEmpty(s);
        public static bool IsNullOrWhiteSpaces(this string s) => string.IsNullOrWhiteSpace(s);

        public static bool IsValidString(this string s) => !(IsNullOrEmpty(s) && IsNullOrWhiteSpaces(s));
    }
}
