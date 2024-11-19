using System;
using System.Threading.Tasks;
using LeagueOFLegendsAPI.Controller;
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
        //await leagueAPI.FiltrarCampeoes();
        //await leagueAPI.OrdenarCampeoesAscendente();
        await leagueAPI.OrdenarCampeoesDescendente();
    }
}
