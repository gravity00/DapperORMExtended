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
        /// Executes a query in the database, using the context connection and current transaction, if any,
        /// and maps the results into a single collection.
        /// </summary>
        /// <typeparam name="TFirst">The first type</typeparam>
        /// <typeparam name="TSecond">The second type</typeparam>
        /// <typeparam name="TReturn">The return type</typeparam>
        /// <param name="context">The database context.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="map">The mapper function</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <returns>A task to be awaited for the collection of items TReturn.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<IEnumerable<TReturn>> RawQueryAsync<TFirst, TSecond, TReturn>(
            this DbContext context, CancellationToken ct, string commandText, Func<TFirst, TSecond, TReturn> map, 
            string splitOn = "Id", object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, ct,
                out var connection, out var command);

            return connection.QueryAsync(command, map, splitOn);
        }

        /// <summary>
        /// Executes a query in the database, using the context connection and current transaction, if any,
        /// and maps the results into a single collection.
        /// </summary>
        /// <typeparam name="TFirst">The first type</typeparam>
        /// <typeparam name="TSecond">The second type</typeparam>
        /// <typeparam name="TThird">The third type</typeparam>
        /// <typeparam name="TReturn">The return type</typeparam>
        /// <param name="context">The database context.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="map">The mapper function</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <returns>A task to be awaited for the collection of items TReturn.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<IEnumerable<TReturn>> RawQueryAsync<TFirst, TSecond, TThird, TReturn>(
            this DbContext context, CancellationToken ct, string commandText, Func<TFirst, TSecond, TThird, TReturn> map, 
            string splitOn = "Id", object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, ct,
                out var connection, out var command);

            return connection.QueryAsync(command, map, splitOn);
        }

        /// <summary>
        /// Executes a query in the database, using the context connection and current transaction, if any,
        /// and maps the results into a single collection.
        /// </summary>
        /// <typeparam name="TFirst">The first type</typeparam>
        /// <typeparam name="TSecond">The second type</typeparam>
        /// <typeparam name="TThird">The third type</typeparam>
        /// <typeparam name="TFourth">The fourth type</typeparam>
        /// <typeparam name="TReturn">The return type</typeparam>
        /// <param name="context">The database context.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="map">The mapper function</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <returns>A task to be awaited for the collection of items TReturn.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<IEnumerable<TReturn>> RawQueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(
            this DbContext context, CancellationToken ct, string commandText, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, 
            string splitOn = "Id", object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, ct,
                out var connection, out var command);

            return connection.QueryAsync(command, map, splitOn);
        }

        /// <summary>
        /// Executes a query in the database, using the context connection and current transaction, if any,
        /// and maps the results into a single collection.
        /// </summary>
        /// <typeparam name="TFirst">The first type</typeparam>
        /// <typeparam name="TSecond">The second type</typeparam>
        /// <typeparam name="TThird">The third type</typeparam>
        /// <typeparam name="TFourth">The fourth type</typeparam>
        /// <typeparam name="TFifth">The fifth type</typeparam>
        /// <typeparam name="TReturn">The return type</typeparam>
        /// <param name="context">The database context.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="map">The mapper function</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <returns>A task to be awaited for the collection of items TReturn.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<IEnumerable<TReturn>> RawQueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
            this DbContext context, CancellationToken ct, string commandText, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, 
            string splitOn = "Id", object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, ct,
                out var connection, out var command);

            return connection.QueryAsync(command, map, splitOn);
        }

        /// <summary>
        /// Executes a query in the database, using the context connection and current transaction, if any,
        /// and maps the results into a single collection.
        /// </summary>
        /// <typeparam name="TFirst">The first type</typeparam>
        /// <typeparam name="TSecond">The second type</typeparam>
        /// <typeparam name="TThird">The third type</typeparam>
        /// <typeparam name="TFourth">The fourth type</typeparam>
        /// <typeparam name="TFifth">The fifth type</typeparam>
        /// <typeparam name="TSixth">The sixth type</typeparam>
        /// <typeparam name="TReturn">The return type</typeparam>
        /// <param name="context">The database context.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="map">The mapper function</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <returns>A task to be awaited for the collection of items TReturn.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<IEnumerable<TReturn>> RawQueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
            this DbContext context, CancellationToken ct, string commandText, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, 
            string splitOn = "Id", object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, ct,
                out var connection, out var command);

            return connection.QueryAsync(command, map, splitOn);
        }

        /// <summary>
        /// Executes a query in the database, using the context connection and current transaction, if any,
        /// and maps the results into a single collection.
        /// </summary>
        /// <typeparam name="TFirst">The first type</typeparam>
        /// <typeparam name="TSecond">The second type</typeparam>
        /// <typeparam name="TThird">The third type</typeparam>
        /// <typeparam name="TFourth">The fourth type</typeparam>
        /// <typeparam name="TFifth">The fifth type</typeparam>
        /// <typeparam name="TSixth">The sixth type</typeparam>
        /// <typeparam name="TSeventh">The seventh type</typeparam>
        /// <typeparam name="TReturn">The return type</typeparam>
        /// <param name="context">The database context.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="map">The mapper function</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <returns>A task to be awaited for the collection of items TReturn.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<IEnumerable<TReturn>> RawQueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
            this DbContext context, CancellationToken ct, string commandText, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, 
            string splitOn = "Id", object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, ct,
                out var connection, out var command);

            return connection.QueryAsync(command, map, splitOn);
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

        /// <summary>
        /// Executes a query in the database, using the context connection and current transaction, if any,
        /// and maps the results into a single collection.
        /// </summary>
        /// <typeparam name="TFirst">The first type</typeparam>
        /// <typeparam name="TSecond">The second type</typeparam>
        /// <typeparam name="TReturn">The return type</typeparam>
        /// <param name="context">The database context.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="map">The mapper function</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <returns>The collection of items TReturn.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<TReturn> RawQuery<TFirst, TSecond, TReturn>(
            this DbContext context, string commandText, Func<TFirst, TSecond, TReturn> map,
            string splitOn = "Id", object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, CancellationToken.None, 
                out var connection, out var command);

            return connection.Query(
                command.CommandText, map, command.Parameters, command.Transaction, command.Buffered, splitOn,
                command.CommandTimeout, command.CommandType);
        }

        /// <summary>
        /// Executes a query in the database, using the context connection and current transaction, if any,
        /// and maps the results into a single collection.
        /// </summary>
        /// <typeparam name="TFirst">The first type</typeparam>
        /// <typeparam name="TSecond">The second type</typeparam>
        /// <typeparam name="TThird">The third type</typeparam>
        /// <typeparam name="TReturn">The return type</typeparam>
        /// <param name="context">The database context.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="map">The mapper function</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <returns>The collection of items TReturn.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<TReturn> RawQuery<TFirst, TSecond, TThird, TReturn>(
            this DbContext context, string commandText, Func<TFirst, TSecond, TThird, TReturn> map,
            string splitOn = "Id", object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, CancellationToken.None, 
                out var connection, out var command);

            return connection.Query(
                command.CommandText, map, command.Parameters, command.Transaction, command.Buffered, splitOn,
                command.CommandTimeout, command.CommandType);
        }

        /// <summary>
        /// Executes a query in the database, using the context connection and current transaction, if any,
        /// and maps the results into a single collection.
        /// </summary>
        /// <typeparam name="TFirst">The first type</typeparam>
        /// <typeparam name="TSecond">The second type</typeparam>
        /// <typeparam name="TThird">The third type</typeparam>
        /// <typeparam name="TFourth">The fourth type</typeparam>
        /// <typeparam name="TReturn">The return type</typeparam>
        /// <param name="context">The database context.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="map">The mapper function</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <returns>The collection of items TReturn.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<TReturn> RawQuery<TFirst, TSecond, TThird, TFourth, TReturn>(
            this DbContext context, string commandText, Func<TFirst, TSecond, TThird, TFourth, TReturn> map,
            string splitOn = "Id", object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, CancellationToken.None, 
                out var connection, out var command);

            return connection.Query(
                command.CommandText, map, command.Parameters, command.Transaction, command.Buffered, splitOn,
                command.CommandTimeout, command.CommandType);
        }

        /// <summary>
        /// Executes a query in the database, using the context connection and current transaction, if any,
        /// and maps the results into a single collection.
        /// </summary>
        /// <typeparam name="TFirst">The first type</typeparam>
        /// <typeparam name="TSecond">The second type</typeparam>
        /// <typeparam name="TThird">The third type</typeparam>
        /// <typeparam name="TFourth">The fourth type</typeparam>
        /// <typeparam name="TFifth">The fifth type</typeparam>
        /// <typeparam name="TReturn">The return type</typeparam>
        /// <param name="context">The database context.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="map">The mapper function</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <returns>The collection of items TReturn.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<TReturn> RawQuery<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
            this DbContext context, string commandText, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map,
            string splitOn = "Id", object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, CancellationToken.None, 
                out var connection, out var command);

            return connection.Query(
                command.CommandText, map, command.Parameters, command.Transaction, command.Buffered, splitOn,
                command.CommandTimeout, command.CommandType);
        }

        /// <summary>
        /// Executes a query in the database, using the context connection and current transaction, if any,
        /// and maps the results into a single collection.
        /// </summary>
        /// <typeparam name="TFirst">The first type</typeparam>
        /// <typeparam name="TSecond">The second type</typeparam>
        /// <typeparam name="TThird">The third type</typeparam>
        /// <typeparam name="TFourth">The fourth type</typeparam>
        /// <typeparam name="TFifth">The fifth type</typeparam>
        /// <typeparam name="TSixth">The sixth type</typeparam>
        /// <typeparam name="TReturn">The return type</typeparam>
        /// <param name="context">The database context.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="map">The mapper function</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <returns>The collection of items TReturn.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<TReturn> RawQuery<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
            this DbContext context, string commandText, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map,
            string splitOn = "Id", object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, CancellationToken.None, 
                out var connection, out var command);

            return connection.Query(
                command.CommandText, map, command.Parameters, command.Transaction, command.Buffered, splitOn,
                command.CommandTimeout, command.CommandType);
        }

        /// <summary>
        /// Executes a query in the database, using the context connection and current transaction, if any,
        /// and maps the results into a single collection.
        /// </summary>
        /// <typeparam name="TFirst">The first type</typeparam>
        /// <typeparam name="TSecond">The second type</typeparam>
        /// <typeparam name="TThird">The third type</typeparam>
        /// <typeparam name="TFourth">The fourth type</typeparam>
        /// <typeparam name="TFifth">The fifth type</typeparam>
        /// <typeparam name="TSixth">The sixth type</typeparam>
        /// <typeparam name="TSeventh">The seventh type</typeparam>
        /// <typeparam name="TReturn">The return type</typeparam>
        /// <param name="context">The database context.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="map">The mapper function</param>
        /// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
        /// <param name="parameters">Optional query parameters.</param>
        /// <param name="commandTimeout">Optional command timeout. If null, the connection timeout will be used.</param>
        /// <param name="commandType">Optional command type.</param>
        /// <param name="flags">Optional command flags.</param>
        /// <returns>The collection of items TReturn.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<TReturn> RawQuery<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
            this DbContext context, string commandText, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map,
            string splitOn = "Id", object parameters = null, int? commandTimeout = null, CommandType? commandType = null, CommandFlags flags = CommandFlags.Buffered)
        {
            context.ExtractDapperParams(
                commandText, parameters, commandTimeout, commandType, flags, CancellationToken.None, 
                out var connection, out var command);

            return connection.Query(
                command.CommandText, map, command.Parameters, command.Transaction, command.Buffered, splitOn,
                command.CommandTimeout, command.CommandType);
        }
    }
}