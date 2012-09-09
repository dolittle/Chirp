(function (undefined) {
    Bifrost.features.featureManager.get("sidebar").defineViewModel(function () {
        var self = this;

        this.chirpCommand = Bifrost.commands.Command.create({
            name: "Chirp",
            parameters: {
                message: ko.observable("")
            },
            complete: function () {
                self.chirpCommand.parameters.message("");
                $.publish("reload");
            }
        });
        this.isEditing = ko.observable(false);
        this.availableLettersCount = ko.computed(function () {
            return 140 - self.chirpCommand.parameters.message().length;
        });

    });
})();
