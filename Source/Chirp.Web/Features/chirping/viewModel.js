Bifrost.namespace("Chirp.Features", {
    chirping : Bifrost.Type.extend(function (chirpMessage, sessionManager) {
        var self = this;
        var session = sessionManager;

        
        this.message = ko.observable("");

        this.chirpMessageCommand = chirpMessage;

        this.chirpMessageCommand.setOptions({
            error: function (commandResult) {
                console.log(commandResult);
            },
            success: function () {
                $.publish("reload");
                self.message("");
            }

        });

        this.chirpMessage = function () {
            var command = self.chirpMessageCommand;
            command.chirper(session.getCurrentUserId());
            command.chirp.id(Bifrost.Guid.create());
            command.chirp.content(self.message());
            command.execute();
        };


        this.isEditing = ko.observable(false);
        this.availableLettersCount = ko.computed(function () {
            return 140 - this.message().length;
        }, this);

        this.shouldShowRemainingCharCount = ko.computed(function () {
            return this.isEditing() && this.availableLettersCount() < 50;
        }, this);
    })
});


Bifrost.features.featureManager.get("chirping").defineViewModel(Chirp.Features.chirping);
