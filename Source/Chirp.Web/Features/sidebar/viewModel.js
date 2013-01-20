(function (undefined) {
    Bifrost.features.featureManager.get("sidebar").defineViewModel(function () {
        var self = this;

        this.chirpMessageCommand = Bifrost.commands.Command.create({
            options: {
                name: "ChirpMessage",
                properties: {
                    publisher: ko.observable(Bifrost.Guid.empty),
                    message: {
                        id: ko.observable(Bifrost.Guid.empty),
                        content: ko.observable("")
                    }
                },
                beforeExecute: function (command) {
//                    command.message.id.value(Bifrost.Guid.create());
                },
                complete: function () {
                    self.chirpCommand.parameters.message("");
                    $.publish("reload");
                }
            }
        });
        this.isEditing = ko.observable(false);
        this.availableLettersCount = ko.computed(function () {
            return 140 - this.chirpMessageCommand.message().content().length;
        }, this);

        this.shouldShowRemainingCharCount = ko.computed(function () {
            return this.isEditing() && this.availableLettersCount() < 50;
        }, this);
    });
})();
