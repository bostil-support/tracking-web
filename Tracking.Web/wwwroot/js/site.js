﻿$('#attachfile').change(function (e) {
    var fileName = e.target.files[0].name;
    $('#fileName').append('<div class="blue"> ' + fileName + '</div>');
});

$('#annulla').click(function () {
    $('#fileName').children().remove();
    $('textarea').val('');
    $('textarea').attr("placeholder", "Note").val('');
});

var showNotes = true;
$('img[class="vizual"]').click(function () {
    var notes = document.getElementById('notesList').children;
    if (!showNotes) {
        showNotes = true;
        for (var i = 4; i < notes.length; i++)
            notes[i].style.display = 'none';
        $(this).attr('src', "../images/plus.png");
        $('#vizualizi').text('Visualizza tutti');
    }

    else {
        showNotes = false;
        for (var j = 4; j < notes.length; j++)
            notes[j].style.display = 'block';
        $(this).attr('src', "../images/minus.png");
        $('#vizualizi').text('Riduci visualizzati');
    }
});


var argumentsEdit = {
    submit: 'Conferma',
    tooltip: "",
    style: 'display: inline',
    onblur: "ignore",
    event: 'custom_event'
};

var argumentsEditAzione = {
    submit: 'Conferma',
    tooltip: "",
    style: 'display: inline',
    onblur: "ignore",
    event: 'custom_event'
};

function openModalForm() {
    var modal = document.getElementById('modal-login');
    modal.style.display = "block";
};

$('.mappatura').trigger('custom_event');
$('.screp').trigger('custom_event');

$("#userButton").off('click').click(handler => {
    const popover = handler.target.parentElement.querySelector('.user-popover');
    $(popover).toggle();
})

$('.dati-rilievo').editable(Edit, argumentsEdit);

$('.azione').editable(Edit, argumentsEdit);

$('.screp').editable(Edit, argumentsEdit);

$('#StatusId').select();


var previous;

$("#StatusId").on('focus', function () {
    previous = this.value;
}).change(function () {
    var end = this.value;
    if (previous !== end) {
        window.Survey.IsUpdated = 'True';
    }
});

function Edit(value, settings) {
    switch ($(this).attr('id')) {
        case 'Title':
            window.Survey.Title = value;
            break;
        case 'SurveySeverity':
            window.Survey.SurveySeverity = value;
            break;
        case 'Id':
            window.Survey.Id = value;
            break;
        case 'UserName':
            window.Survey.UserName = value;
            break;
        case 'ValidatorAttribute':
            window.Survey.ValidatorAttribute = value;
            break;
        case 'Description':
            window.Survey.Description = value;
            break;
        case 'LegalEntityName':
            var name = $("#LegalEntityName option:selected").text();
            window.Survey.LegalEntityName = name;
            window.Survey.Cod_ABI = value;
            $("#Cod_ABI").text(value);
            break;
        case 'ScrepArea':
            window.Survey.ScrepArea = value;
            break;
        case 'RiskType':
            var type = $("#RiskType option:selected").text();
            window.Survey.RiskType.Name = type;
            window.Survey.RiskType.Id = value;
            break;
        case 'ActionOwner':
            window.Survey.ActionOwner = value;
            break;
        case 'ActionDescription':
            window.Survey.ActionDescription = value;
            break;
    }

    if ($(this).attr('id') === 'LegalEntityName')
        return name;
    else if ($(this).attr('id') === 'RiskType')
        return type;
    else
        return value;
}

(function ($) {
    window.Survey = {
        Title: document.getElementById('Title').textContent,
        SurveySeverity: document.getElementById('SurveySeverity').textContent,
        Id: document.getElementById('Id').textContent,
        UserName: document.getElementById('UserName').textContent,
        Description: document.getElementById('Description').textContent,
        LegalEntityName: document.getElementById('LegalEntityName').textContent,
        Cod_ABI: document.getElementById('Cod_ABI').textContent,
        ActionOwner: document.getElementById('ActionOwner') ? document.getElementById('ActionOwner').textContent : '',
        ActionDescription: document.getElementById('ActionDescription').textContent,
        StatusId: $('#StatusId :selected').val(),
        DueDateLocal: $('#dueDateLocal1').val(),
        RiskType: {
            Id: $('#RiskTypeId').attr('value'),
            Name: document.getElementById('RiskType') ? document.getElementById('RiskType').textContent : ''
        },
        IsUpdated: 'False',
    };
})(jQuery);

$('#conferma').click(function () {
    $.ajax({
        type: 'POST',
        url: 'EditSurvey',
        data: window.Survey,
        success: function () {
            window.location.href = 'Index'
        }
    });
});

$('#salva').click(function () {
    console.log("button salva");
    $('#modalWindow').css('display', 'block');
});

$('#annullaPopup').click(function () {
    $('#modalWindow').css('display', 'none');
})

var span = document.getElementsByClassName("close")[0];

span.onclick = function () {
    $('#modalWindow').css('display', 'none');
}

function GetStatus(value) {
    window.Survey.StatusId = value;
}

$("#dueDateLocal").on("dp.change", function () {
    window.Survey.DueDateLocal = $('#dueDateLocal1').val();
});

