function startAutoLogout() {
    window.setTimeout(function(){
        document.location ="/";
    }, 10000);

    window.setTimeout(function(){
        document.getElementById("lblExpire").innerHTML = "WARNING : Session is about to close";
    }, 8000);
}