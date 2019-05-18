var eventHub = new Vue();

var validObj = {
    isInvalid: false,
    feedBack: "",
    rules: []
}

moment.locale("es");

function openModal(idModal) {
    $(idModal).modal({ backdrop: "static", keyboard: false });
}

function closeModal(idModal) {
    $(idModal).modal("hide");
}

function formatoFecha(value, fmt) {
    if (value === null) return "";
    fmt = (typeof fmt === "undefined") ? "DD-MM-YYYY" : fmt;
    return moment(value).format(fmt);
}



function clone(obj) {
    if (obj === null || typeof obj !== "object") {
        return obj;
    }
    var temp = obj.constructor();
    for (var key in obj) {
        if (obj.hasOwnProperty(key)) {
            temp[key] = clone(obj[key]);
        }
    }
    return temp;
}