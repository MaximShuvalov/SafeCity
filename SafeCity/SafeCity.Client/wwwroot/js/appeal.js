let className = localStorage.getItem('appealClass');

const urlCategory = 'https://bkg.sibadi.org/api/subtypesbytype?nameType=' + className;

const categoryAppeal = document.getElementById('appealCategory');

let fetchAllCategory = fetch(urlCategory)

fetchAllCategory.then(function (response) {
    response.text().then(function (text) {
        var sel = document.getElementById("appealCategory");
        var options = JSON.parse(text);

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


    if (document.getElementById("attachment").files.length > 0) var file = new Blob([document.getElementById("attachment").files[0]]);

    // при успешном завершении операции чтения
    reader.onload = (function (file) {
        return function (e) {
            var r = e.target;
            // получаем содержимое файла, состояние чтения, ошибки(или null)
            console.log(r.result, r.readyState, r.error);
        };
    })(file);

    if (document.getElementById("attachment").files.length > 0) var fileContent = await readUploadedFileAsBinary(file);

    let data = {
        "email": document.getElementById("input_email").value,
        "text": document.getElementById("input_message").value,
        "phone": document.getElementById("input_phone").value,
        "address": document.getElementById("input_address").value,
        "attachment": (document.getElementById("attachment").files.length > 0) ? fileContent.split(',')[1] : null
    };

    try {
        const response = await fetch(urlSubType, {
            method: 'POST',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });
        const json = await response.json();
        console.log('Успех:', JSON.stringify(json));
    } catch (error) {
        console.error('Ошибка', error);
    }
    document.location.href = "https://bkg.sibadi.org";
}

<<<<<<< HEAD

=======
>>>>>>> appealFormUI
//file extension validation
document.getElementById("file").addEventListener("change", validateFile)

function validateFile(){
    const allowedExtensions =  ['jpg','jpeg','png','pdf'],
    sizeLimit = 2000000;
    const { name:fileName, size:fileSize } = this.files[0];
    const fileExtension = fileName.split(".").pop();

    if(!allowedExtensions.includes(fileExtension)){
        alert("Пожалуйста, выберите файл .jpg, .jpeg, .png или .pdf расширения");
        this.value = null;
    }else if(fileSize > sizeLimit){
        alert("Размер файла не должен превышать 2 МБ")
        this.value = null;
    }
}

