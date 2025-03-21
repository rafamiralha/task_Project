using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class User
{
    public int Id { get; set; }
    public string name_user { get; set; }
}


class Program
{
    static void Main()
    {
        List<Task> Tasks = JsonDb.Carregar();

        while (true)
        {
            Console.WriteLine("1-Criar | 2-Listar | 3-Excluir | 4-Sair");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Titulo da Tarefa: ");
                    string title = Console.ReadLine();
                    Console.Write("Descrição da Tarefa: ");
                    string description = Console.ReadLine();

                    int novoId = Tasks.Count > 0 ? Tasks[^1].Id + 1 : 1;
                    Tasks.Add(new Task { Id = novoId, title_task = title, description_task = description });
                    JsonDb.Salvar(Tasks);
                    break;

                case "2":
                    foreach (var p in Tasks)
                        Console.WriteLine($"Identificador: {p.Id} \n Título: {p.title_task} \n Descrição: {p.description_task}");
                    break;

                case "3":
                    Console.Write("ID da Task para excluir: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Tasks.RemoveAll(p => p.Id == id);
                    JsonDb.Salvar(Tasks);
                    break;

                case "4":
                    return;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}