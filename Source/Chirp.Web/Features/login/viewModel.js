Bifrost.namespace("Chirp", {
    loginFeature: Bifrost.Type.extend(function (login,Session) {
        var self = this;
        var session = Session;

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

        //this.loginCommand = Bifrost.commands.Command.create({
        //    options: {
        //        name: "Login",
        //        context: self,
        //        properties: {
        //            userName: ko.observable(""),
        //            password: ko.observable("")
        //        },
        //        beforeExecute: clearMessages,
        //        success: function () {
        //            session.getUserIdFor(self.loginCommand.userName()).continueWith(function (userId) {
        //                session.setSessionId(userId);
        //                History.pushState({}, "", "/home");
        //            });
        //        },
        //        error: function (e) {
        //            if (e.validationResults.length) {
        //                self.message(e.validationResults[0].errorMesssage);
        //            }
        //            if (e.commandValidationMessages && e.commandValidationMessages.length) {
        //                self.message(e.commandValidationMessages[0]);
        //            }
        //        }
        //    }
        //});

    })
});


//(function (undefined) {
Bifrost.features.featureManager.get("login").defineViewModel(Chirp.loginFeature);
//        //function () {
//        //var self = this;
//        //var session = Bifrost.dependencyResolver.resolve(Chirp, "Session");

//        //console.log(session);

//        //function clearMessages() {
//        //    self.message("");
//        //}

//        //this.message = ko.observable("");

//        //this.canEnterPassword = ko.observable(false);

//        //this.loginCommand = Bifrost.commands.Command.create({
//        //    options: {
//        //        name: "Login",
//        //        context: self,
//        //        properties: {
//        //            userName: ko.observable(""),
//        //            password: ko.observable("")
//        //        },
//        //        beforeExecute: clearMessages,
//        //        success: function () {
//        //            session.getUserIdFor(self.loginCommand.userName()).continueWith(function (userId) {
//        //                session.setSessionId(userId);
//        //                History.pushState({}, "", "/home");
//        //            });
//        //        },
//        //        error: function (e) {
//        //            if (e.validationResults.length) {
//        //                self.message(e.validationResults[0].errorMesssage);
//        //            }
//        //            if (e.commandValidationMessages && e.commandValidationMessages.length) {
//        //                self.message(e.commandValidationMessages[0]);
//        //            }
//        //        }
//        //    }
//        //});

////    }
//);
//})();
