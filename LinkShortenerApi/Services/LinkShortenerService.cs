using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkShortenerApi.Services
{
    public class LinkShortenerService
    {
        private readonly Dictionary<string, string> _urlDatabase = new();

        public string ShortenUrl(string longUrl)
        {
            // Gera um "hash" simples para o URL
            var shortUrl = Convert.ToBase64String(Encoding.UTF8.GetBytes(longUrl))
                                .Substring(0, 8);
            _urlDatabase[shortUrl] = longUrl;

            return shortUrl;
        }

        public string GetLongUrl(string shortUrl)
        {
            return _urlDatabase.ContainsKey(shortUrl) ? _urlDatabase[shortUrl] : null;
        }
    }
}
