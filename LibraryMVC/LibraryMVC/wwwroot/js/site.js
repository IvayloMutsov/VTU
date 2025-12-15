document.addEventListener("DOMContentLoaded", function () {
    // 1. Remove any Inputmask instances if the library is present
    if (window.Inputmask) {
        Inputmask.remove(document.querySelectorAll('input'));
    }

    // 2. Remove any data-mask attributes
    document.querySelectorAll('input[data-mask]').forEach(function (el) {
        el.removeAttribute('data-mask');
    });

    // 3. Remove any classes that might trigger masking (e.g., 'masked')
    document.querySelectorAll('input.masked').forEach(function (el) {
        el.classList.remove('masked');
    });

    // 4. Optionally, remove pattern attributes if you want plain input
    document.querySelectorAll('input[pattern]').forEach(function (el) {
        el.removeAttribute('pattern');
    });

    console.log("Input masks removed.");
});

document.addEventListener('DOMContentLoaded', function () {
    const toggles = document.querySelectorAll('.accordion-toggle');

    if (!toggles.length) return;

    toggles.forEach(toggle => {
        toggle.addEventListener('click', function (e) {
            e.preventDefault();

            const currentSubmenu = this.nextElementSibling;

            document.querySelectorAll('.submenu').forEach(menu => {
                if (menu !== currentSubmenu) {
                    menu.classList.remove('active');
                }
            });

            currentSubmenu.classList.toggle('active');
        });
    });
});