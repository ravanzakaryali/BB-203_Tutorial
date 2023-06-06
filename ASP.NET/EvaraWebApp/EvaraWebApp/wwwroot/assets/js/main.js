//let addCartbutton = document.getElementsByClassName("addCartButton");

let countCart = document.getElementById("cartCount");
function addCart(elm) {
    let id = elm.value;
    fetch(`/product/AddCart/${id}`)
        .then(res => res.json())
        .then(data => {
            console.log(data);
            countCart.innerHTML = data;
        });
    toastr.success('Success add cart');
}