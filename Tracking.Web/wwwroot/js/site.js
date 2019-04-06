// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

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

$('.legal-entity').editable(Edit, arguments);

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
            window.Survey.LegalEntity.Name = value;
            break;
        case 'LegalEntityId':
            window.Survey.LegalEntity.Id = value;
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
    //We have to return string, it will be put into element for displaying
    return (value);
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
                Name: document.getElementById('LegalEntityName').textContent,
                Id: document.getElementById('LegalEntityId').textContent,
            },
            SrepCluster: document.getElementById('SrepCluster').textContent,
            ScrepArea: document.getElementById('ScrepArea').textContent,
            ActionOwner: document.getElementById('ActionOwner').textContent,
            ActionDescription: document.getElementById('ActionDescription').textContent
        };
    })(jQuery);

$('#salva').click(function () {
  
    $.ajax({
        type: 'POST',
        url: '/Home/EditSurvey',
        dataType: 'json',
        data: window.Survey
    });
});
