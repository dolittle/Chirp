require.config({
	appDir: "/",
	baseUrl: "/scripts",
	optimize: "none",

	paths: {
	    "jquery": "jquery-1.7.1.min",
	    "knockout": "knockout-2.0.0",
		"knockout.mapping": "knockout.mapping-2.0.0",
	    "bifrost": "Bifrost.debug",
	    "order": "order",
	    "domReady": "domReady",
	    "text": "text",
	    "bootstrap": "bootstrap",
	    "bootstrap-collapse": "bootstrap-collapse",
	    "marked": "marked",
        "pubsub": "pubsub-min",
        "session": "session",
        "cookies" : "jquery.cookies.2.2.0"
	}
});

// "http://cdn.dolittle.com/Bifrost/Bifrost.debug",


require(
    ["jquery", "knockout"],
	function () {
	    require(["jquery.history", "pubsub"],
		    function () {
		        require(["knockout.mapping", "bifrost", "bootstrap", "knockout.plugins"],
		            function () {
		                require(["cookies", "session"]);
		                Bifrost.features.featureMapper.add("{feature}/{subFeature}", "/Features/{feature}/{subFeature}", false);
		                Bifrost.features.featureMapper.add("{feature}", "/Features/{feature}", true);
		                require(["/index.js"]);
		            }
		        );
		    }
		);
	}
);
