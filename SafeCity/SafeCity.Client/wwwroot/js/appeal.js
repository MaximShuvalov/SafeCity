let className = localStorage.getItem('appealClass');

const urlCategory = 'https://bkg.sibadi.org/api/subtypesbytype?nameType=' + className;

const categoryAppeal = document.getElementById('appealCategory');

let fetchAllCategory = fetch(urlCategory)

fetchAllCategory.then(function (response) {
    response.text().then(function (text) {
        var sel = document.getElementById("appealCategory");
        var options = JSON.parse(text)

        for (var i = 0; i <= options.length - 1; i++) {
            var opt = document.createElement('option');
            opt.value = options[i].key;
            opt.text = options[i].name;
            sel.appendChild(opt);
        }
    });
});

async function postAppeal() {
    let subtypeName = categoryAppeal.options[categoryAppeal.selectedIndex].text;
    let urlSubType = new URL('https://bkg.sibadi.org/api/addappeal?');
    let params = {nameSubtype: subtypeName};
    urlSubType.search = new URLSearchParams(params).toString();
    localStorage.clear();
    var reader = new FileReader();

    var file = new Blob([document.getElementById("attachment").files[0]]);

    // при успешном завершении операции чтения
    reader.onload = (function (file) {
        return function (e) {
            var r = e.target;
            // получаем содержимое файла, состояние чтения, ошибки(или null)
            console.log(r.result, r.readyState, r.error);
        };
    })(file);

    var fileContent = await readUploadedFileAsBinary(file);
    let data = {
        "email": document.getElementById("input_email").value,
        "text": document.getElementById("input_message").value,
        "phone": document.getElementById("input_phone").value,
        "address": document.getElementById("input_address").value,
        "attachment": fileContent.split(',')[1]
    };

    fetch(urlSubType, {
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
    })
    .then(res=>res.text())
            .then(res => {
                console.log('Done', res);
                document.location.href = "https://bkg.sibadi.org";
            })
            .catch(e => {
                document.location.href = "https://bkg.sibadi.org";
                console.log(e);});
    document.location.href = "https://bkg.sibadi.org";
}

const readUploadedFileAsBinary = (inputFile) => {
    const temporaryFileReader = new FileReader();

    return new Promise((resolve, reject) => {
        temporaryFileReader.onerror = () => {
            temporaryFileReader.abort();
            reject(new DOMException("Problem parsing input file."));
        };

        temporaryFileReader.onload = () => {
            resolve(temporaryFileReader.result);
        };
        temporaryFileReader.readAsDataURL(inputFile);
    });
};