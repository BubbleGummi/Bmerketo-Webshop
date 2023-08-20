function footerPosition(element, scrollHeight, innerHeight) {
    try {
        const _element = document.querySelector('.footer');
        const isTallerThanScreen = scrollHeight >= innerHeight + _element.scrollHeight;

        // Toggle CSS classes based on the condition
        _element.classList.toggle('position-fixed-bottom', !isTallerThanScreen);
        _element.classList.toggle('position-static', isTallerThanScreen);
    } catch (error) {
        // Handle any errors that occur
        console.error(error);
    }
}

// Call the footerPosition function with appropriate arguments
footerPosition('.footer', document.body.scrollHeight, window.innerHeight);

function toggleMenu(value) {
    try {
        const toggleBtn = document.querySelector(value);
        toggleBtn.addEventListener('click', function () {
            const element = document.querySelector(toggleBtn.getAttribute('data-target'));

            if (!element.classList.contains('open-menu')) {
                element.classList.add('open-menu');
                toggleBtn.classList.add('btn-outline-dark');
                toggleBtn.classList.add('btn-toggle-white');
            } else {
                element.classList.remove('open-menu');
                toggleBtn.classList.remove('btn-outline-dark');
                toggleBtn.classList.remove('btn-toggle-white');
            }
        });
    } catch (error) {
        console.error(error);
    }
}

// Call the toggleMenu function with appropriate argument
toggleMenu('[data-option="toggle"]');

// Validation of forms:

function completeNameValidationRequired(e) {
    console.log(e.target.dataset.valRequired);
    const regex = /^(?![\s-]+$)[a-öA-Ö\s-]*$/;
    const validationfield = document.querySelector(`[data-valmsg-for="${e.target.id}"]`);
    console.log(validationfield);

    if (regex.test(e.target.value) && e.target.value.length >= 2) {
        validationfield.classList.add('text-success');
        validationfield.classList.remove('text-danger');
        validationfield.innerText = "It's valid";
    } else {
        validationfield.classList.remove('text-success');
        validationfield.classList.add('text-danger');
        validationfield.innerText = `You must provide a valid name: ${e.target.dataset.valRequired}`;
    }
}

// Add similar functions for other validation cases (emailValidationRequired, postalCodeValidation, streetNameValidation, firstAndLastNameValidation, passwordValidation, comparePasswords, numberOfCharacters)

