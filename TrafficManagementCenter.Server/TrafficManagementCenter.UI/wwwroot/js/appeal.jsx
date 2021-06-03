var urlAllTypes = 'http://localhost:8070/api/citizens/alltypes';
var urlAllClasses  = 'http://localhost:8070/api/citizens/allclasses';


var typeSelect = document.getElementById("typeappeal");
var subtypeSelect = document.getElementById("subtypesappeal");
var classAppealSelect = document.getElementById("classappeal");

let myFetchAllTypes = fetch(urlAllTypes);
let myFetchAllClasses = fetch(urlAllClasses);

myFetchAllClasses.then(function(response) {
  response.text().then(function(text) {
    var sel = document.getElementById("classappeal");
    var options = JSON.parse(text)

    for (var i = 0; i<=options.length - 1; i++){
        var opt = document.createElement('option');
        opt.value = options[i].key;
        opt.text = options[i].name;
        sel.appendChild(opt);
    }
  });
});

myFetchAllTypes.then(function(response) {
  response.text().then(function(text) {
    var sel = document.getElementById("typeappeal");
    var options = JSON.parse(text)

    for (var i = 0; i<=options.length - 1; i++){
        var opt = document.createElement('option');
        opt.value = options[i].key;
        opt.text = options[i].name;
        sel.appendChild(opt);
    }
  });
});

function changeOption(){
  let option = typeSelect.options[typeSelect.selectedIndex];
  let urlSubType  = new URL('http://localhost:8070/api/citizens/subtypesbytype?');
  let params = {nameType:option.text};
  urlSubType.search = new URLSearchParams(params).toString();
  let myFethcSubTypes = fetch(urlSubType);

  myFethcSubTypes.then(function(response) {
    response.text().then(function(text) {
      var sel = document.getElementById("subtypesappeal");
      var options = JSON.parse(text)
  
      for (var i = 0; i<=options.length - 1; i++){
          var opt = document.createElement('option');
          opt.value = options[i].key;
          opt.text = options[i].name;
          sel.appendChild(opt);
      }
    });
  });


  //option.name
}

typeSelect.addEventListener("change", changeOption);


function postAppeal(){
  let subtypeName = subtypeSelect.options[subtypeSelect.selectedIndex].text;
  let classAppealName = classAppealSelect.options[classAppealSelect.selectedIndex].text;
  let urlSubType  = new URL('http://localhost:8070/api/citizens/addappeal?');
  let params = {nameClass:classAppealName, nameSubtype: subtypeName};
  urlSubType.search = new URLSearchParams(params).toString();

  let data = {
    "email" : document.getElementById("input_email").value,
    "text" : document.getElementById("input_message").value
  };

   let answerServer = fetch(urlSubType, {
    method: 'POST',
    mode: 'cors',
    cache: 'no-cache',
    credentials: 'same-origin',
    headers: {
      'Content-Type': 'application/json'
    },
    redirect: 'follow',
    referrerPolicy: 'no-referrer',
    body: JSON.stringify(data)
  });

  clearForm();
}

function clearForm(){
  document.getElementById("input_email").value = '';
  document.getElementById("input_message").value = '';
  document.querySelector("#subtypesappeal").value = "10";
  document.querySelector("#typeappeal").value = "10";
  document.querySelector("#classappeal").value = "10";
  document.getElementById("check").checked = false;
}


