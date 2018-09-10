using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Storage;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore
{
    /// <summary>
    /// Extensions for <see cref="DbContext"/> instances to simplify Dapper integrations.
    /// </summary>
    public static partial class DapperEFCoreExtensions
    {
        private static void ExtractDapperParams(this DbContext context, int? commandTimeout, 
            out DbConnection connection, out DbTransaction transaction, out int timeout)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            connection = context.Database.GetDbConnection();
            transaction = context.Database.CurrentTransaction?.GetDbTransaction();
            timeout = commandTimeout ?? connection.ConnectionTimeout;
        }
    }
}
