Bifrost.namespace("Chirp.Features", {
    loginUser: Bifrost.Type.extend(function (login,sessionManager) {
        var self = this;
        var session = sessionManager;

        console.log(session);

        function clearMessages() {
            self.message("");
        }

        this.message = ko.observable("");

        this.canEnterPassword = ko.observable(false);
        
        this.loginCommand = login;

        this.loginCommand.setOptions({
            success: function () {
                session.getUserIdFor(self.loginCommand.userName()).continueWith(function (userId) {
                    session.setSessionId(userId);
                    History.pushState({}, "", "/home");
                });
            }
        });
        this.login = function () {
            self.loginCommand.password(self.loginCommand.userName() + "dummyPassword");
            self.loginCommand.execute();
        };
    })
});

Bifrost.features.featureManager.get("login").defineViewModel(Chirp.Features.loginUser);
