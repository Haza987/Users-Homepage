using Data.Interfaces;
using Domain.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Data.Services;

public class FileService : IFileService
{
    private readonly string _filePath;
    private readonly string _directoryPath;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public FileService(string directoryPath = "Data", string fileName = "contacts.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
        _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
    }

    public bool SaveListToFile(List<Contact> list)
    {
        try
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
                return true;
            }
            else
            {
                var json = JsonSerializer.Serialize(list, _jsonSerializerOptions);
                File.WriteAllText(_filePath, json);
                return true;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public List<Contact> LoadListFromFile()
    {
        try
        {
            if (!File.Exists(_filePath))
            {
                return new List<Contact>();
            }
            else
            {
                var json = File.ReadAllText(_filePath);
                var list = JsonSerializer.Deserialize<List<Contact>>(json, _jsonSerializerOptions);
                return list ?? new List<Contact>();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return new List<Contact>();
        }
    }
}