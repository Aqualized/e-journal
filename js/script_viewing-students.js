
$(document).ready(function () {
    // Показывать окно при клике на ячейку
    $('.status').on('click', function () {
        const popup = $('.popup');
        const position = $(this).offset();
        popup.css({
            top: position.top + 50,
            left: position.left + 50
        }).fadeIn();
    });

    // Скрытие окна при клике вне его
    $(document).on('click', function (e) {
        if (!$(e.target).closest('.popup, .status').length) {
            $('.popup').fadeOut();
        }
    });
});
