$(document).ready(function () {
    // Обработчик клика на гамбургер-кнопку
    $('.hamburger-menu').on('click', function () {
        const menu = $('.analysis-tools');
        menu.toggleClass('open'); // Переключение класса open
    });

    // Обработка кликов по статусам (кнопки)
    $('.status').on('click', function (e) {
        const popup = $('.popup'); // Находим всплывающее окно
        const buttonPosition = $(this).offset(); // Получаем позицию кнопки

        // Перемещаем всплывающее окно к кнопке
        popup.css({
            top: buttonPosition.top + $(this).outerHeight() + 10, // Смещаем ниже кнопки
            left: buttonPosition.left
        }).fadeIn();

        // Закрываем, если кликнули вне окна
        e.stopPropagation(); // Не даем закрыть окно при клике на него
        $(document).on('click', function () {
            popup.fadeOut();
        });
    });

    // Удаляем обработчик при новом открытии
    $('.popup').on('click', function (e) {
        e.stopPropagation();
    });
});
