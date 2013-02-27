Bifrost.namespace("Chirp.Features", {
    userStatus: Bifrost.Type.extend(function (sessionManager) {
        var session = sessionManager;

        this.userName = ko.observable("");
        this.changeUser = function () {
            $.publish("changeUser");
        }
        this.userName(session.getCurrentUserName());
    })
});
Bifrost.features.featureManager.get("userStatus").defineViewModel(Chirp.Features.userStatus);