// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var yesBtn = document.getElementById("yesBtn");
var thinkBtn = document.getElementById("thinkBtn");

var swapped = false;

// Hover OR touch should trigger swap
function swapButtons() {
    if (!swapped) {
        yesBtn.style.transform = "translateX(160px)";
        thinkBtn.style.transform = "translateX(-160px)";
    } else {
        yesBtn.style.transform = "translateX(0)";
        thinkBtn.style.transform = "translateX(0)";
    }

    swapped = !swapped;
}

// Desktop hover
thinkBtn.addEventListener("mouseenter", swapButtons);

// Mobile touch
thinkBtn.addEventListener("touchstart", function (e) {
    e.preventDefault();
    swapButtons();
});

// Disable click on "Let me think"
thinkBtn.addEventListener("click", function (e) {
    e.preventDefault();
});

// Yes click (only allowed action)
yesBtn.addEventListener("click", function () {
    window.location.href = "/Yes?key=ourSecretKey123";
});



