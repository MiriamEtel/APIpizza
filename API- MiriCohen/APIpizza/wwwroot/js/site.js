let basicUrl = 'https://localhost:5001';
let myToken="";
let myRaw="";
var headerAuthorize=new Headers();
headerAuthorize.append("Authorization",myToken);
headerAuthorize.append("Content-Type","application/json");

var Raw=JSON.stringify({
    "name":"Miriam Cohen",
    "password":"111m"
})

function login(){
    let name=document.getElementById("logname").value;
    let password=document.getElementById("logpassword").value;
     
    raw=JSON.stringify({
      "name":name,
       "password":password,
    })
    myRaw=raw;
    var requestOptions={
        method:'POST',
        Headers:headerAuthorize,
        body:raw,
        redirect:'follow'
    }
    var urli= `${basicUrl}/api/Login/Login/Login`;
    fetch(urli,requestOptions)
         .then(respose => respose.text())
         .then(ref => loginlogin(ref))
         .then(result => console.log(result))
         .catch(error => alert('error:please login',error.message));

}

function loginlogin(tokenforyou){
    myToken=`Bearer ${tokenforyou}`;
    headerAuthorize.append("Authorization",myToken);
    headerAuthorize.append("Content-Type","application/json");
    alert("Wellcome!!! you are connected 💝 ")
    return `Bearer ${tokenforyou}`;
}

//pizzas

function getAllPizzas() {
    var urli = `${basicUrl}/api/pizza/get`;
    fetch(urli).then(response => response.json())
        .then(json => fillPizzaList(json))
        .catch(error => console.log('Authorization failed: ' + error.message));
}

function fillPizzaList(pizzaList) {
    var tbody = document.getElementById('pizzatbody');
    tbody.innerHTML = `<b><tr><th>Id</th><th>Name</th><th>Price</th><th>Gluten Free</th></tr></b>`;
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
        .catch(error => alert('error: '+error.message));
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
    let gluten = document.getElementById("createGluten").checked;
    var urli = `${basicUrl}/api/pizza/Create/${name}/${gluten}/${price}`;


    var requestOptions = {
        method: 'POST',
        headers:myHeaders,
        body: raw,
        redirect: 'follow'
    };
    fetch(urli, requestOptions)
        .then(response => response.json())
        .catch(error => alert('error:' ,error.message));
}

function change() {
    var myHeaders = new Headers();
    headerAuthorize.append("Authorization",myToken);
    headerAuthorize.append("Content-Type","application/json");
    let name = document.getElementById("new_name").value;
    var raw=myRaw;

    let price = parseInt(document.getElementById("price").value);
    let id = document.getElementById("idname").value;
    let gluten = document.getElementById("gluten").willValidate;
    var urli = `${basicUrl}/api/pizza/upDate/${id}/${name}/${gluten}/${price}`;

    var raw = "";
    var requestOptions = {
        method: 'PUT',
        headers:myHeaders,
        body: raw,
        redirect: 'follow'
    };
    fetch(urli, requestOptions)
        .then(response => response.text())
        .then(result => console.log(result))
        .catch(error => alert('error: ', error.message));
}

//workers
function getAllWorkers(){
var myHeaders = new Headers();
    headerAuthorize.append("Authorization",myToken);
    headerAuthorize.append("Content-Type","application/json");
    var raw=myRaw;

    var requestOptions = {
        method: 'GET',
        headers:myHeaders,
        redirect: 'follow'
    };

    var urli = `${basicUrl}/api/worker/get`;
    fetch(urli,requestOptions)
    .then(response => response.json())
        .then(json => fillWorkerList(json))
        .catch(error => alert('error: '+error.message));
}

function fillWorkerList(workerList){
    var tbody =document.getElementById('workertbody');
    tbody.innerHTML = `<b><tr><th>Id</th><th>Name</th><th>Role</th></tr></b>`;
    workerList.forEach(w =>{
        var tr = `<tr>
        <td>${w.id}</td>
        <td>${w.name}</td>
        <td>${w.role}</td>
        </tr>`
        tbody.innerHTML += tr;   
    })
}

function getWorkerById(){
    var myHeaders = new Headers();
    headerAuthorize.append("Authorization",myToken);
    headerAuthorize.append("Content-Type","application/json");
    var raw=myRaw;
    let id=document.getElementById("wByid").value;
    var urli = `${basicUrl}/api/worker/GetById`;

    var requestOptions = {
        method: 'GET',
        headers:myHeaders,
        redirect: 'follow'
    };

    
    fetch(urli,requestOptions)
    .then(response => response.json())
        .then(json =>getwById(json))
        .catch(error => alert('error: '+error.message));  
}

function getById(data){
    let tbody =document.getElementById('workertbody');  
    var tr = `<tr>
    <td>${data.id}</td>
    <td>${data.name}</td>
    <td>${data.role}</td>
    </tr>`
    tbody.innerHTML +=tr;

}

function createWorker(){
    var myHeaders = new Headers();
    headerAuthorize.append("Authorization",myToken);
    headerAuthorize.append("Content-Type","application/json");
    var raw=myRaw;

    let name=document.getElementById("createWorkerName").value;
    let password=document.getElementById("createWorkerPass").value;
    let role=document.getElementById("createWorkerRole").value;  
    var urli=`${basicUrl}/api/worker/Create/${name}/${password}/${role}`;

    var requestOptions = {
        method: 'POST',
        headers:myHeaders,
        body:raw,
        redirect: 'follow'
    };
    fetch(urli,requestOptions)
        .catch(error => alert('error: ' , error.message));  
}

function changeWorker(){
    var myHeaders = new Headers();
    headerAuthorize.append("Authorization",myToken);
    headerAuthorize.append("Content-Type","application/json");
    var raw=myRaw;  
    
    
    let name=document.getElementById("newWorkerName").value;
    let id=parseInt(document.getElementById("idWorker")).value;
    let password=document.getElementById("newWorkerPass").value;
    let role=document.getElementById("newWorkerRole").value;  
    var urli=`${basicUrl}/api/worker/Create/${name}/${password}/${role}`;

    var requestOptions = {
        method: 'PUT',
        headers:myHeaders,
        body:raw,
        redirect: 'follow'
    };
    fetch(urli,requestOptions)
        .then(response => response.json())
        .then(result => console.log(result))
        .catch(error => alert('error: ' , error.message));  
}