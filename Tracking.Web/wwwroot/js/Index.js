var names = [];
var owners = [];
var statuses = [];
var severities = [];
var filter;

window.onload = function () {
    $('#filterDiv').hide();
    $.ajax({
        url: "/Home/GetInterventions",
        type: "GET",
        success: GetInterventionsSuccess
    });
}

$('#buttonFiltri').click(function () {
    if ($('#filterDiv').css('display') == 'none')
        $('#filterDiv').css('display', 'block');
    else
        $('#filterDiv').css('display', 'none');
});

$('input[type=checkbox]').change(function () {
    var id = $(this).attr('id');
    filter = $('label[for="' + id + '"]').text();
    var property = $($(this).parent()).children('.legend').text();

    if ($(this).is(':checked')) {
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
        type: "POST",
        traditional: true,
        data: {
            LegalEntities: names,
            Owners: owners,
            Statuses: statuses,
            Severities: severities
        },
        success: GetInterventionsSuccess
    });
});

function remove(array, element) {
    var index = array.indexOf(element);
    array.splice(index, 1);
}

function GetInterventionsSuccess(data) {
    $('#main-content').html(data);
}