Bifrost.namespace("Chirp.Features", {
    status: Bifrost.Type.extend(function (sessionManager) {
        var self = this;
        var session = sessionManager;

        function switchToLogin() {
            self.feature("login");
        }

        function switchToStatus() {
            self.feature("userStatus");
        }


        this.feature = ko.observable("login");
        this.isUserLoggedIn = ko.observable(false);

        this.isUserLoggedIn.subscribe(function (newValue) {
            if (newValue === true)
                switchToStatus();
            else
                switchToLogin();
        });

        $.subscribe("changeUser", switchToLogin);
        $.subscribe("loggedIn", switchToStatus);

        if (session.isUserLoggedIn)
            switchToStatus();

    })
});
Bifrost.features.featureManager.get("status").defineViewModel(Chirp.Features.status);