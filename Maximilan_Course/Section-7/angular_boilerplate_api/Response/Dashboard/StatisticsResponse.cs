namespace BoilerPlate.Response.Dashboard
{
    /// <summary>
    ///This Class is used for Statistics Response
    /// </summary>
    public class StatisticsResponse
    {
        public int User { get; set; }
        public int Role { get; set; }
        public int CMS { get; set; }    
        public int EmailTemplate { get; set; }
        public int Product { get; set; }
    }
}