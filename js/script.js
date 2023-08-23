function myfun() {
    if (document.getElementById("search").style.height == "0px" && document.getElementById("search").style.visibility == "hidden") {
        document.getElementById("search").style.height = "73px";
        document.getElementById("search").style.visibility = "visible";
        document.getElementById("search").style.opacity = "1";
        document.getElementById("s-txt").style.marginRight = "0px";
    }
    else {
        document.getElementById("search").style.height = "0px";
        document.getElementById("search").style.visibility = "hidden";
        document.getElementById("search").style.opacity = "0";
        document.getElementById("s-txt").style.marginRight = "50px";

    }
}
