(function (undefined) {
    Bifrost.features.featureManager.get("login").defineViewModel(function () {
        var self = this;

        this.message = ko.observable("");

        this.login = Bifrost.commands.Command.create({
            options: {
                name: "Login",
                context: self,
                properties: {
                    userName: ko.observable(),
                    password: ko.observable()
                },
                beforeExecute: function (command) {
                    self.message("");
                },
                success: function () {
                    History.pushState({}, "", "/home");
                },
                error: function (e) {
                    if (e.validationResults.length > 0) {
                        self.message(e.validationResults[0].errorMessage);
                    }
                }
            }
        });

        this.resetPassword = Bifrost.commands.Command.create({
            options: {
                name: "ResetPassword",
                context: self,
                properties : {
                    userName: ko.computed(function () {
                        return self.login.userName();
                    })
                },
                beforeExecute: function (command) {
                },
                success: function () {
                    self.message("Password has been reset, you will receive an email with the new password");
                },
                error: function () {
                }
            }
        });
    });
})();
