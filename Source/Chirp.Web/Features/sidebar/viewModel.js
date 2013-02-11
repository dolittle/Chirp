Bifrost.namespace("Chirp", {
    sidebar : Bifrost.Type.extend(function (chirpMessage, sessionManager) {
        var self = this;
        var session = sessionManager;


        function newChirp(message) {
            return {
                id: ko.observable(Bifrost.Guid.create()),
                content: ko.observable(message || "")
            };
        }

        this.message = ko.observable("");

        this.chirpMessageCommand = chirpMessage;

        this.chirpMessage = function () {
            var command = self.chirpMessageCommand;
            command.chirper(session.getCurrentUserId());
            command.chirp = newChirp(self.message());
            command.execute();


            setTimeout(function () {
                $.publish("reload");
            }, 1000);
        };

        //this.chirpMessageCommand = Bifrost.commands.Command.create({
        //    options: {
        //        name: "ChirpMessage",
        //        properties: {
        //            chirper: ko.observable(session.getCurrentUserId()),
        //            chirp: newChirp()
        //        },
        //        beforeExecute: function (command) {
        //            command = self.chirpMessageCommand;
        //            var chirp = command.chirp();
        //            chirp.id(Bifrost.Guid.create());
        //            command.chirp(chirp);
        //        },
        //        error: function () { debugger; },
        //        complete: function () {
        //            self.chirpMessageCommand.chirp = newChirp()
        //            $.publish("reload");
        //        }
        //    }
        //});



        this.isEditing = ko.observable(false);
        this.availableLettersCount = ko.computed(function () {
            return 140 - this.message().length;
        }, this);

        this.shouldShowRemainingCharCount = ko.computed(function () {
            return this.isEditing() && this.availableLettersCount() < 50;
        }, this);
    })
});


Bifrost.features.featureManager.get("sidebar").defineViewModel(Chirp.sidebar);
