var input = document.getElementById('bday');

var logo = document.getElementById('logo');


logo.onclick = function () {
    window.location.assign("index.cshtml");
}

var dateInputMask = function dateInputMask(elm) {

    elm.addEventListener('keyup', function (e) {

        if (e.keyCode < 47 || e.keyCode > 57) {
            e.preventDefault();
        }

        var len = elm.value.length;

        if (len !== 1 || len !== 3) {
            if (e.keyCode == 47) {
                e.preventDefault();
            }
        }

        if (len === 2) {
            if (e.keyCode !== 8 && e.keyCode !== 46) {
                elm.value = elm.value + '.';
            }
        }

        if (len === 5) {
            if (e.keyCode !== 8 && e.keyCode !== 46) {
                elm.value = elm.value + '.';
            }
        }
    });
};

dateInputMask(input);