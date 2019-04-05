// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function openModalForm() {
    var modal = document.getElementById('modal-login');
    modal.style.display = "block";
};

$(".dati-rilievo").editable($.updateSurvey, {
    submit: 'Salva',
    tooltip: "Click to edit...",
    style: 'display: inline',
    onblur: "ignore",
    event: 'custom_event'
});

$.updateSurvey = function (value, settings) {
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
            window.Survey.LegalEntityName = value;
            break;
        case 'LegalEntityId':
            window.Survey.LegalEntityId = value;
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
            Title: '<%: Model.SurveySeverity %>',
            SurveySeverity: '<%: Model.SurveySeverity %>',
            Id: '<%: Model.UserName %>',
            UserName: '<%: Model.UserName %>',
            ValidatorAttribute: '<%: Model.ValidatorAttribute %>',
            Country: '<%: Model.Country %>',
            Description: '<%: Model.Description %>',
            LegalEntityName: '<%: Model.LegalEntity.Name %>',
            LegalEntityId: '<%: Model.LegalEntity.Id %>',
            SrepCluster: '<%: @Model.SrepCluster %>',
            ScrepArea: '<%: @Model.ScrepArea %>',
            ActionOwner: '<%: @Model.ActionOwner %>',
            ActionDescription: '<%: @Model.ActionDescription %>'
        };
    })(jQuery);

$('#salva').click(function () {
    $.ajax({
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        url: '<%=Url.Action("Edit", "Survey") %>',
        dataType: 'json',
        data: $.toJSON(window.Survey)
    });
});

/*
$('.edit-all-dati-rilievo-btn').click(function () {
    console.log("edit-all-dati-rilievo-btn");
    $(this).parent().find('.edit').dblclick();
});
*/
// edit survey fields
/*
$('#description-edit').click(function (e) {
    e.preventDefault();
    var txt = $("#description-text").text().trim();
    $("#description-text").replaceWith("<input id='input-description' value='" + txt + "' />");
    $('#description-edit').html("<a onclick='SaveEditSurveyField();return false;' href='#'>Salva</a>");
});

function SaveEditSurveyField() {
    var txt = $("#description-text").text();
    console.log(txt);
    //var txt = $("#input-description").value;
    $("Description").value = txt;
    $("#description-text").replaceWith(txt);
    $('#description-content').html("<a href='#' id='description-edit'><img src='~/images/edit.png' alt='edit'></a>");
}
*/
