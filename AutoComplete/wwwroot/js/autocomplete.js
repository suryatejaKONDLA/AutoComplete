function setupAutocomplete(inputElement, dotNetHelper) {
    document.addEventListener('click', function (event) {
        const isClickInside = inputElement.contains(event.target);
        if (!isClickInside) {
            dotNetHelper.invokeMethodAsync('CloseDropdown');
        }
    });
}