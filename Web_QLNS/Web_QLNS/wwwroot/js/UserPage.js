let btnBangLuong = document.getElementById("btnBangLuong");
let btnBangChamCong = document.getElementById("btnBangChamCong");
let btnChamCong = document.getElementById("btnChamCong");
let BangLuongOverlay = document.getElementById("BangLuong__overlay");
let Avatar = document.getElementById("Avatar");

let BangLuong = document.getElementsByClassName("BangLuong");
let BangChamCong = document.getElementsByClassName("BangChamCong");

console.log("UserPage JS");

btnBangLuong.onmouseover = () => {
    BangLuongOverlay.style.width = "123%";
    Avatar.style.left = "75%";
    Avatar.style.transform = "translate(-50%, 145%)";
    Avatar.style.width = "200px";
    Avatar.style.height = "200px";
    Avatar.style.border = "15px solid #FFFFFF";
    BangChamCong[0].style.display = "none";
};

btnBangLuong.onmouseleave = () => {
    BangLuongOverlay.style.width = "100%";
    Avatar.removeAttribute("style");
    BangChamCong[0].removeAttribute("style");
};

btnBangChamCong.onmouseover = () => {
    BangLuongOverlay.style.width = "73%";
    Avatar.style.left = "23%";
    Avatar.style.transform = "translate(-50%, 145%)";
    Avatar.style.width = "200px";
    Avatar.style.height = "200px";
    Avatar.style.border = "15px solid #FFFFFF";
    btnBangLuong.style.display = "none";
};

btnBangChamCong.onmouseleave = () => {
    BangLuongOverlay.style.width = "100%";
    Avatar.removeAttribute("style");
    btnBangLuong.removeAttribute("style");
};

const setTimeBtnChamCong = () => {
    let now = new Date();
    if (now.getHours() > 7) {
        btnChamCong.classList.remove("btn-success");
        btnChamCong.classList.add("btn-danger");
    }
    console.log(now.getHours());
}
setTimeBtnChamCong();