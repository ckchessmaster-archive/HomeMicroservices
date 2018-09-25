let currentIndex = 0;

$(document).ready(function () {
    let addFieldButton = document.getElementById('AddFieldButton');
    addFieldButton.onclick = addFieldButtonClicked;
});

function addFieldButtonClicked() {
    $('#FieldListHeaders').append(
        $('<th id="FieldHeader_' + currentIndex + '">' +
            '<input type="text" id="Fields_' + currentIndex + '_Name" name="Fields[' + currentIndex + '].Name" placeholder="Field Name" class="form-control" />' +
        '</th > '));

    fieldListType = $('<td id="FieldType_' + currentIndex + '"></td >');
    fieldListType.append(getFieldTypeSelect(currentIndex));
    $('#FieldListTypes').append(fieldListType);

    removeFieldButton = $('<td id="RemoveFieldButton_' + currentIndex + '"><a href="JavaScript:void(0)">Remove Field</a></td>');
    removeFieldButton.on(events = 'click', data = { index: currentIndex }, handler=removeFieldButtonClicked);
    $('#FieldListRemoveButtons').append(removeFieldButton);

    currentIndex++;
}

function getFieldTypeSelect(index) {
    select = $('<select id="Fields_' + index + '_Type" name="Fields[' + index + '].Type" class="form-control"></select>');
    select.append($('<option value="text">Text</select>'));
    select.append($('<option value="number">Number</select>'));

    return select;
}

function removeFieldButtonClicked(event) {
    $('#FieldHeader_' + event.data.index).remove();
    $('#FieldType_' + event.data.index).remove();
    $('#RemoveFieldButton_' + event.data.index).remove();

    // Renumber the fields
    for (i = event.data.index + 1; i < currentIndex; i++) {
        selectedHeader = $('#FieldHeader_' + i);
        selectedHeader.attr('id', 'FieldHeader_' + (i - 1));
        selectedHeader.children().attr('id', 'Fields_' + (i - 1) + '_Name');
        selectedHeader.children().attr('name', 'Fields[' + (i - 1) + '].Name');

        selectedBody = $('#FieldType_' + i);
        selectedBody.attr('id', 'FieldType_' + (i - 1));
        selectedBody.children().attr('id', 'Fields_' + (i - 1) + '_Type');
        selectedBody.children().attr('name', 'Fields[' + (i - 1) + '].Type');

        newRemoveFieldButton = $('<td id="RemoveFieldButton_' + (i - 1) + '"><a href="JavaScript:void(0)">Remove Field</a></td>');
        newRemoveFieldButton.on(events = 'click', data = { index: i - 1 }, handler = removeFieldButtonClicked);
        $('#RemoveFieldButton_' + i).replaceWith(newRemoveFieldButton);
    }
}