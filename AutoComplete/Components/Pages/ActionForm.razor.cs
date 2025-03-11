namespace AutoComplete.Components.Pages;

public partial class ActionForm
{
    private readonly List<string> AvailableItems = ["Item1", "Item2", "Item3", "Item4", "Item5", "Item6"];
    private readonly List<ActionItemModel> AddedItems = [];

    private string SelectedActionItem = null;
    private ActionItemModel NewItem = new();

    private void OnItemSelected(string item)
    {
        SelectedActionItem = item;
        NewItem = new() { ActionItem = item };
    }

    private void HandleDateChange(DateTime? date)
    {
        NewItem.EffectiveDate = date;
        Console.WriteLine($"Date received: {date}");

    }

    private void AddItem()
    {
        if (!string.IsNullOrEmpty(SelectedActionItem))
        {
            AddedItems.Add(NewItem);

            AvailableItems.Remove(SelectedActionItem);
            SelectedActionItem = null;

            NewItem = new();
        }
    }

    private void RemoveItem(ActionItemModel item)
    {
        AddedItems.Remove(item);
        AvailableItems.Add(item.ActionItem);
    }
}