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

    private bool Initialized = false;
    private DateTime? LastSelectedDate;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            DotNetHelper = DotNetObjectReference.Create(this);
            await JsRuntime.InvokeVoidAsync("flatpickrInterop.initialize", ElementId, DateFormat, DotNetHelper);
            Initialized = true;
        }

        // Sync date from C# to JS only after initialization
        if (Initialized && SelectedDate != LastSelectedDate)
        {
            await JsRuntime.InvokeVoidAsync("flatpickrInterop.setDate", ElementId, SelectedDate);
            LastSelectedDate = SelectedDate;
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