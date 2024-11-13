using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LeagueOFLegendsAPI
{
    public class LeagueAPI
    {
        public async Task LerCampeoes()
        {
            string api = "https://ddragon.leagueoflegends.com/cdn/14.22.1/data/pt_BR/champion.json";
            using HttpClient client = new HttpClient();

            try
            {
                DadosCampeoes campeoes = await client.GetFromJsonAsync<DadosCampeoes>(api);

                if (campeoes?.Data != null)
                {
                    foreach (var item in campeoes.Data.Values)
                    {
                        Console.WriteLine($"Key: {item.Id}");
                        Console.WriteLine($"Nome: {item.Name}");
                        Console.WriteLine($"Título: {item.Title}");
                        Console.WriteLine($"História: {item.Historia}");
                        Console.WriteLine($"Vida: {item.Stats.Hp} ");
                        Console.WriteLine($"Armadura: {item.Stats.Armor} ");
                        Console.WriteLine(new string('-', 40));
                    }
                }
                else
                {
                    Console.WriteLine("Não foi possível obter os dados dos campeões.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocorreu um erro: {e.Message}\n ");
            }
        }
    }
}
