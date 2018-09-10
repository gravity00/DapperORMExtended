using System;
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
        /// Executes a command in the database, using the context connection and current transaction, if any.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <param name="behavior">Optional command behavior.</param>
        /// <returns>A task to be awaited for the command result.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<IDataReader> RawExecuteReaderAsync(this DbContext context, CancellationToken ct, string commandText,
            object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered,
            CommandBehavior behavior = CommandBehavior.Default)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, ct,
                out var connection, out var command);

            return connection.ExecuteReaderAsync(command, behavior);
        }

        /// <summary>
        /// Executes a command in the database, using the context connection and current transaction, if any.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <param name="behavior">Optional command behavior.</param>
        /// <returns>The command result.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IDataReader RawExecuteReader(this DbContext context, string commandText,
            object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered,
            CommandBehavior behavior = CommandBehavior.Default)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, CancellationToken.None, 
                out var connection, out var command);

            return connection.ExecuteReader(command, behavior);
        }
    }
}
