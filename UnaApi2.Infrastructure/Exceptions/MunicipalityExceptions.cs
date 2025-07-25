using System;

namespace UnaApi2.Infrastructure.Exceptions
{
    public class MunicipalityNotFoundException : Exception
    {
        public MunicipalityNotFoundException() : base($"Municipality no encontrado")
        {
        }
        
        public MunicipalityNotFoundException(int id) : base($"Municipality con ID {id} no encontrado")
        {
        }
        
        public MunicipalityNotFoundException(string message) : base(message)
        {
        }
        
        public MunicipalityNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    
    public class MunicipalityValidationException : Exception
    {
        public MunicipalityValidationException(string message) : base(message)
        {
        }
        
        public MunicipalityValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}