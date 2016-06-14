jQuery.showConfirmModal = function (textForModal, callback) {
    vex.dialog.confirm({
        message: textForModal,
        className: 'vex-theme-default',
        contentClassName: 'vex-custom-content',
        callback: callback
    });
};

jQuery.showDialogModal = function (messageForDialog, inputHtml, buttons, callback) {
    vex.dialog.open({
        message: messageForDialog,
        input: inputHtml,
        className: 'vex-theme-default',
        contentClassName: 'vex-custom-content vex-custom-form',
        buttons: buttons,
        callback: callback
    });
};

jQuery.showPromptModal = function (messageForPrompt, placeHolderText, callback) {
    vex.dialog.prompt({
        message: messageForPrompt,
        className: 'vex-theme-default',
        contentClassName: 'vex-custom-content',
        placeholder: placeHolderText,
        callback: callback
    });
};

jQuery.showAlertModal = function (messageForPrompt, callback) {
    vex.dialog.alert({
        message: messageForPrompt,
        className: 'vex-theme-default',
        contentClassName: 'vex-custom-content',
        callback: callback
    });
};

$(function () {
    $(window).bind("load resize", function () {
        topOffset = 50;
        width = (this.window.innerWidth > 0) ? this.window.innerWidth : this.screen.width;
        if (width < 768) {
            $('div.navbar-collapse').addClass('collapse');
            topOffset = 100; // 2-row-menu
        } else {
            $('div.navbar-collapse').removeClass('collapse');
        }

        height = ((this.window.innerHeight > 0) ? this.window.innerHeight : this.screen.height) - 1;
        height = height - topOffset;
        if (height < 1) height = 1;
        if (height > topOffset) {
            $("#page-wrapper").css("min-height", (height) + "px");
        }
    });

    $(document).ready(function () {
        var url = window.location;
        $.each($('.nav-link'), function (index, element) {
            var self = $(element);
            var datalocation = $(self).attr('href');
            if (url.pathname == datalocation) {
                $(self).addClass('active');
                $(self).closest('.dropdown').addClass('open');
            }

        });

        $(document).on('click', '.nav-link', function(e) {
            e.stopPropagation();
        });


    });


});
