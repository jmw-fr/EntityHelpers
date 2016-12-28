// <copyright file="EntityLogExtensionsTests.cs" company="Weeger Jean-Marc">
// Copyright Weeger Jean-Marc under MIT Licence. See https://opensource.org/licenses/mit-license.php.
// </copyright>

namespace Jmw.EntityHelpers.Tests
{
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using Xunit;

    /// <summary>Test of <see cref="EntityLogExtensions" />.</summary>
    public class EntityLogExtensionsTests
    {
        /// <summary>
        /// Test of <see cref="EntityLogExtensions.LogMessage(DbValidationError)" />
        /// </summary>
        /// <param name="propriete">Property name</param>
        /// <param name="message">Validation message</param>
        [Theory]
        [InlineData("Propriete", "Message")]
        public void DbValidationError_LogMessage(string propriete, string message)
        {
            var error = new DbValidationError(propriete, message);

            var log = error.LogMessage();

            Assert.NotNull(log);

            Assert.NotEqual(0, log.Length);

            Assert.Contains(propriete, log);

            Assert.Contains(message, log);
        }

        /// <summary>
        /// Test of <see cref="EntityLogExtensions.LogMessage(DbValidationError)" />
        /// </summary>
        /// <param name="propriete1">Property 1 name</param>
        /// <param name="message1">Validation 1 message</param>
        /// <param name="propriete2">Property 2 name</param>
        /// <param name="message2">Validation 2 message</param>
        [Theory]
        [InlineData("Propriete 1", "Message 1", "Propriete 2", "Message 2")]
        public void IEnumerable_DbValidationError_LogMessage(string propriete1, string message1, string propriete2, string message2)
        {
            var list = new List<DbValidationError>();

            list.Add(new DbValidationError(propriete1, message1));
            list.Add(new DbValidationError(propriete2, message2));

            var log = list.LogMessage();

            Assert.NotNull(log);

            Assert.NotEqual(0, log.Length);

            Assert.Contains(propriete1, log);

            Assert.Contains(message1, log);

            Assert.Contains(propriete2, log);

            Assert.Contains(message2, log);
        }

        /// <summary>
        /// Test of <see cref="EntityLogExtensions.LogMessage(DbValidationError)" />
        /// </summary>
        /// <param name="message">Validation message</param>
        [Theory]
        [InlineData("Message")]
        public void DbEntityValidationException_LogMessage(string message)
        {
            var exception = new DbEntityValidationException(message);

            var log = exception.LogMessage();

            Assert.NotNull(log);

            Assert.NotEqual(0, log.Length);

            Assert.Contains(message, log);
        }
    }
}
