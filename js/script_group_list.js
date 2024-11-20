$(document).ready(function () {
    const $menuToggle = $('.menu-toggle');
    const $sidebar = $('.sidebar');
    const menuWidth = 300; // Ширина бокового меню
    const buttonOffset = 60; // Отступ кнопки от меню
  
    $menuToggle.on('click', function () {
      const isVisible = $sidebar.css('right') === '0px';
  
      // Выдвижение/сокрытие бокового меню
      $sidebar.css('right', isVisible ? `-${menuWidth}px` : '0px');
  
      // Смещение кнопки с учетом отступа
      $menuToggle.css('right', isVisible ? '60px' : `${menuWidth + buttonOffset}px`);
    });
  });