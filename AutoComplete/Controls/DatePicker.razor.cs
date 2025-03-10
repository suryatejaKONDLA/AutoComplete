namespace AutoComplete.Controls;

public partial class DatePicker : ComponentBase
{
    [Parameter] public string DateFormat { get; set; } = "d-M-Y";
    [Parameter] public string CssClass { get; set; } = "form-control";
    [Parameter] public EventCallback<DateTime?> OnDateChanged { get; set; }

    [Parameter] public DateTime? SelectedDate { get; set; }
    [Parameter] public EventCallback<DateTime?> SelectedDateChanged { get; set; }

    private string ElementId { get; set; } = $"flatpickr-{Guid.NewGuid()}";

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JSRuntime.InvokeVoidAsync("flatpickrInterop.initialize", ElementId, DateFormat);
        }
    }

    private async Task OnInputChange(ChangeEventArgs e)
    {
        if (DateTime.TryParse(e.Value?.ToString(), out var date))
        {
            SelectedDate = date;
            await SelectedDateChanged.InvokeAsync(SelectedDate);
            await OnDateChanged.InvokeAsync(SelectedDate);
        }
    }
}