﻿using Microsoft.EntityFrameworkCore;

namespace Youtube_Stream_Title_Convert
{
    public class NotVTuberVideoContext : VideoContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={Program.GetDataFilePath("NotVTuberVideoDb.db")}")
#if DEBUG
            //.LogTo((act) => System.IO.File.AppendAllText("NotVTuberVideoDbTrackerLog.txt", act), Microsoft.Extensions.Logging.LogLevel.Information)
#endif
            .EnableSensitiveDataLogging();

        public static NotVTuberVideoContext GetDbContext()
        {
            var context = new NotVTuberVideoContext();
            context.Database.SetCommandTimeout(60);
            var conn = context.Database.GetDbConnection();
            conn.Open();
            using (var com = conn.CreateCommand())
            {
                com.CommandText = "PRAGMA journal_mode=WAL; PRAGMA synchronous=OFF";
                com.ExecuteNonQuery();
            }
            return context;
        }
    }
}
