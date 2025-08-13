namespace BO
{
    [Serializable]
    public class BlDoesNotExistException : Exception//הישות לא נמצאת
    {
        public BlDoesNotExistException(string? message) : base(message) { }
        public BlDoesNotExistException(string message, Exception innerException)
                    : base(message, innerException) { }
    }

    public class BlDoesExistException : Exception//הישות  נמצאת
    {
        public BlDoesExistException(string? message) : base(message) { }
        public BlDoesExistException(string message, Exception innerException)
                    : base(message, innerException) { }
    }
    public class BlInvalidInputException : Exception//קלט לא תקין
    {
        public BlInvalidInputException(string? message) : base(message) { }
        public BlInvalidInputException(string message, Exception innerException)
                    : base(message, innerException) { }
    }

}
