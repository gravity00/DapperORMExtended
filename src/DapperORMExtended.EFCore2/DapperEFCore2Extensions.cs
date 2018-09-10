using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using Dapper;
using Microsoft.EntityFrameworkCore.Storage;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore
{
    /// <summary>
    /// Extensions for <see cref="DbContext"/> instances to simplify Dapper integrations.
    /// </summary>
    public static partial class DapperEFCore2Extensions
    {
        private static void ExtractDapperParams(this DbContext context, 
            string commandText, object parameters, int? commandTimeout, CommandType? commandType, CommandFlags flags, CancellationToken ct,
            out DbConnection connection, out CommandDefinition command)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (commandText == null) throw new ArgumentNullException(nameof(commandText));

            connection = context.Database.GetDbConnection();
            command = new CommandDefinition(
                commandText, parameters,
                context.Database.CurrentTransaction?.GetDbTransaction(),
                commandTimeout ?? connection.ConnectionTimeout,
                commandType, flags, ct);
        }
    }
}
