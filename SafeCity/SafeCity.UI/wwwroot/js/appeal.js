const urlCategory = 'http://localhost:8070/api/alltypes'

const cateagoryAppeal = document.getElementById('сategoryAppeal');

let fetchAllCategory = fetch(urlCategory)

fetchAllCategory.then(function(response) {
  response.text().then(function(text) {
    var sel = document.getElementById("сategoryAppeal");
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
  let urlSubType  = new URL('http://localhost:8070/api/subtypesbytype?');
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
}

typeSelect.addEventListener("change", changeOption);
