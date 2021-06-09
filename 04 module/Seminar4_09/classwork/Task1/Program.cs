using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Task1
{
	class Program
	{
        static async Task Main()
        {
            MatchCollection links = GetLinks(await GetHTMLText("https://ru.wikipedia.org/wiki/Заглавная_страница"));
            foreach (Match link in links)
                Console.WriteLine($" {link.Groups["name"].Value} : {link}");
        }
        static async Task<string> GetHTMLText(string link)
		{
            using HttpClient client = new();
            var response = await client.GetAsync(link);
            string htmlText = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Скачали ответ: {htmlText.Length} символов");
            return htmlText;
        }
		static MatchCollection GetLinks(string text)
			=> Regex.Matches(HttpUtility.UrlDecode(text), @" href=""\/wiki\/(?<name>[\w\(\)]+)""");
	}
}
