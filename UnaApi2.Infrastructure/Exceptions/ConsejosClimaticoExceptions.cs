using System;

namespace UnaApi2.Infrastructure.Exceptions
{
    public class ConsejosClimaticoNotFoundException : Exception
    {
        public ConsejosClimaticoNotFoundException() : base($"ConsejosClimatico no encontrado")
        {
        }
        
        public ConsejosClimaticoNotFoundException(int id) : base($"ConsejosClimatico con ID {id} no encontrado")
        {
        }
        
        public ConsejosClimaticoNotFoundException(string message) : base(message)
        {
        }
        
        public ConsejosClimaticoNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    
    public class ConsejosClimaticoValidationException : Exception
    {
        public ConsejosClimaticoValidationException(string message) : base(message)
        {
        }
        
        public ConsejosClimaticoValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}