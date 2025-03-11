namespace AutoComplete.Models;

public class ActionItemModel
{
    [Display(Name = "Action Item")]
    public string ActionItem { get; set; }

    [Display(Name = "Effective Date")]
    public DateTime? EffectiveDate { get; set; }
    
    [Display(Name = "Is Selected")]
    public bool IsSelected { get; set; }

    [Display(Name = "Comments")]
    public string Comments { get; set; }
}