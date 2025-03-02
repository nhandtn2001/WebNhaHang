﻿var indicator = document.querySelector('.my-bar-nav-indicator');
var items = document.querySelectorAll('.my-bar-nav-item');
function handleIndicator(el) {
    items.forEach(function (item) {
        item.classList.remove('is-active');
        item.removeAttribute('style');
    });
    indicator.style.width = "".concat(el.offsetWidth, "px");
    indicator.style.left = "".concat(el.offsetLeft, "px");
    indicator.style.backgroundColor = el.getAttribute('active-color');
    el.classList.add('is-active');
    el.style.color = el.getAttribute('active-color');
}
items.forEach(function (item, index) {
 /*   item.addEventListener('click', function (e) {
        handleIndicator(e.target);
    });
    */
    item.classList.contains('is-active') && handleIndicator(item);
});