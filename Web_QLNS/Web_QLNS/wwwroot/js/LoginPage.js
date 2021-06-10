let btnLogin = document.getElementById("loginBtn");
let loginOverlay = document.getElementById("login__Overlay");
let loginBG = document.getElementById("login__bg");

btnLogin.onmouseover = () => {
    loginOverlay.style.width = "75%";
    loginBG.style.background = "url(../img/background/background_Login02.png) no-repeat";
    loginBG.style.backgroundSize = 'cover';
}

btnLogin.onmouseout = () => {
    loginOverlay.style.width = "50%";
    loginBG.style.background = "url(../img/background/background_Login01.png) no-repeat";
    loginBG.style.backgroundSize = 'cover';
}
