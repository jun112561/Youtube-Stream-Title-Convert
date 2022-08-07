﻿using System;

namespace Youtube_Stream_Title_Convert.DataBase.Table
{
    public class YoutubeMemberCheck : DbEntity
    {
        public enum CheckStatus { ExpiredOrNoMember = -1, NotYetStarted = 0, Success = 1 }

        public ulong GuildId { get; set; }
        public ulong UserId { get; set; }
        public string CheckYTChannelId { get; set; }
        public DateTime LastCheckTime { get; set; } = DateTime.Now;
        public CheckStatus LastCheckStatus { get; set; } = CheckStatus.NotYetStarted;
    }
}
