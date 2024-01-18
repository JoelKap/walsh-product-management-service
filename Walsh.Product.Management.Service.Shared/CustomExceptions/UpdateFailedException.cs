namespace Walsh.Product.Management.Service.Shared.CustomExceptions
{
    public class UpdateFailedException : Exception
    {
        public UpdateFailedException() : base("Failed to update the entity.")
        {
        }

        public UpdateFailedException(string message) : base(message)
        {
        }

        public UpdateFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
