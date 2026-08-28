using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataAccess
{
    public class GenericResponse<T>
    {
        public bool Result { get; set; }
        public string? ErrorMessage { get; set; }
        public T? Data { get; set; }


        // Métodos estáticos de conveniencia para instanciar respuestas rápidamente
        public static GenericResponse<T> Success(T data)
        {
            return new GenericResponse<T>
            {
                Result = true,
                Data = data,
                ErrorMessage = null
            };
        }

        public static GenericResponse<T> Fail(string errorMessage)
        {
            return new GenericResponse<T>
            {
                Result = false,
                Data = default,
                ErrorMessage = errorMessage
            };
        }
    }
}
