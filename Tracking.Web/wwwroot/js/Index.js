var names = [];
var owners = [];
var statuses = [];
var severities = [];
var textDescr = {};
var filter;

window.onload = function () {
    SetFilterFields();
    $('#filterDiv').hide();
    $.ajax({
        url: "GetSurveys",
        type: "GET",
        success: GetSurveysSuccess
    });

    SetDescriptionText();
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
}

function SetDescriptionText() {
    var d = document.getElementById('LegalEntity');
    var id = document.getElementsByClassName('modelId');
    var descrptn = document.getElementsByClassName('descr');

    for (var i = 0; i < id.length; i++) {
        textDescr["id"].push(id[i]);
        textDescr["descrptn"].push(descrptn[i]);
    }

    for (var i = 0; i < textDescr.length; i++) {
        console.log(textDescr[i]["id"] + " " + textDescr[i]["descrptn"]);
    }
}