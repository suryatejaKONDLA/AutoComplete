window.flatpickrInterop = {
    initialize: function (elementId, dateFormat, dotNetHelper) {
        var flatpickrInstance = flatpickr(document.getElementById(elementId), {
            dateFormat: dateFormat,
            onChange: function (selectedDates) {
                if (selectedDates.length > 0) {
                    dotNetHelper.invokeMethodAsync('OnFlatpickrDateChanged', selectedDates[0]);
                } else {
                    dotNetHelper.invokeMethodAsync('OnFlatpickrDateChanged', null);
                }
            }
        });
    }
};