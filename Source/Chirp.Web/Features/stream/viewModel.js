Bifrost.namespace("Chirp", {
    streamFeature: Bifrost.Type.extend(function (readingStreamForReader, sessionManager) {

        //Bifrost.features.featureManager.get("stream").defineViewModel(function () {
            var self = this;
            var session = sessionManager;

            this.chirps = readingStreamForReader.all();

            this.loadChirps = function () {
                //$.get("/Streamer/GetReadingStreamFor", { reader: session.getCurrentUserId() }, function (e) {
                //    self.chirps(e);
                //});
                //var stream = readingStream.byReader(session.getCurrentUserId());

                readingStreamForReader.readerId(session.getCurrentUserId());
                readingStreamForReader.execute();
            }

            $.subscribe("reload", function () {
                self.loadChirps();
            });


            this.loadChirps();
        })
});

Bifrost.features.featureManager.get("stream").defineViewModel(Chirp.streamFeature);
