using Microsoft.AspNetCore.Components;

namespace AutoComplete.Controls
{
    public partial class Dropdown<TItem> : ComponentBase
    {
        [Parameter]
        public List<TItem> Items { get; set; } = [];

        [Parameter]
        public Func<TItem, string> DisplayProperty { get; set; }

        [Parameter]
        public TItem SelectedItem { get; set; }

        [Parameter]
        public EventCallback<TItem> SelectedItemChanged { get; set; }

        private string SelectedValue { get; set; } = string.Empty;

        protected override void OnParametersSet()
        {
            if (SelectedItem != null)
            {
                SelectedValue = DisplayProperty(SelectedItem);
            }
        }

        private async Task OnSelectionChanged(ChangeEventArgs e)
        {
            SelectedValue = e.Value?.ToString() ?? string.Empty;
            var selectedItem = Items.FirstOrDefault(item => DisplayProperty(item) == SelectedValue);

            if (selectedItem != null)
            {
                await SelectedItemChanged.InvokeAsync(selectedItem);
            }
        }
    }
}