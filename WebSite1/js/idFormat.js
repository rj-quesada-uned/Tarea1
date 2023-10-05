function changeFormat(id) {
    if (id == 1) {
        input.value = formatNumber(input.value);
    }
    else {

    }
}

const form = document.getElementById('registerForm');

if (form) {
    const select = document.getElementById('MainContent_idOptions');
    const input = document.getElementById('MainContent_UserName');
    const values = document.querySelectorAll('#registerForm input');

    select.addEventListener('change', function () {
        let selectedOption = this.options[select.selectedIndex].value;
        changeFormat(selectedOption);
    });
}