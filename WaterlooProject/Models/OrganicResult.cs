namespace WaterlooProject.Models
{
    public class OrganicResult
    {
        public int Position { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Redirect_Link { get; set; }
        public string Displayed_Link { get; set; }
        public string Favicon { get; set; }
        public string Snippet { get; set; }
        public List<string> Snippet_Highlighted_Words { get; set; }
        public object Sitelinks { get; set; }
        public string Source { get; set; }
    }

}
