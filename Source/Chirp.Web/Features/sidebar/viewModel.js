(function (undefined) {
    Bifrost.features.featureManager.get("sidebar").defineViewModel(function () {
        var self = this;

        function newChirp() {
            return ko.observable({
                        id: ko.observable(Bifrost.Guid.create()),
                        content: ko.observable("")
                    });
        }

        this.chirpMessageCommand = Bifrost.commands.Command.create({
            options: {
                name: "ChirpMessage",
                properties: {
                    chirper: ko.observable("03F1D667-063B-4D15-B892-06F89818E9A8"),
                    chirp: newChirp()
                },
                beforeExecute: function (command) {
                    command = self.chirpMessageCommand;
                    var chirp = command.chirp();
                    chirp.id(Bifrost.Guid.create());
                    command.chirp(chirp);
                    //                    command.id(Bifrost.Guid.create);
                },
                success: function () { debugger; },
                error: function () { debugger; },
                complete: function () {
                    self.chirpMessageCommand.chirp = newChirp()
                    $.publish("reload");
                }
            }
        });



        this.isEditing = ko.observable(false);
        this.availableLettersCount = ko.computed(function () {
            return 140 - this.chirpMessageCommand.chirp().content().length;
        }, this);

        this.shouldShowRemainingCharCount = ko.computed(function () {
            return this.isEditing() && this.availableLettersCount() < 50;
        }, this);
    });
})();
