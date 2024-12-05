using Business.Models;
using System.Diagnostics;
using System.Text.Json;


namespace Business.Services;

public class FileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public FileService(string directoryPath = "Data", string fileName = "list.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
        _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
    }


    //Code generated with help from chatGPT.
    public void SaveListToFile<T>(List<T> list)
    {
        try
        {
            // Skapa katalogen om den inte finns
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }

            // Serialisera listan till JSON och skriv till fil
            var json = JsonSerializer.Serialize(list, _jsonSerializerOptions);
            File.WriteAllText(_filePath, json);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error: {ex.Message}");
        }
    }

    public List<T> LoadListFromFile<T>()
    {
        try
        {
            // Kontrollera om filen existerar
            if (!File.Exists(_filePath))
            {
                return new List<T>(); // Returnera en tom lista om filen saknas
            }

            // Läs in JSON-data från filen
            var json = File.ReadAllText(_filePath);

            // Deserialisera JSON till en lista
            var list = JsonSerializer.Deserialize<List<T>>(json, _jsonSerializerOptions);

            return list ?? new List<T>(); // Returnera en tom lista om deserialiseringen misslyckas
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error loading file: {ex.Message}");
            return new List<T>();
        }
    }
}