using System.Text.Json;

namespace PartnersPageGenerator;

public class PartnerReader
{
    public List<PartnerModel> LoadFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("JSON file not found", filePath);
        }

        string fileContent = File.ReadAllText(filePath);

        var list = JsonSerializer.Deserialize<List<PartnerModel>>(fileContent)!;

        return list.OrderBy(x => x.Name).ToList();
    }
}
