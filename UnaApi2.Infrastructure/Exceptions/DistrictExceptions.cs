using System;

namespace UnaApi2.Infrastructure.Exceptions
{
    public class DistrictNotFoundException : Exception
    {
        public DistrictNotFoundException() : base($"District no encontrado")
        {
        }
        
        public DistrictNotFoundException(int id) : base($"District con ID {id} no encontrado")
        {
        }
        
        public DistrictNotFoundException(string message) : base(message)
        {
        }
        
        public DistrictNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    
    public class DistrictValidationException : Exception
    {
        public DistrictValidationException(string message) : base(message)
        {
        }
        
        public DistrictValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}