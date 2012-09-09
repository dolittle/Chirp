/*	

jQuery pub/sub plugin by Peter Higgins (dante@dojotoolkit.org)

Loosely based on Dojo publish/subscribe API, limited in scope. Rewritten blindly.

Original is (c) Dojo Foundation 2004-2010. Released under either AFL or new BSD, see:
http://dojofoundation.org/license for more information.

*/

; (function (d) {

    // the topic/subscription hash
    var cache = {};

    d.publish = function (/* String */topic, /* Array? */args) {
        // <summary> 
        //		Publish some data on a named topic.
        //</summary>topic: String
        //		The channel to publish on
        // args: Array?
        //		The data to publish. Each array item is converted into an ordered
        //		arguments on the subscribed functions. 
        //
        // example:
        //		Publish stuff on '/some/topic'. Anything subscribed will be called
        //		with a function signature like: function(a,b,c){ ... }
        //
        //	|		$.publish("/some/topic", ["a","b","c"]);
        cache[topic] && d.each(cache[topic], function () {
            var arg = d.isArray(args) ? args : [args];
            this.apply(this, arg || []); 
        });
    };

    d.subscribe = function (/* String */topic, /* Function */callback) {
        // <summary>
        //		Register a callback on a named topic.
        //</summary>topic: String
        //		The channel to subscribe to
        // callback: Function
        //		The handler event. Anytime something is $.publish'ed on a 
        //		subscribed channel, the callback will be called with the
        //		published array as ordered arguments.
        //
        // returns: Array
        //		A handle which can be used to unsubscribe this particular subscription.
        //	
        // example:
        //	|	$.subscribe("/some/topic", function(a, b, c){ /* handle data */ });
        //
        if (!cache[topic]) {
            cache[topic] = [];            
        }       
        cache[topic].push(callback);
        return [topic, callback]; // Array
    };

    d.logSubscriptions = function() {
        if(console && console.log) console.log("[PubSub] current subscriptions:");
        for(var p in cache) {
            if (console && console.log) console.log(p);
        }
        if(console && console.log) console.log("[/PubSub]");
    };

    d.unsubscribeAllFor = function(topic) {
          // <summary>
        //		Remove all handlers for a topic (wildcard before the slash) eg. 'CommPkg' will remove CommPkg/save CommPkg/delete etc
        //</summary>
        //var wildcards = d.grep(d.makeArray(cache), function (el,i) {
        for(var p in cache) {
            var arr = p.split("/");
            if(arr.length != 2){ continue; }
            if( arr[0] == topic) cache[p] = [];
        }
    };

    d.subscribeOnce = function (/* String */topic, /* Function */callback) {
        // <summary>
        //		Register a callback on a named topic IF IT DOES NOT ALREADY EXIST.
        //</summary>topic: String
        //		The channel to subscribe to
        // callback: Function
        //		The handler event. Anytime something is $.publish'ed on a 
        //		subscribed channel, the callback will be called with the
        //		published array as ordered arguments.
        //
        // returns: Array
        //		A handle which can be used to unsubscribe this particular subscription.
        //	
        // example:
        //	|	$.subscribe("/some/topic", function(a, b, c){ /* handle data */ });
        //
        if (!cache[topic]) {
            cache[topic] = [];            
            cache[topic].push(callback);
        }
        return [topic, callback]; // Array
    };

    d.subscribeMany = function (events, callback) {
        // <summary>
        //		Register a callback on a named topic.
        //</summary>topic: String array
        //		The channel to subscribe to
        // callback: Function
        //		The handler event. Anytime something is $.publish'ed on a 
        //		subscribed channel, the callback will be called with the
        //		published array as ordered arguments.
        //
        // returns: Array
        //		A handle which can be used to unsubscribe this particular subscription.
        //	
        // example:
        //	|	$.subscribe("/some/topic", function(a, b, c){ /* handle data */ });
        //
        var result = {};
        $.each(events, function (i, topic) {
            if (!cache[topic]) {
                cache[topic] = [];                
            }            
            cache[topic].push(callback);
            result[topic] = [];
            result[topic].push(callback);
        });
        return result; // Array
    };

     d.unsubscribe = function (/* Array or topic */handle) {
        // <summary>
        //		Disconnect a subscribed function for a topic.</summary>
        // handle: if Array
        //		    The return value from a $.subscribe call.
        //         if String 
        //          a topic. Will clear ALL subscriptions for the given topic
        // example:
        //	|	var handle = $.subscribe("/something", function(){});
        //	|	$.unsubscribe(handle);
        if($.isArray(handle)) {
            var t = handle[0];
            cache[t] && d.each(cache[t], function(idx) {
                if (this == handle[1]) {
                    cache[t].splice(idx, 1);
                }
            });
        }else {
            if (cache[handle]) {
                cache[handle] = [];  //clear all handlers for the topic
            }     
        }
    };

})(jQuery);
