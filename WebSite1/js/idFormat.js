function nationalId() {
    const formattedValue = input.value.replace(/\D/g, '');

    if (formattedValue.length >= 10) {
        input.value = formattedValue.substring(0, 2) + '-' + formattedValue.substring(2, 6) + '-' + formattedValue.substring(6, 10);
    }
    else {
        input.value = formattedValue;
    }
}

function residenceId() {
    const formattedValue = input.value.replace(/\D/g, '');

    if (formattedValue.length >= 12) {
        input.value = formattedValue.substring(0, 12);
    }
    else {
        input.value = formattedValue;
    }
}

const select = document.getElementById('MainContent_idOptions');
const input = document.getElementById('MainContent_UserName');

select.addEventListener('change', function () {
    let selectedOption = this.options[select.selectedIndex].value;

    if (selectedOption == 1) {
        input.placeholder = '00-0000-0000';
        input.value = "";
        input.removeEventListener('keyup', residenceId);
        input.addEventListener('keyup', nationalId);
    }
    else {
        input.placeholder = '000000000000';
        input.value = '';
        input.removeEventListener('keyup', nationalId);
        input.addEventListener('keyup', residenceId);
    }
});