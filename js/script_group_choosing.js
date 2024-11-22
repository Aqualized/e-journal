$(document).ready(function () {
  $(".menu-toggle").on("click", function () {
    $(".sidebar").toggleClass("hidden");
    $(".container").toggleClass("menu-closed");
  });
});
