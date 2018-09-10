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
        /// Executes a command in the database that returns a single value, using the context connection and current transaction, if any.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <returns>A task to be awaited for the command result.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<object> RawExecuteScalarAsync(this DbContext context, CancellationToken ct, string commandText,
            object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, ct,
                out var connection, out var command);

            return connection.ExecuteScalarAsync(command);
        }

        /// <summary>
        /// Executes a command in the database that returns a single value, using the context connection and current transaction, if any.
        /// </summary>
        /// <typeparam name="T">The type to return.</typeparam>
        /// <param name="context">The database context.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <returns>A task to be awaited for the command result.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<T> RawExecuteScalarAsync<T>(this DbContext context, CancellationToken ct, string commandText,
            object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, ct,
                out var connection, out var command);

            return connection.ExecuteScalarAsync<T>(command);
        }

        /// <summary>
        /// Executes a command in the database that returns a single value, using the context connection and current transaction, if any.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <returns>The command result.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static object RawExecuteScalar(this DbContext context, string commandText,
            object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, CancellationToken.None, 
                out var connection, out var command);

            return connection.ExecuteScalar(command);
        }

        /// <summary>
        /// Executes a command in the database that returns a single value, using the context connection and current transaction, if any.
        /// </summary>
        /// <typeparam name="T">The type to return.</typeparam>
        /// <param name="context">The database context.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <returns>The command result.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T RawExecuteScalar<T>(this DbContext context, string commandText,
            object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, CancellationToken.None, 
                out var connection, out var command);

            return connection.ExecuteScalar<T>(command);
        }
    }
}
