using Dapper;
using Npgsql;
using PSQL_Dapper.Models;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace PSQL_Dapper
{
    class Program
    {
        //private string _connString = "Host=localhost;Username=postgres;Password=@Dvantech9771;Database=postgres";
        private string _connString = "Host=PC031112;Port=5434;Username=postgres;Password=postgrespostgres;Database=postgres";
        static void Main(string[] args)
        {
            Console.WriteLine("Start...");
            Program p = new Program();
            //p.vGetVersion();
            //p.vCreateTable();
            for (int i = 0; i < 50; i++)
            {
                p.vGenerateRandomData();
                Task.Delay(5000).Wait();
            }

            Console.WriteLine("Finished");

        }

        private static readonly Random random = new Random();
        private static double RandomNumberBetween(double minValue, double maxValue)
        {
            //int month = random.Next(1, 13);  
            var next = random.NextDouble();
            Console.WriteLine("next: {0}", next);
            var temp = minValue + (next * (maxValue - minValue));
            var newValue = Math.Round(temp, 2);
            return newValue;
        }

        private async void vGenerateRandomData()
        {
            string strEntity = String.Empty;
            double fRandomNumber = 0;
            if (random.Next(0, 2) == 0) // creates a number between 0 and 1
            {
                fRandomNumber = RandomNumberBetween(10.2, 90.8);
                Console.WriteLine("fRandomNumber: {0}", fRandomNumber);
                strEntity = "humidity";
            }
            else
            {
                fRandomNumber = RandomNumberBetween(100.6, 190.8);
                Console.WriteLine("fRandomNumber: {0}", fRandomNumber);
                strEntity = "temperature";
            }

            State s = new State();
            s.state = fRandomNumber;
            s.entity = strEntity;
            await insertData(s);
        }

        private async Task<int> insertData(State entity)
        {

            // convert local time to UTC for database save
            var databaseUtcTime = DateTime.Now.ToUniversalTime();
            //Console.WriteLine("localTime:{0}", localTime);
            Console.WriteLine("databaseUtcTime:{0}", databaseUtcTime);

            var taipeiTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Taipei Standard Time");
            var taipeiTime = TimeZoneInfo.ConvertTime(DateTime.Now, taipeiTimeZone);
            databaseUtcTime = TimeZoneInfo.ConvertTimeToUtc(taipeiTime, taipeiTimeZone);
            //Console.WriteLine("entity.timestamp:{0}", entity.timestamp);
            //Console.WriteLine("taipeiTime:{0}", taipeiTime);
            //Console.WriteLine("databaseUtcTime:{0}", databaseUtcTime);

            entity.timestamp = databaseUtcTime;

            var sql = "INSERT INTO states (entity, state, timestamp) Values (@entity, @state, @timestamp);";
            using (var connection = new NpgsqlConnection(_connString))
            {
                //connection.Open();
                Console.WriteLine("inserting...");
                var affectedRows = connection.Execute(sql, entity);
                Console.WriteLine("affectedRows:{0}", affectedRows);
                return affectedRows;
            }
        }

        private void vGetVersion()
        {
            using (var connection = new NpgsqlConnection(_connString))
            {
                //var version = connection.Query<String>("select VERSION()");
                var version = connection.QueryAsync<String>("select VERSION()").Result;
                Console.WriteLine(version.FirstOrDefault());
            }
        }

        private void vCreateTable()
        {
            using (var connection = new NpgsqlConnection(_connString))
            {
                string sql = @"
                    CREATE TABLE states
                    (id            serial PRIMARY KEY,
                        entity           TEXT    NOT NULL,
                        state            REAL     NOT NULL,
                        timestamp        timestamptz NOT NULL
                    );
                ";
                connection.Execute(sql);
            }
        }
    }
}
