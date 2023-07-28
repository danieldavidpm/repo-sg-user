namespace Common
{
    public class JsonResult<TData>
    {
        public bool Valid { get; set; }
        public string Message { get; set; }
        public List<Error> Detail { get; set; }
        public TData Data { get; set; }
        public bool Warning { get; set; }

        public JsonResult()
        {
        }

        public JsonResult(TData data)
        {
            Valid = true;
            Data = data;
        }

        public JsonResult(bool valid = true, TData data = default, string message = null, List<Error> detail = default)
        {
            Valid = valid;
            Data = data;            
            Message = message;
            Detail = detail;
        }

        public JsonResult(bool valid, string message = null)
        {
            Valid = valid;
            Message = message;
        }
    }
}