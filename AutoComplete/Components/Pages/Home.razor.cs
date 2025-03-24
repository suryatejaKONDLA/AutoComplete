namespace AutoComplete.Components.Pages;

public partial class Home
{
    private Group SelectedItem { get; set; }

    private List<Group> Items { get; set; } = [];

    private void OnItemSelected(Group item) { SelectedItem = item; }

    protected override void OnInitialized()
    {
        Items = DataGroupService.GetDataGroupLocal().ToList();
        SelectedDate = DateTime.Now;
    }


    private DateTime? SelectedDate;

    private void HandleDateChange(DateTime? date)
    {
        SelectedDate = date;
        Console.WriteLine($"Date Selected: {SelectedDate}");
    }
}
