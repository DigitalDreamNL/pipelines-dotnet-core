using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;
using Survey_Sender.Models;

namespace Survey_Sender
{
    public static class TableStorageHelper
    {
        private static CloudStorageAccount storageAccount = new CloudStorageAccount(
            new StorageCredentials("storageautomaticsurvey", "ufoyKoszGYhBit29BzJz/Sh7vQQ0Rm0RUWOewR7ap63y2C9+cqzZKT4rl26hlIYMvxPGzV6dDeOoxCJ0U5LlRA=="), true);

        public static void SendRecords<T>(string tableName, List<T> records) where T : TableEntity
        {
            var table = GetTable(tableName);
            foreach (var record in records)
            {
                TableOperation insertOrReplace = TableOperation.InsertOrReplace(record);
                table.ExecuteAsync(insertOrReplace);
            }
        }

        public static List<QuestionRecord> GetRecords(string tableName)
        {
            var table = GetTable(tableName);
            return table.ExecuteQuery(new TableQuery<QuestionRecord>()).ToList();
        }

        public static List<QuestionRecord> GetRecords(string tableName, DateTime start, DateTime end)
        {
            var table = GetTable(tableName);
            List<QuestionRecord> recordList = table.ExecuteQuery(new TableQuery<QuestionRecord>()).ToList();

            if (recordList.Count > 0)
            {
                return recordList.Where(a => a.Timestamp >= start && a.Timestamp <= end).ToList();
            }
            return null;
        }

        private static CloudTable GetTable(string tableName)
        {
            var client = storageAccount.CreateCloudTableClient();
            return client.GetTableReference(tableName);
        }
    }
}
