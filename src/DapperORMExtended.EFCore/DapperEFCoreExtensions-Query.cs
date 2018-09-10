using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Dapper;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore
{
    public static partial class DapperEFCoreExtensions
    {
        /// <summary>
        /// Executes a query in the database, using the context connection and current transaction, if any.
        /// </summary>
        /// <typeparam name="T">The type to return.</typeparam>
        /// <param name="context">The database context.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <returns>A task to be awaited for the collection of items T.</returns>
        public static Task<IEnumerable<T>> RawQueryAsync<T>(this DbContext context, CancellationToken ct, string commandText,
            object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(commandTimeout, out var connection, out var transaction, out var timeout);

            return connection.QueryAsync<T>(
                new CommandDefinition(commandText, parameters, transaction, timeout, commandType, flags, ct));
        }

        /// <summary>
        /// Executes a query in the database, using the context connection and current transaction, if any.
        /// </summary>
        /// <typeparam name="T">The type to return.</typeparam>
        /// <param name="context">The database context.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <returns>The collection of items T.</returns>
        public static IEnumerable<T> RawQuery<T>(this DbContext context, string commandText,
            object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(commandTimeout, out var connection, out var transaction, out var timeout);

            return connection.Query<T>(
                new CommandDefinition(commandText, parameters, transaction, timeout, commandType, flags, CancellationToken.None));
        }
    }
}