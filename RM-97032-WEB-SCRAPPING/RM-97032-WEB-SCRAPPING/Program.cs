using HtmlAgilityPack;
using System;
using System.Net.Http;
using System.Threading.Tasks;                 

class Program 
{
    static async Task Main(string[] args) 
    {

        var client = new HttpClient(); 
        var url = "https://www.metacritic.com/game/five-nights-at-freddys/"; 

        using (var response = await client.GetAsync(url)) 
        {
            if (response.IsSuccessStatusCode) 
            {
                var content = await response.Content.ReadAsStringAsync(); 
                Console.WriteLine("HTML Content:"); 
                Console.WriteLine(content); 

                var doc = new HtmlDocument(); 
                doc.LoadHtml(content); 

                var titleNode = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div/div/div[2]/div[1]/div[1]/div/div/div[2]/div[3]/div[1]/div");
                var title = titleNode?.InnerText?.Trim(); 

                var metascoreNode = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div/div/div[2]/div[1]/div[1]/div/div/div[2]/div[3]/div[4]/div[1]/div/div[1]/div[2]/div/div/span");
                var metascore = metascoreNode?.InnerText?.Trim();

                var userscoreNode = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/div/div/div[2]/div[1]/div[1]/div/div/div[2]/div[3]/div[4]/div[2]/div[1]/div[2]/div/div/span");
                var userscore = userscoreNode?.InnerText?.Trim();

                Console.WriteLine("Título do Jogo: " + (title ?? "Não achou o título do jogo.")); 
                Console.WriteLine("Metascore: " + (metascore ?? "Não achou o metascore do jogo."));
                Console.WriteLine("Userscore: " + (userscore ?? "Não achou o userscore do jogo."));
            }
            else 
            {
                Console.WriteLine("Erro no Http: " + response.StatusCode);
            }
        }

        Console.WriteLine("Pressione alguma tecla para fechar o CMD");
        Console.ReadKey();

    }
}



