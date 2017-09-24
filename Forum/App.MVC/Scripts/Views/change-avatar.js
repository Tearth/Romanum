$(document).ready(function () {
    $(".default-avatar-radio input:radio").click(function () {
        setInternalAvatarInputEnabled(false);
    });

    $(".gravatar-avatar-radio input:radio").click(function () {
        setInternalAvatarInputEnabled(false);
    });

    $(".internal-avatar-radio input:radio").click(function () {
        setInternalAvatarInputEnabled(true);
    });

    function setInternalAvatarInputEnabled(status) {
        var fileInput = $(".internal-avatar-input input:file");
        fileInput.prop('disabled', !status);

        if (!status) {
            fileInput.replaceWith(fileInput.val('').clone(true));
        }
    }
});