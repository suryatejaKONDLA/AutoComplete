namespace AutoComplete.Controls
{
    public partial class AutoComplete<TItem> : ComponentBase
    {
        [Parameter]
        public TItem Model { get; set; }

        [Parameter]
        public EventCallback<TItem> ModelChanged { get; set; }

        [Parameter]
        public List<TItem> Items { get; set; }

        [Parameter]
        public Func<TItem, string> DisplayProperty { get; set; }

        private string SearchText { get; set; }
        private List<TItem> FilteredItems { get; set; } = [];
        private bool IsDropdownOpen { get; set; } = false;

        private ElementReference InputElement;

        protected override void OnParametersSet()
        {
            FilteredItems = Items;
        }

        private void OnInput(ChangeEventArgs e)
        {
            SearchText = e.Value?.ToString();
            FilteredItems = Items.Where(item => DisplayProperty(item).Contains(SearchText, StringComparison.OrdinalIgnoreCase)).ToList();
            IsDropdownOpen = true; // Open dropdown when typing
        }

        private void OnKeyDown(KeyboardEventArgs e)
        {
            if (e.Key == "Enter" && FilteredItems.Any())
            {
                SelectItem(FilteredItems.First());
            }
        }

        private async Task SelectItem(TItem item)
        {
            SearchText = DisplayProperty(item);
            await ModelChanged.InvokeAsync(item);
            IsDropdownOpen = false;
        }

        private void OpenDropdown()
        {
            IsDropdownOpen = true;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JsRuntime.InvokeVoidAsync("setupAutocomplete", InputElement, DotNetObjectReference.Create(this));
            }
        }

        [JSInvokable]
        public void CloseDropdown()
        {
            IsDropdownOpen = false;
            StateHasChanged();
        }
    }
}
