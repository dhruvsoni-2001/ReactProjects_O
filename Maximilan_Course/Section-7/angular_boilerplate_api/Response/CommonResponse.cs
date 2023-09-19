namespace BoilerPlate.Response
{
    /// <summary>
    /// This Class returns the Common Response of all API
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CommonResponse<T>
    {
        public bool Status { get; set; } = true;
        public string[] Error { get; set; }
        public T Data { get; set; }
    }
}