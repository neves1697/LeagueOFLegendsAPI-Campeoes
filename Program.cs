using System;
using System.Threading.Tasks;
using LeagueOFLegendsAPI;

class Program
{
    static async Task Main(string[] args)
    {
        LeagueAPI leagueAPI = new LeagueAPI();
        await leagueAPI.LerCampeoes();
    }
}
