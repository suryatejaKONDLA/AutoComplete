namespace AutoComplete.Controls;

public partial class DatePicker : ComponentBase
{
    private DotNetObjectReference<DatePicker> DotNetHelper;

    private string ElementId { get; set; } = $"flatpickr-{Guid.NewGuid()}";

    [Parameter] public string DateFormat { get; set; } = "d-M-Y";

    [Parameter] public string CssClass { get; set; } = "form-control";

    [Parameter] public EventCallback<DateTime?> OnDateChanged { get; set; }

    [Parameter] public DateTime? SelectedDate { get; set; }

    [Parameter] public EventCallback<DateTime?> SelectedDateChanged { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            DotNetHelper = DotNetObjectReference.Create(this);
            await JsRuntime.InvokeVoidAsync("flatpickrInterop.initialize", ElementId, DateFormat, DotNetHelper);
        }
    }

    [JSInvokable]
    public async Task OnFlatpickrDateChanged(DateTime? date)
    {
        SelectedDate = date;
        await SelectedDateChanged.InvokeAsync(SelectedDate);
        await OnDateChanged.InvokeAsync(SelectedDate);
        StateHasChanged();
    }

    public void Dispose()
    {
        DotNetHelper?.Dispose();
    }
}