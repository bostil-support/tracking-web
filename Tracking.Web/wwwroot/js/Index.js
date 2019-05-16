﻿var names = [];
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
        url: "GetFilterDatas",
        type: "GET",
        success: function (data) {
            $('#filterDiv').html(data);
        }
    });
}

function GetSurveys() {
    $.ajax({
        url: "GetSurveys",
        type: "GET",
        success: GetSurveysSuccess
    });
}

function ButtonFilterClick() {
    if ($('#filterDiv').css('display') === 'none')
        $('#filterDiv').css('display', 'block');
    else
        $('#filterDiv').css('display', 'none');
}

function Filter(id) {
    var element = document.getElementById(id);
    filter = $('span[value="' + id + '"]').text();
    var filedset = $($(element).parent()).parent();
    var property = $(filedset).children('.legend').text();

    if ($(element).is(':checked')) {
        if (property === "Legal entity") {
            names.push(filter);
        }

        if (property === "Owner azione correttiva") {
            owners.push(filter);
        }

        if (property === "Stato azione correttiva") {
            statuses.push(filter);
        }

        if (property === "Severità rilievo") {
            severities.push(filter);
        }
    }

    else {
        if (property === "Legal entity") {
            remove(names, filter);
        }

        if (property === "Owner azione correttiva") {
            remove(owners, filter);
        }

        if (property === "Stato azione correttiva") {
            remove(statuses, filter);
        }

        if (property === "Severità rilievo") {
            remove(severities, filter);
        }
    }

    $.ajax({
        url: "Filter",
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

    for (var j = 0; j < descrptn.length; j++) {
        descrptn[j].textContent = textDescr[j].value.substring(0, 110) + '...';
    }

    $('.riduci').hide();
}

function EspandiText(id) {
    const index = textDescr.findIndex(item => item.key === id);
    if (index >= 0) {
        document.getElementById('descr ' + id).textContent = textDescr[index].value;
        document.getElementById('Espandi ' + id).style.display = 'none';
        document.getElementById('Riduci ' + id).style.display = '';
    }
}

function RiduciText(id) {
    const index = textDescr.findIndex(item => item.key === id);
    if (index >= 0) {
        document.getElementById('descr ' + id).textContent = textDescr[index].value.substring(0, 110) + '...';
        document.getElementById('Espandi ' + id).style.display = '';
        document.getElementById('Riduci ' + id).style.display = 'none';
    }
}

$("#userButton").off('click').click(handler => {
    const popover = handler.target.parentElement.querySelector('.user-popover');
    $(popover).toggle();
})