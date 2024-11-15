using System;
using System.Threading.Tasks;
using LeagueOFLegendsAPI.Control;
using LeagueOFLegendsAPI.View;
class Program
{
    static async Task Main(string[] args)
    {
        LeagueAPI leagueAPI = new LeagueAPI();
        ExibirCampeoes exibir = new ExibirCampeoes();
        //await leagueAPI.LerCampeoes();
        //exibir.ExibicacaoCampeoes();
        //await leagueAPI.ExibirCampeoes();
        await leagueAPI.FiltrarCampeoes();
    }
}
