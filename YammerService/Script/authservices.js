function async_addScript(d, id, url) {
	var s = "script";
	var js, fjs = d.getElementsByTagName(s)[0];
	if (d.getElementById(id)) return;
	js = d.createElement(s); js.id = id;
	js.src = url;
	fjs.parentNode.insertBefore(js, fjs);
};

//load script from configured AuthApiConfig
(function () {
	async_addScript(document, "authservice", AuthApiConfig.scriptUrlRoot + "/" + AuthApiConfig.service + ".js");
})();