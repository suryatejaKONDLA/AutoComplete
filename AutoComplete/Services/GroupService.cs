namespace AutoComplete.Services;

public class GroupService
{
    private readonly string FilePath;
    private List<Group> Groups = [];

    public GroupService()
    {
        FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GeneratedData.json");
        LoadData();
    }

    private void LoadData()
    {
        if (File.Exists(FilePath))
        {
            var jsonData = File.ReadAllText(FilePath);
            Groups = System.Text.Json.JsonSerializer.Deserialize<List<Group>>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? [];
        }
    }

    public IEnumerable<Group> GetDataGroupLocal()
    {
        return Groups;
    }
}