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

    // Обработка кликов по инструментам анализа
    $('.icon').on('click', function () {
        const tool = $(this).data('tool');
        alert(`Вы выбрали инструмент: ${tool}`);
        // Здесь можно добавить действия в зависимости от выбранного инструмента
        if (tool === 'pie') {
            console.log('Круговая диаграмма');
        } else if (tool === 'bar') {
            console.log('Столбчатая диаграмма');
        } else if (tool === 'feedback') {
            console.log('Обратная связь');
        }
    });
});
