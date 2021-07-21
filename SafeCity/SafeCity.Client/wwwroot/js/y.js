var adress_needed = 'Омск';

        var add = function () {
            let fetchAllCategory = fetch("https://bkg.sibadi.org/api/all")

            fetchAllCategory.then(function (response) {
                response.text().then(function (text) {
                    var options = JSON.parse(text)

                    for (var i = 0; i <= options.length - 1; i++) {
                        addToMap(options[i].address);
                    }
                });
            });
        };

        var addToMap = function (inputAdress) {
            ymaps.geocode(inputAdress, { //ищем по нужному адресу
                boundedBy: myMap.getBounds(),
                results: 1
            }).then(function (res) {
                myMap.geoObjects.add(res.geoObjects.get(0));
            });
        };

        var myGeocoder = ymaps.geocode("Омск");

        myGeocoder.then(function (res) {
            myMap.controls.add('zoomControl', {
                left: 5,
                top: 5
            });
            var firstGeoObject = res.geoObjects.get(0),
                coords = firstGeoObject.geometry.getCoordinates(),
                bounds = firstGeoObject.properties.get('boundedBy');

            myMap.setBounds(bounds, {
                checkZoomRange: true
            });

            var myPlacemark = new ymaps.Placemark([55.752577, 37.632134], {}, {
                iconImageHref: 'http://4.bp.blogspot.com/--ddYKXz6fpc/Uh1NrRYLtVI/AAAAAAAAAPA/Bd16ChUzC2Q/s1600/home-icon.png',
                iconImageSize: [50, 40],
                iconImageOffset: [0, -50],
            });

            var myPlacemark1 = new ymaps.Placemark([55.52, 37.622093], {}, {
                iconImageHref: 'http://4.bp.blogspot.com/--ddYKXz6fpc/Uh1NrRYLtVI/AAAAAAAAAPA/Bd16ChUzC2Q/s1600/home-icon.png',
                iconImageSize: [50, 40],
                iconImageOffset: [0, -50],
            });

            myMap.geoObjects
                .add(myPlacemark)
                .add(myPlacemark1);
        });