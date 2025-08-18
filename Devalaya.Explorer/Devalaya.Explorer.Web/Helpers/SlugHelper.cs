namespace Devalaya.Explorer.Web.Helpers
{
    public static class SlugHelper
    {
        public static string GenerateSlug(string phrase)
        {
            string str = phrase.ToLower();
            str = System.Text.RegularExpressions.Regex.Replace(str, @"[^a-z0-9\s-]", ""); 
            str = System.Text.RegularExpressions.Regex.Replace(str, @"\s+", " ").Trim();    
            str = str.Replace(" ", "-");                                                    
            return str;
        }
    }

}
