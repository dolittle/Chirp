(function (undefined) {
    Bifrost.features.featureManager.get("stream").defineViewModel(function () {
        var self = this;

        this.chirps = ko.observableArray();

        this.loadChirps = function () {
            $.get("/Stream/GetPublic", function (e) {
                self.chirps(e);
            }, "json");
        }

        $.subscribe("reload", function () {
            self.loadChirps();
        });


        this.loadChirps();
    });
})();
