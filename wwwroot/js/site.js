// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var list = [1, 2, 3];
var listCount = list.length;

const addToCart = (id, quantity, price) => {
    let object = { id, quantity, price };

    for (i = 0; i < list.length;i++) {
        if (list[i] = id) {
            object = id, (quantity + list[i].quantity), price
            list[i] = object
            return
        }
        else {
            return list = object.push;
        }
    }
}
