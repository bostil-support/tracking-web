$('#attachfile').change(function (e) {
    var fileName = e.target.files[0].name;
    $('#fileName').append('<div class="blue"> ' + fileName + '</div>');
});

$('#annulla').click(function () {
    $('#fileName').children().remove();
    $('textarea').val('');
    $('textarea').attr("placeholder", "Note").val('');
});

$('img[class="vizual"]').click(function () {
    if (!($('#notesList').css('display') == 'none')) {
        $('#notesList').hide();
        $(this).attr('src', "/images/plus.png");
        $('#vizualizi').text('Visualizza tutti');
    }
    else {
        $('#notesList').show();
        $(this).attr('src', "/images/minus.png");
        $('#vizualizi').text('Riduci visualizzati');
    }
});

var arguments = {
    submit: 'Salva',
    tooltip: "Click to edit...",
    style: 'display: inline',
    onblur: "ignore",
    event: 'custom_event'
};

function openModalForm() {
    var modal = document.getElementById('modal-login');
    modal.style.display = "block";
};

$('.dati-rilievo').editable(Edit, arguments);

$('.legal-entity').editable(Edit,
    {
        type: 'select',
        submit: 'Salva',
        tooltip: "Click to edit...",
        style: 'display: inline',
        onblur: "ignore",
        event: 'custom_event',
        loadurl: '/Home/GetEntityNames'
    });

$('.normativa').editable(Edit, arguments);

$('.mappatura').editable(Edit, arguments);

$('.azione').editable(Edit, arguments);

$('#StatusId').select();

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
            var name = $('select[name="value"] option[value=' + value + ']').text()
            window.Survey.LegalEntity.Name = name;
            window.Survey.LegalEntity.Id = value;
            $('#LegalEntityCode').text(value);
            break;
        case 'ScrepArea':
            window.Survey.ScrepArea = value;
            break;
        case 'RiskType':
            window.Survey.RiskType.Name = value;
            break;
        case 'ActionOwner':
            window.Survey.ActionOwner = value;
            break;
        case 'ActionDescription':
            window.Survey.ActionDescription = value;
            break;
    }

    if ($(this).attr('id') == 'LegalEntityName')
        return name;
    else
        return value;
}

    (function ($) {
        window.Survey = {
            Title: document.getElementById('Title').textContent,
            SurveySeverity: document.getElementById('SurveySeverity').textContent,
            Id: document.getElementById('Id').textContent,
            UserName: document.getElementById('UserName').textContent,
            ValidatorAttribute: document.getElementById('ValidatorAttribute').textContent,
            Description: document.getElementById('Description').textContent,
            LegalEntity: {
                Id: document.getElementById('LegalEntityCode').textContent,
                Name: document.getElementById('LegalEntityName').textContent,
            },
            ScrepArea: document.getElementById('ScrepArea').textContent,
            ActionOwner: document.getElementById('ActionOwner').textContent,
            ActionDescription: document.getElementById('ActionDescription').textContent,
            StatusId: $('#StatusId :selected').val(),
            DueDateLocal: $('#dueDateLocal1').val(),
            RiskType: {
                Name: document.getElementById('Risk').textContent
            },
            //MRN: document.getElementById('mrn').textContent,
            //Regulatory_Area: document.getElementById('regulatory_area').textContent,
        };
    })(jQuery);

$('#conferma').click(function () {
    $.ajax({
        type: 'POST',
        url: '/Home/EditSurvey',
        data: window.Survey,
        success: function () {
            window.location.href = '/Home/Index'
        }
    });
});

$('#salva').click(function () {
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