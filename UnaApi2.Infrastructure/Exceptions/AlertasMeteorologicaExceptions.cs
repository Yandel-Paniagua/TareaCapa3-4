using System;

namespace UnaApi2.Infrastructure.Exceptions
{
    public class AlertasMeteorologicaNotFoundException : Exception
    {
        public AlertasMeteorologicaNotFoundException() : base($"AlertasMeteorologica no encontrado")
        {
        }
        
        public AlertasMeteorologicaNotFoundException(int id) : base($"AlertasMeteorologica con ID {id} no encontrado")
        {
        }
        
        public AlertasMeteorologicaNotFoundException(string message) : base(message)
        {
        }
        
        public AlertasMeteorologicaNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    
    public class AlertasMeteorologicaValidationException : Exception
    {
        public AlertasMeteorologicaValidationException(string message) : base(message)
        {
        }
        
        public AlertasMeteorologicaValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}