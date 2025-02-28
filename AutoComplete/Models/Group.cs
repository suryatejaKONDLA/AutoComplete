using Newtonsoft.Json;

namespace AutoComplete.Models;

public class Group
{
    [JsonProperty("groupId")]
    [JsonPropertyName("groupId")]
    public int? GroupId { get; set; }

    [JsonProperty("lineOfBusiness")]
    [JsonPropertyName("lineOfBusiness")]
    public string LineOfBusiness { get; set; }

    [JsonProperty("groupNo")]
    [JsonPropertyName("groupNo")]
    public string GroupNo { get; set; }

    [JsonProperty("groupName")]
    [JsonPropertyName("groupName")]
    public string GroupName { get; set; }

    [JsonProperty("dbaOrTradeName")]
    [JsonPropertyName("dbaOrTradeName")]
    public string DbaOrTradeName { get; set; }

    [JsonProperty("isActive")]
    [JsonPropertyName("isActive")]
    public bool? IsActive { get; set; }

    [JsonProperty("isCompleted")]
    [JsonPropertyName("isCompleted")]
    public bool? IsCompleted { get; set; }

    [JsonProperty("modifiedBy")]
    [JsonPropertyName("modifiedBy")]
    public string ModifiedBy { get; set; }
}