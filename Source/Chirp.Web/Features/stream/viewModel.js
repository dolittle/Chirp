(function (undefined) {
    Bifrost.features.featureManager.get("stream").defineViewModel(function () {
        var self = this;
        var session = Bifrost.dependencyResolver.resolve(Chirp, "Session");


        this.chirps = ko.observableArray();

        this.loadChirps = function () {
            $.get("/Streamer/GetReadingStreamFor", { reader : session.getCurrentUserId()}, function (e) {
                self.chirps(e);
            });
        }

        $.subscribe("reload", function () {
            self.loadChirps();
        });


        this.loadChirps();
    });
})();
