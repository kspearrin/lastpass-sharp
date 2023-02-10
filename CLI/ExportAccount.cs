﻿using CsvHelper.Configuration.Attributes;
using LastPass;

namespace CLI
{
    public class ExportAccount
    {
        public ExportAccount() { }

        public ExportAccount(Account account)
        {
            Url = account.Url;
            Username = account.Username;
            Password = account.Password;
            // Totp not supported
            Extra = account.Notes;
            Name = account.Name;
            Grouping = account.Group;
            Fav = account.Favorite == "1" ? 1 : 0;
        }

        [Name("url")]
        public string Url { get; set; }
        [Name("username")]
        public string Username { get; set; }
        [Name("password")]
        public string Password { get; set; }
        [Name("totp")]
        public string Totp { get; set; }
        [Name("extra")]
        public string Extra { get; set; }
        [Name("name")]
        public string Name { get; set; }
        [Name("grouping")]
        public string Grouping { get; set; }
        [Name("fav")]
        public int Fav { get; set; }
    }
}
