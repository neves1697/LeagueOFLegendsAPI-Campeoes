﻿using LeagueOFLegendsAPI.View;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
namespace LeagueOFLegendsAPI.Controller
{
    public class LeagueAPI
    {
        public string api = "https://ddragon.leagueoflegends.com/cdn/14.22.1/data/pt_BR/champion.json";
        HttpClient client = new HttpClient();

        public async Task LerCampeoes()
        {
            //string api = "https://ddragon.leagueoflegends.com/cdn/14.22.1/data/pt_BR/champion.json";
            //using HttpClient client = new HttpClient
            try
            {
                DadosCampeoes campeoes = await client.GetFromJsonAsync<DadosCampeoes>(api);

                if (campeoes?.Data != null)
                {
                    foreach (var item in campeoes.Data.Values)
                    {
                        Console.WriteLine($"Key: {item.Id}");
                        Console.WriteLine($"Nome: {item.Name}");
                        Console.WriteLine($"Título: {item.Title.ToUpper()}");
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

        public async Task ExibirCampeoes()
        {
            DadosCampeoes campeoes = await client.GetFromJsonAsync<DadosCampeoes>(api);

            if (campeoes?.Data != null)
            {
                Console.WriteLine($"Total Campeões: {campeoes.Data.Count} \n");
            }
            else
            {
                Console.WriteLine("Não foi possível filtrar os dados");
            }
        }

        public async Task FiltrarCampeoesPorNome()
        {
            DadosCampeoes campeoes = await client.GetFromJsonAsync<DadosCampeoes>(api);

            if (campeoes?.Data != null)
            {
                string mensagem = "Digite o nome de um campeão para filtrar:";
                Console.WriteLine(mensagem);

                // Lê o nome do campeão digitado pelo usuário
                var nomeDoCampeao = Console.ReadLine();

                // Verifica se o nome digitado pelo usuário existe no dicionário
                if (campeoes.Data.ContainsKey(nomeDoCampeao))
                {
                    Console.WriteLine($"Campeão encontrado: {nomeDoCampeao}");
                }
                else
                {
                    Console.WriteLine("Campeão não encontrado.");
                }
            }
        }

        public async Task FiltrarCampeoesPorID(int id)
        {
            DadosCampeoes campeoes = await client.GetFromJsonAsync<DadosCampeoes>(api);

            if (campeoes?.Data != null)
            {
                var campeaoEncontrado = campeoes.Data.Values.FirstOrDefault(c => c.Id == id.ToString());

                if (campeaoEncontrado != null)
                {
                    Console.WriteLine($"Key: {campeaoEncontrado.Id}");
                    Console.WriteLine($"Nome: {campeaoEncontrado.Name}");
                    Console.WriteLine($"Título: {campeaoEncontrado.Title.ToUpper()}");
                    Console.WriteLine($"História: {campeaoEncontrado.Historia}");
                    Console.WriteLine($"Vida: {campeaoEncontrado.Stats.Hp}");
                    Console.WriteLine($"Armadura: {campeaoEncontrado.Stats.Armor}");
                    Console.WriteLine(new string('-', 40));
                }
                else
                {
                    Console.WriteLine("Nenhum campeão encontrado com o ID fornecido.");
                }
            }
            else
            {
                Console.WriteLine("Não foi possível obter os dados dos campeões.");
            }
        }


        public async Task OrdenarCampeoesAscendente()
        {
            DadosCampeoes campeoes = await client.GetFromJsonAsync<DadosCampeoes>(api);

            if (campeoes?.Data is not null)
            {
                // Converte os campeões para uma lista e ordena por nome
                var listaOrdenada = campeoes.Data.Values
                    .OrderBy(c => c.Name) // Ordenação por Nome
                    .ToList();

                foreach (var item in listaOrdenada)
                {
                    Console.WriteLine($"Key: {item.Id}");
                    Console.WriteLine($"Nome: {item.Name}");
                    Console.WriteLine($"Título: {item.Title.ToUpper()}");
                    Console.WriteLine(new string('-', 40));
                }
            }
            else
            {
                Console.WriteLine("Não foi possível obter os dados dos campeões.");
            }
        }

        public async Task OrdenarCampeoesDescendente()
        {
            DadosCampeoes campeoes = await client.GetFromJsonAsync<DadosCampeoes>(api);

            if (campeoes?.Data is not null)
            {
                var listaDescendente = campeoes.Data.Values.OrderByDescending(c => c.Name).ToList();

                foreach (var lista in listaDescendente)
                {
                    Console.WriteLine($"Key: {lista.Id}");
                    Console.WriteLine($"Nome: {lista.Name}");
                    Console.WriteLine($"Título: {lista.Title.ToUpper()}");
                    Console.WriteLine(new string('-', 40));
                }
            }
        }
    }
}

