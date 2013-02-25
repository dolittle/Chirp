Bifrost.namespace("Chirp.Features", {
    stream: Bifrost.Type.extend(function (readingStreamForReader, sessionManager) {

            var self = this;
            var session = sessionManager;
            
            readingStreamForReader.readerId(session.getCurrentUserId());

            this.loadChirps = function () {
                readingStreamForReader.execute();
            };

            $.subscribe("reload", function () {
                self.loadChirps();
            });

            this.streams = readingStreamForReader.all();

            this.chirps = ko.computed(function () {
                if (self.streams().length) {
                    var theChirps = self.streams()[0].content;
                    return theChirps;
                }
                return [];
            });
    })
});

Bifrost.features.featureManager.get("stream").defineViewModel(Chirp.Features.stream);
