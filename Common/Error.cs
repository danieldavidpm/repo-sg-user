namespace Common
{
    public class Error
    {
        public string Message { get; set; }
        public bool IsValid { get; set; }
    }

    public class ErrorAccumulator
    {
        private List<Error> errors = new List<Error>();

        public void AddError(string errorMessage)
        {
            Error error = new Error { Message = errorMessage };
            errors.Add(error);
        }

        public List<Error> GetErrors()
        {
            return errors;
        }
    }
}
