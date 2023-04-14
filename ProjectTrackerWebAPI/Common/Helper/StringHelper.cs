namespace Project.Common
{
    public static class StringHelper
    {
        public static string RemoveHTTP(string url)
        {
            return url?.Replace("https://", "").Replace("http://", "");
        }

        public static string AddHTTP(string url, bool isSecured = true)
        {
            if (isSecured)
                return "https://" + url;
            else
                return "http://" + url;
        }
    }
}
