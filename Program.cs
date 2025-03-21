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
            Console.WriteLine("1-Criar | 2-Listar | 3-Editar | 4-Excluir | 5-Sair");
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
                    {
                        Console.Write("ID do produto para editar: ");
                        if (!int.TryParse(Console.ReadLine(), out int Id))
                        {
                            Console.WriteLine("ID inválido.");
                            return;
                        }

                        var produto = Tasks.Find(p => p.Id == Id);
                        if (produto == null)
                        {
                            Console.WriteLine("Produto não encontrado!");
                            return;
                        }

                        Console.Write($"Novo titulo ({produto.title_task}): ");
                        string? newTitle_task = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newTitle_task))
                            produto.title_task = newTitle_task;

                        Console.Write($"Nova Descricao ({produto.description_task}): ");
                        string? newDescription_task = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newDescription_task))
                            produto.description_task = newDescription_task;

                        JsonDb.Salvar(Tasks);
                        Console.WriteLine("Task atualizada com sucesso!");
                    }
                    break;

                case "4":
                    Console.Write("ID da Task para excluir: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Tasks.RemoveAll(p => p.Id == id);
                    JsonDb.Salvar(Tasks);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}