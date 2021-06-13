const urlCategory = 'http://localhost:8030/api/alltypes'

const cateagoryAppeal = document.getElementById('categoryAppeal');

let fetchAllCategory = fetch(urlCategory)

fetchAllCategory.then(function(response) {
    response.text().then(function(text) {
        var sel = document.getElementById("categoryAppeal");
        var options = JSON.parse(text)

        for (var i = 0; i <= options.length - 1; i++) {
            var opt = document.createElement('option');
            opt.value = options[i].key;
            opt.text = options[i].name;
            sel.appendChild(opt);
        }
    });
});