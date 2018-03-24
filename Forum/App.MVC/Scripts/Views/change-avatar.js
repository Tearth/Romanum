$(document).ready(function () {
    $("input[type='radio'][value='Default']").click(function () {
        setInternalAvatarInputEnabled(false);
    });

    $("input[type='radio'][value='Gravatar']").click(function () {
        setInternalAvatarInputEnabled(false);
    });

    $("input[type='radio'][value='Internal']").click(function () {
        setInternalAvatarInputEnabled(true);
    });

    function setInternalAvatarInputEnabled(status) {
        var fileInput = $("input[type='file'][name='AvatarFile']");
        fileInput.prop('disabled', !status);

        if (!status) {
            fileInput.replaceWith(fileInput.val('').clone(true));
        }
    }

    var internalRadio = $("input[type='radio'][value='Internal']:checked");
    setInternalAvatarInputEnabled(internalRadio.val());
});