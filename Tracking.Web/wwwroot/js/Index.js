var names = [];
var owners = [];
var statuses = [];
var severities = [];
var textDescr = [];
var filter;

window.onload = function () {
    SetFilterFields();
    $('#filterDiv').hide();

    GetSurveys();
}

function SetFilterFields() {
    $.ajax({
        url: "/Home/GetFilterDatas",
        type: "GET",
        success: function (data) {
            $('#filterDiv').html(data);
        }
    });
}

function GetSurveys() {
    $.ajax({
        url: "/Home/GetSurveys",
        type: "GET",
        success: GetSurveysSuccess
    });
}

function ButtonFilterClick() {
    if ($('#filterDiv').css('display') == 'none')
        $('#filterDiv').css('display', 'block');
    else
        $('#filterDiv').css('display', 'none');
}

function Filter(id) {
    var element = document.getElementById(id);
    filter = $('label[for="' + id + '"]').text();
    var property = $($(element).parent()).children('.legend').text();

    if ($(element).is(':checked')) {
        if (property == "Legal entity") {
            names.push(filter);
        }

        if (property == "Owner azione correttiva") {
            owners.push(filter);
        }

        if (property == "Stato azione correttiva") {
            statuses.push(filter);
        }

        if (property == "Severità rilievo") {
            severities.push(filter);
        }
    }

    else {
        if (property == "Legal entity") {
            remove(names, filter);
        }

        if (property == "Owner azione correttiva") {
            remove(owners, filter);
        }

        if (property == "Stato azione correttiva") {
            remove(statuses, filter);
        }

        if (property == "Severità rilievo") {
            remove(severities, filter);
        }
    }

    $.ajax({
        url: "/Home/Filter",
        type: "GET",
        traditional: true,
        data: {
            LegalEntities: names,
            Owners: owners,
            Statuses: statuses,
            Severities: severities
        },
        success: GetSurveysSuccess
    });
}

function remove(array, element) {
    var index = array.indexOf(element);
    array.splice(index, 1);
}

function GetSurveysSuccess(data) {
    $('#main-content').html(data);
    SetDescriptionText();
}

function SetDescriptionText() {
    var id = document.getElementsByClassName('modelId');
    var descrptn = document.getElementsByClassName('descr');

    for (var i = 0; i < id.length; i++) {
        textDescr.push({
            key: id[i].textContent,
            value: descrptn[i].textContent
        });
    }

    for (var i = 0; i < textDescr.length; i++) {
        descrptn[i].textContent = textDescr[i].value.substring(0, 150) + '...';
    }

    $('.riduci').hide();
}

function EspandiText(id) {
    var descrptn = document.getElementsByClassName('descr');
    for (var i = 0; i < textDescr.length; i++) {
        if (textDescr[i].key == id) {
            descrptn[i].textContent = textDescr[i].value;
            document.getElementById('Espandi ' + id).style.display = 'none';
            document.getElementById('Riduci ' + id).style.display = '';
            break;
        }
    }
}

function RiduciText(id) {
    var descrptn = document.getElementsByClassName('descr');
    for (var i = 0; i < textDescr.length; i++) {
        if (textDescr[i].key == id) {
            descrptn[i].textContent = textDescr[i].value.substring(0, 150) + '...';
            document.getElementById('Espandi ' + id).style.display = '';
            document.getElementById('Riduci ' + id).style.display = 'none';
            break;
        }
    }
}