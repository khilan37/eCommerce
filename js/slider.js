var i = 0;
var images = [];
var time = 3000;
images[0] = 'images/yourmart.jpg';
images[1] = 'images/w1.jpg';
images[2] = 'images/logo8.jpg';
function changeImg() {
    document.slide.src = images[i];
    if (i < images.length - 1) {
        i++;
    }
    else {
        i = 0;
    }
    setTimeout("changeImg()", time);
}
window.onload = changeImg;

