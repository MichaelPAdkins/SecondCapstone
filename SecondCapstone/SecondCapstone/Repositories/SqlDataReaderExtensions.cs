using System;
using Microsoft.Data.SqlClient;

namespace SecondCapstone.Extensions
{
    public static class SqlDataReaderExtensions
    {
        // This method checks if a column exists in the SqlDataReader
        public static bool HasColumn(this SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
