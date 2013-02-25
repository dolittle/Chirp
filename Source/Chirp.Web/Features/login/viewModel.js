Bifrost.namespace("Chirp", {
    loginFeature: Bifrost.Type.extend(function (login,sessionManager) {
        var self = this;
        var session = sessionManager;

        console.log(session);

        function clearMessages() {
            self.message("");
        }

        this.message = ko.observable("");

        this.canEnterPassword = ko.observable(false);
        
        this.loginCommand = login;
        this.login = function () {
            self.loginCommand.password(self.loginCommand.userName() + "dummyPassword");
            self.loginCommand.execute();

            setTimeout(function myfunction() {
                session.getUserIdFor(self.loginCommand.userName()).continueWith(function (userId) {
                    session.setSessionId(userId);
                    History.pushState({}, "", "/home");
                });
            }, 2000);
        };
    })
});

Bifrost.features.featureManager.get("login").defineViewModel(Chirp.loginFeature);
