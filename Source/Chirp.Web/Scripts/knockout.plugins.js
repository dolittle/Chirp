ko.bindingHandlers.fadeInOrOut = {
    init: function (element, valueAccessor) {
    },
    update: function (element, valueAccessor) {
        var options = valueAccessor();
        var delay = options.delay || 0;
        var duration = options.duration || 500;

        setTimeout(function () {
            if (options.fadeIn === true) {
                $(element).hide().fadeIn(duration);
            } else {
                $(element).fadeOut(duration);
            }
        }, delay);
    }
};


ko.bindingHandlers.fadeInElement = {
    init: function (element, valueAccessor) {
    },
    update: function (element, valueAccessor) {
        $(element).hide().fadeIn(500);
    }
};
