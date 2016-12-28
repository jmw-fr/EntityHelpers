// <copyright file="EntityLogExtensions.cs" company="Weeger Jean-Marc">
// Copyright Weeger Jean-Marc under MIT Licence. See https://opensource.org/licenses/mit-license.php.
// </copyright>

namespace Jmw.EntityHelpers
{
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Text;

    /// <summary>
    /// EntityFramework extensions
    /// </summary>
    public static class EntityLogExtensions
    {
        /// <summary>
        /// Returns a formatted message of the validation error.
        /// </summary>
        /// <param name="err">Validation error</param>
        /// <returns>Formatted message</returns>
        public static string LogMessage(this DbValidationError err)
        {
            return string.Format("[{0} - {1}]", err.PropertyName, err.ErrorMessage);
        }

        /// <summary>
        /// Returns a formatted message from a enumeration of validation errors.
        /// </summary>
        /// <param name="list">Validation errors</param>
        /// <returns>Formatted message</returns>
        public static string LogMessage(this IEnumerable<DbValidationError> list)
        {
            var builder = new StringBuilder();

            foreach (DbValidationError error in list)
            {
                builder.Append("\t");
                builder.Append(error.LogMessage());
            }

            return builder.ToString();
        }

        /// <summary>
        /// Returns a formatted message from <see cref="DbEntityValidationException" />.
        /// </summary>
        /// <param name="exception">Validation exception</param>
        /// <returns>Formatted message</returns>
        public static string LogMessage(this DbEntityValidationException exception)
        {
            var builder = new StringBuilder();

            builder.AppendLine(exception.Message);

            builder.AppendLine(string.Empty);

            foreach (var error in exception.EntityValidationErrors)
            {
                builder.AppendLine(string.Format("\t{0}\r\n\t\t{1}", error, error.ValidationErrors.LogMessage()));
            }

            return builder.ToString();
        }
    }
}
