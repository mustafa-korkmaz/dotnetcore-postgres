
namespace Common.Response
{
    /// <summary>
    /// abstract response  base class
    /// </summary>
    public class ResponseBase
    {
        public string Code { get; set; }
        public ResponseType Type { get; set; }
    }
}