
$(document).ready(function () {
    $('[name="colorPicker"]')
      .colorpicker()
      .on('showPicker changeColor', function (e) {
          // Re-validate the color when user choose a color from the color picker
          $('#defaultForm')
              .data('bootstrapValidator')                   // Get BootstrapValidator instance
              .updateStatus('dcolor', 'NOT_VALIDATED')       // Set the color as not validated yet
              .validateField('dcolor');                     // and validate the color
      });
});