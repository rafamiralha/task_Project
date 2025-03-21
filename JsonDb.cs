using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class JsonDb
{
    private const string FilePath = "tasks.json";

    // Salva a lista de Tasks no arquivo JSON
    public static void Salvar(List<Task> tasks)
    {
        string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }

    // Carrega a lista de Tasks do JSON
    public static List<Task> Carregar()
    {
        if (!File.Exists(FilePath)) return new List<Task>();
        string json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<Task>>(json) ?? new List<Task>();
    }
}