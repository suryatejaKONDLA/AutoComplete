using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace AutoComplete.Controls
{
    public partial class AutoComplete<TItem> : ComponentBase
    {
        [Parameter]
        public TItem Model { get; set; }

        [Parameter]
        public EventCallback<TItem> ModelChanged { get; set; }

        [Parameter]
        public List<TItem> Items { get; set; } = [];

        [Parameter]
        public Func<TItem, string> DisplayProperty { get; set; }

        private string SearchText { get; set; } = string.Empty;
        private List<TItem> FilteredItems { get; set; } = [];
        private bool IsDropdownOpen { get; set; } = false;
        private ElementReference InputElement;

        protected override void OnParametersSet()
        {
            FilterItems();
        }

        private void OnInput(ChangeEventArgs e)
        {
            SearchText = e.Value?.ToString() ?? string.Empty;
            FilterItems();
            IsDropdownOpen = true;
        }

        private void FilterItems()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredItems = Items;
            }
            else
            {
                FilteredItems = Items
                    .Where(item => DisplayProperty(item).Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            StateHasChanged();
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

        private ValueTask<ItemsProviderResult<TItem>> LoadItems(ItemsProviderRequest request)
        {
            var items = FilteredItems.Skip(request.StartIndex).Take(request.Count).ToList();
            return ValueTask.FromResult<ItemsProviderResult<TItem>>(new(items, FilteredItems.Count));
        }
    }
}
