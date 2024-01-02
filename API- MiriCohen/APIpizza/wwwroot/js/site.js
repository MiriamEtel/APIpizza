let basicUrl = 'https://localhost:5001';

function getAllPizzas() {
    var urli = `${basicUrl}/api/pizza/get`;
    fetch(urli).then(response => response.json())
        .then(json => fillPizzaList(json))
        .catch(error => console.log('Authorization failed: ' + error.message));
}
function fillPizzaList(pizzaList) {
    var tbody = document.getElementById('pizzatbody');
    tbody.innerHTML = "";
    pizzaList.forEach(pizza => {
        var tr = `<tr>
         <td>${pizza.id}</td>
        <td>${pizza.name}</td>
        <td>${pizza.price}</td>
        <td>${pizza.gluten}</td>
        </tr>`
        tbody.innerHTML += tr;
    });
}
function getById() {
    let iddom = document.getElementById("Byid");
    let id = iddom.value;
    var urli = `${basicUrl}/api/pizza/GetById/${id}`;
    fetch(urli).then(response => response.json())
        .then(json => getPizzaById(json))
        .catch(error => console.log('Authorization failed: ' + error.message));
}

function getPizzaById(data) {
    let tbody = document.getElementById('pizzatbody');
    var tr = `<tr>
    <td>${data.name}</td>
    <td>${data.price}</td>
    <td>${data.gluten}</td>
    </tr>`
    tbody.innerHTML += tr;
}
function create() {
    let name = document.getElementById("createName").value;
    let price = parseInt(document.getElementById("createPrice").value);
    let gluten = document.getElementById("createGluten").willValidate;
    var urli = `${basicUrl}/api/pizza/Create/${name}/${gluten}/${price}`;

    var raw = "";
    var requestOptions = {
        method: 'POST',
        body: raw,
        redirect: 'follow'
    };
    fetch(urli, requestOptions)
        .then(response => response.text())
        .catch(error => console.log('error', error));
}

function change() {
    let name = document.getElementById("new_name").value;
    let price = parseInt(document.getElementById("price").value);
    let id = document.getElementById("idname").value;
    let gluten = document.getElementById("gluten").willValidate;
    var urli = `${basicUrl}/api/pizza/upDate/${id}/${name}/${gluten}/${price}`;

    var raw = "";
    var requestOptions = {
        method: 'PUT',
        body: raw,
        redirect: 'follow'
    };
    fetch(urli, requestOptions)
        .then(response => response.text())
        .then(result => console.log(result))
        .catch(error => console.log('error', error));
}