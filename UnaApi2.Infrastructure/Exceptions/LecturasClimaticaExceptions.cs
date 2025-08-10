using System;

namespace UnaApi2.Infrastructure.Exceptions
{
    public class LecturasClimaticaNotFoundException : Exception
    {
        public LecturasClimaticaNotFoundException() : base($"LecturasClimatica no encontrado")
        {
        }
        
        public LecturasClimaticaNotFoundException(int id) : base($"LecturasClimatica con ID {id} no encontrado")
        {
        }
        
        public LecturasClimaticaNotFoundException(string message) : base(message)
        {
        }
        
        public LecturasClimaticaNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    
    public class LecturasClimaticaValidationException : Exception
    {
        public LecturasClimaticaValidationException(string message) : base(message)
        {
        }
        
        public LecturasClimaticaValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}