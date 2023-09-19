namespace BoilerPlate.Response
{
    /// <summary>
    /// This Class is used for Getting repsone with total records count
    /// </summary>

    public class BaseTotalRecordResponse<T>
    {
        public int RecordsTotal { get; set; }

        public List<T> Response { get; set; }
    }
}
