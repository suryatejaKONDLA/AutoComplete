namespace AutoComplete.Models;

public class Group
{
    [JsonProperty("groupId")]
    [JsonPropertyName("groupId")]
    [Display(Name = "Group ID")]
    public int? GroupId { get; set; }

    [JsonProperty("lineOfBusiness")]
    [JsonPropertyName("lineOfBusiness")]
    [Display(Name = "Line of Business")]
    public string LineOfBusiness { get; set; }

    [JsonProperty("groupNo")]
    [JsonPropertyName("groupNo")]
    [Display(Name = "Group No")]
    public string GroupNo { get; set; }

    [JsonProperty("groupName")]
    [JsonPropertyName("groupName")]
    [Display(Name = "Group Name")]
    public string GroupName { get; set; }

    [JsonProperty("dbaOrTradeName")]
    [JsonPropertyName("dbaOrTradeName")]
    [Display(Name = "DBA or Trade Name")]
    public string DbaOrTradeName { get; set; }

    [JsonProperty("isActive")]
    [JsonPropertyName("isActive")]
    [Display(Name = "Active")]
    public bool? IsActive { get; set; }

    [JsonProperty("isCompleted")]
    [JsonPropertyName("isCompleted")]
    [Display(Name = "Completed")]
    public bool? IsCompleted { get; set; }

    [JsonProperty("modifiedBy")]
    [JsonPropertyName("modifiedBy")]
    [Display(Name = "Modified By")]
    public string ModifiedBy { get; set; }
}