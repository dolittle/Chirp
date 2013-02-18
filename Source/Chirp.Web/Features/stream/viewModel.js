Bifrost.namespace("Chirp", {
    streamFeature: Bifrost.Type.extend(function (readingStreamForReader, sessionManager) {

        //Bifrost.features.featureManager.get("stream").defineViewModel(function () {
            var self = this;
            var session = sessionManager;
            
            readingStreamForReader.readerId(session.getCurrentUserId());

            this.loadChirps = function () {
                //$.get("/Streamer/GetReadingStreamFor", { reader: session.getCurrentUserId() }, function (e) {
                //    self.chirps(e);
                //});
                //var stream = readingStream.byReader(session.getCurrentUserId());
                readingStreamForReader.execute();
            }

            $.subscribe("reload", function () {
                self.loadChirps();
            });

            this.streams = readingStreamForReader.all();
        //this.loadChirps();
            this.chirps = ko.computed(function () {
                if (self.streams().length) {
                    var theChirps = self.streams()[0].content;
                    return theChirps;
                }
                return [];
            });
    })
});

Bifrost.features.featureManager.get("stream").defineViewModel(Chirp.streamFeature);
