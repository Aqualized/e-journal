$(document).ready(function () {
    // При клике на кнопку скрываем/показываем меню
    $(".menu-toggle").on("click", function () {
      $(".container").toggleClass("menu-closed"); // Добавляем/удаляем класс для изменения ширины
      $(".sidebar").toggleClass("hidden"); // Скрываем/показываем боковую панель
    });
  });
  