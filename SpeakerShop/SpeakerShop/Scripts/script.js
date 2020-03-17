var btn = document.getElementById('my_button_sing_in');
var modal = document.getElementById('lg');

btn.onclick = function () {
    modal.style.display = "block";
}

window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}