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

$('.azione').editable(Edit, arguments);

function Edit(value, settings) {
    //Based on the current element, we update the corresponding property of survey
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
            //$('#LegalEntityId').text(value);
            break;
        case 'SrepCluster':
            window.Survey.SrepCluster = value;
            break;
        case 'ScrepArea':
            window.Survey.ScrepArea = value;
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
                Id: document.getElementById('LegalEntityId').textContent,
                Name: document.getElementById('LegalEntityName').textContent,
            },
            SrepCluster: document.getElementById('SrepCluster').textContent,
            ScrepArea: document.getElementById('ScrepArea').textContent,
            ActionOwner: document.getElementById('ActionOwner').textContent,
            ActionDescription: document.getElementById('ActionDescription').textContent
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