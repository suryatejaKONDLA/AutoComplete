namespace AutoComplete.Controls;

public partial class Dropdown<TItem> : ComponentBase
{
    [Parameter]
    public List<TItem> Items { get; set; } = new List<TItem>();

    [Parameter]
    public Func<TItem, string> DisplayProperty { get; set; }

    [Parameter]
    public TItem SelectedItem { get; set; }

    [Parameter]
    public EventCallback<TItem> SelectedItemChanged { get; set; }

    private string SelectedItemAsString
    {
        get => SelectedItem == null ? string.Empty : DisplayProperty(SelectedItem);
        set
        {
            SelectedItem = string.IsNullOrEmpty(value) ? default : // Set SelectedItem to null or default value of TItem
                Items.FirstOrDefault(item => DisplayProperty(item) == value);
            SelectedItemChanged.InvokeAsync(SelectedItem);
        }
    }
}