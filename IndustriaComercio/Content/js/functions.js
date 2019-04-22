var eventHub = new Vue();

var validObj = {
    isInvalid: false,
    feedBack: "",
    rules: []
}

function openModal(idModal) {
    $(idModal).modal({ backdrop: "static", keyboard: false });
}

function closeModal(idModal) {
    $(idModal).modal("hide");
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