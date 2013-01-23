(function (undefined) {
    Bifrost.features.featureManager.get("login").defineViewModel(function () {
        var self = this;

        function clearMessages() {
            self.message("");
        }

        this.message = ko.observable("");

        this.canEnterPassword = ko.observable(false);

        this.loginCommand = Bifrost.commands.Command.create({
            options: {
                name: "Login",
                context: self,
                properties: {
                    userName: ko.observable(""),
                    password: ko.observable("")
                },
                beforeExecute: clearMessages,
                success: function () {
                    History.pushState({}, "", "/home");
                },
                error: function (e) {
                    if (e.validationResults.length) {
                        self.message(e.validationResults[0].errorMesssage);
                    }
                    if (e.commandValidationMessages && e.commandValidationMessages.length) {
                        self.message(e.commandValidationMessages[0]);
                    }
                }
            }
        });

    });
})();
