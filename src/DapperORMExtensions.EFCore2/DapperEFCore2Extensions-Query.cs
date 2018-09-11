using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Dapper;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore
{
    public static partial class DapperEFCore2Extensions
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
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<IEnumerable<T>> RawQueryAsync<T>(this DbContext context, CancellationToken ct, string commandText,
            object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, ct,
                out var connection, out var command);

            return connection.QueryAsync<T>(command);
        }

        /// <summary>
        /// Executes a query in the database, using the context connection and current transaction, if any.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <param name="type">The type to return.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <returns>A task to be awaited for the collection of items T.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<IEnumerable<object>> RawQueryAsync(this DbContext context, CancellationToken ct, Type type, string commandText,
            object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, ct,
                out var connection, out var command);

            return connection.QueryAsync(type, command);
        }

        /// <summary>
        /// Executes a query in the database, using the context connection and current transaction, if any.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <returns>A task to be awaited for the collection of items T.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<IEnumerable<dynamic>> RawQueryAsync(this DbContext context, CancellationToken ct, string commandText,
            object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, ct,
                out var connection, out var command);

            return connection.QueryAsync(command);
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
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<T> RawQuery<T>(this DbContext context, string commandText,
            object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, CancellationToken.None,
                out var connection, out var command);

            return connection.Query<T>(command);
        }

        /// <summary>
        /// Executes a query in the database, using the context connection and current transaction, if any.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="type">The type to return.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <returns>The collection of items T.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<object> RawQuery(this DbContext context, Type type, string commandText,
            object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, CancellationToken.None,
                out var connection, out var command);

            return connection.Query(type, command.CommandText,
                command.Parameters, command.Transaction, command.Buffered, command.CommandTimeout, command.CommandType);
        }

        /// <summary>
        /// Executes a query in the database, using the context connection and current transaction, if any.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <returns>The collection of items T.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<dynamic> RawQuery(this DbContext context, string commandText,
            object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, CancellationToken.None,
                out var connection, out var command);

            return connection.Query(command.CommandText,
                command.Parameters, command.Transaction, command.Buffered, command.CommandTimeout, command.CommandType);
        }
    }
}