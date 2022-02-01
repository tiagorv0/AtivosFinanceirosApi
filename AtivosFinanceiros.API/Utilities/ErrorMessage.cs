using System.Collections.Generic;

namespace AtivosFinanceiros.API.Utilities
{
    public static class ErrorMessage
    {
        public static string DomainError(string message)
        {
            return message;
        }

        public static object DomainError(string message, IReadOnlyCollection<string> erros)
        {
            return new
            {
                message,
                erros
            };
        }

        public static string InternalError()
        {
            return "Erro Interno";
        }
    }
}
