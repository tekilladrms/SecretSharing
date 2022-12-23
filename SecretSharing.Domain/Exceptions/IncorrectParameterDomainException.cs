
namespace SecretSharing.Domain.Exceptions
{
    public sealed class IncorrectParameterDomainException<TValue> : DomainException
    {
        public IncorrectParameterDomainException(object parameter) : base($"Incorrect parameter {parameter}. Creation {typeof(TValue)} faled")
        {
        }
    }
}