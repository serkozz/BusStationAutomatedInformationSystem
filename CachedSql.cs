using System;
using Npgsql;

namespace BusStationAutomatedInformationSystem
{
    public class CachedSql
    {
        public string KeySentence { get; }
        public string SQL { get; }

        public CachedSql(string keySentence, string sql)
        {
            KeySentence = keySentence;
            SQL = sql;
        }

        public CachedSql(string str, bool isStringAKeySentence)
        {
            if (isStringAKeySentence)
            {
                KeySentence = str;
                SQL = GetCachedSqlByKeySentence();
            }
            else
            {
                SQL = str;
                KeySentence = GetCachedSqlKeySentenceBySQLString();
            }
        }

        private string GetCachedSqlKeySentenceBySQLString()
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Constants._connectionString);
                connection.Open();
                string sql = $"select (key_sentence) from cached_sql where sql_string = '{SQL}'";
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                var result = command.ExecuteScalar().ToString();
                return string.Empty;
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Не удалось получить имя запроса!!!", "Неудача!!!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private string GetCachedSqlByKeySentence()
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(Constants._connectionString);
                connection.Open();
                string sql = $"select (sql_string) from cached_sql where key_sentence = '{KeySentence}'";
                NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                string result = command.ExecuteScalar().ToString();
                return result;
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Не удалось получить запрос по имени!!!", "Неудача!!!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return string.Empty;
            }
        }
    }
}