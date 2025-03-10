window.flatpickrInterop = {
    initialize: (elementId, dateFormat) => {
        flatpickr(`#${elementId}`, {
            allowInput: false,
            dateFormat: dateFormat,
            onChange: function (selectedDates, dateStr, instance) {
                document.getElementById(elementId).value = dateStr;
            }
        });
    }
};