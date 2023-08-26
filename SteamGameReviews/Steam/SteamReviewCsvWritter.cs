using SteamGameReviews.Steam.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SteamGameReviews.Steam
{
    internal sealed class SteamReviewCsvWritter : IAsyncDisposable, IDisposable
    {
        private static readonly byte[] EndOfLineBytes = Encoding.UTF8.GetBytes("\n");
        private static Dictionary<string, FieldInfo>? serializedFields;

        private Stream stream;
        private TextWriter writer;

        public SteamReviewCsvWritter(string filename)
        {
            InitializeSerializer();
            stream = new FileStream(filename, FileMode.Create, FileAccess.Write);
            writer = new StreamWriter(stream, Encoding.UTF8);
        }

        public void Dispose()
        {
            writer.Dispose();
            stream.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await writer.DisposeAsync();
            await stream.DisposeAsync();
        }

        public async Task WriteHeaders()
        {
            string headers = string.Join(',', serializedFields!.Keys);
            await writer.WriteLineAsync(headers);
        }

        public async Task WriteAppInfo(AppInfo app)
        {
            if (app.Reviews == null)
            {
                return;
            }

            foreach (Review review in app.Reviews)
            {
                await WriteReviewAsync(app, review);
            }
        }

        private async Task WriteReviewAsync(AppInfo app, Review review)
        {
            CsvDto dto = BuildHydratedObject(app, review);
            var builder = new StringBuilder();
            int index = 0;

            foreach (FieldInfo field in serializedFields!.Values)
            {
                string value = field.GetValue(dto)!.ToString()!;

                if (field.FieldType == typeof(bool))
                {
                    value = value.ToLower();
                }

                if (field.FieldType == typeof(string))
                {
                    value = EscapeString(value);
                }

                builder.Append(value);

                if (index + 1 < serializedFields!.Count)
                {
                    builder.Append(',');
                }

                index++;
            }

            await writer.WriteLineAsync(builder.ToString());
        }

        private static string EscapeString(string str)
        {
            char delimiter = ',';
            char enclosure = '"';
            char escape = '\\';
            var builder = new StringBuilder(str.Length);

            if (str.Contains(delimiter) ||
                str.Contains(enclosure) ||
                str.Contains(escape) ||
                str.Contains('\n') ||
                str.Contains('\r') ||
                str.Contains('\t') ||
                str.Contains(' '))
            {
                bool escaped = false;
                builder.Append(enclosure);

                for (int i = 0; i < str.Length; i++)
                {
                    char ch = str[i];

                    if (ch == escape)
                    {
                        escaped = true;
                    }
                    else if (!escaped && ch == enclosure)
                    {
                        builder.Append(enclosure);
                    }
                    else
                    {
                        escaped = false;
                    }

                    builder.Append(ch);
                }

                builder.Append(enclosure);
            }
            else
            {
                builder.Append(str);
            }

            return builder.ToString();
        }

        private static CsvDto BuildHydratedObject(AppInfo app, Review review)
        {
            var dto = new CsvDto();

            dto.review_id = review.Id;
            dto.app_id = app.Id;
            dto.app_name = app.Name;
            dto.author_id = review.Author.Id;
            dto.author_owned_games = review.Author.GamesOwned;
            dto.author_playtime_hours = review.Author.PlaytimeAtReview.TotalHours.ToString();
            dto.author_last_played = review.Author.LastPlayed.ToString("yyyy-MM-dd HH:mm:ss");
            dto.review_lang = review.Language;
            dto.review_text = review.Text;
            dto.review_date = review.CreatedTime.ToString("yyyy-MM-dd HH:mm:ss");
            dto.review_voted_up = review.VotedUp;
            dto.review_votes_up = review.VotesUp;
            dto.review_votes_funny = review.VotesFunny;
            dto.review_purchased_on_steam = review.PurchasedOnSteam;
            dto.review_received_for_free = review.ReceivedForFree;
            dto.review_written_earlyaccess = review.WrittenDuringEarlyAccess;
            dto.review_hidden_in_china = review.HiddenInChina;

            return dto;
        }


        private static void InitializeSerializer()
        {
            if (serializedFields == null)
            {
                var dtoType = typeof(CsvDto);
                FieldInfo[] fields = dtoType.GetFields();

                serializedFields = new Dictionary<string, FieldInfo>(fields.Length);

                foreach (FieldInfo field in fields)
                {
                    serializedFields.Add(field.Name, field);
                }
            }
        }

        private class CsvDto
        {
            public long review_id;
            public long app_id;
            public string app_name = "";
            public long author_id;
            public int author_owned_games;
            public string author_playtime_hours = "";
            public string author_last_played = "";
            public string review_lang = "";
            public string review_text = "";
            public string review_date = "";
            public bool review_voted_up;
            public int review_votes_up;
            public int review_votes_funny;
            public bool review_purchased_on_steam;
            public bool review_received_for_free;
            public bool review_written_earlyaccess;
            public bool review_hidden_in_china;
        }
    }
}
