Bifrost.namespace("Chirp", {
    streamFeature: Bifrost.Type.extend(function (readingStream, sessionManager) {

        //Bifrost.features.featureManager.get("stream").defineViewModel(function () {
            var self = this;
            var session = sessionManager;


            this.chirps = ko.observableArray();

            this.loadChirps = function () {
                //$.get("/Streamer/GetReadingStreamFor", { reader: session.getCurrentUserId() }, function (e) {
                //    self.chirps(e);
                //});
                var stream = readingStream.byReader(session.getCurrentUserId());
                self.chirps(stream);
            }

            $.subscribe("reload", function () {
                self.loadChirps();
            });


            this.loadChirps();
        })
});

Bifrost.features.featureManager.get("stream").defineViewModel(Chirp.streamFeature);
