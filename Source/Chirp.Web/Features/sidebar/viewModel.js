(function (undefined) {
    Bifrost.features.featureManager.get("sidebar").defineViewModel(function () {
        var self = this;
        var session = Bifrost.dependencyResolver.resolve(Chirp, "Session");


        function newChirp() {
            return ko.observable({
                        id: ko.observable(Bifrost.Guid.create()),
                        content: ko.observable("")
                    });
        }

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
            return 140 - this.chirpMessageCommand.chirp().content().length;
        }, this);

        this.shouldShowRemainingCharCount = ko.computed(function () {
            return this.isEditing() && this.availableLettersCount() < 50;
        }, this);
    });
})();
