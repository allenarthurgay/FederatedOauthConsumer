function async_addScript(d, id, url) {
	var s = "script";
	var js, fjs = d.getElementsByTagName(s)[0];
	if (d.getElementById(id)) return;
	js = d.createElement(s); js.id = id;
	js.src = url;
	fjs.parentNode.insertBefore(js, fjs);
};

function isRegisteredForService(servicename) {
    var serviceUrl = "/" + AuthApiConfig.principalId +"/"+ servicename + "/isregistered?format=json";
    alert(serviceUrl);
    $.get(serviceUrl, function (data) {

        alert(JSON.stringify(data.isRegistered));
    });
}

function getSupportedServices() {
    var serviceUrl =  "/supportedservices?format=json";
    $.get(serviceUrl, function(data) {
        alert(JSON.stringify(data));
    });
}

//load script from configured AuthApiConfig
(function () {
	async_addScript(document, "authservice", AuthApiConfig.scriptUrlRoot + "/" + AuthApiConfig.service + ".js");
})();