window.flatpickrInterop = {
    instances: {},

    initialize: function (elementId, dateFormat, dotNetHelper) {
        var input = document.getElementById(elementId);
        var instance = flatpickr(input, {
            dateFormat: dateFormat,
            defaultDate: input.value || null,
            onChange: function (selectedDates) {
                if (selectedDates.length > 0) {
                    dotNetHelper.invokeMethodAsync('OnFlatpickrDateChanged', selectedDates[0]);
                } else {
                    dotNetHelper.invokeMethodAsync('OnFlatpickrDateChanged', null);
                }
            }
        });

        this.instances[elementId] = instance;
    },

    setDate: function (elementId, date) {
        var instance = this.instances[elementId];
        if (instance && date) {
            instance.setDate(date, true);
        } else if (instance) {
            instance.clear();
        }
    }
};
