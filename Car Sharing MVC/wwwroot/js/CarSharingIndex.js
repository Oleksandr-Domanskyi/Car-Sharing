document.addEventListener("DOMContentLoaded", function () {
    const backgroundUrl = 'https://c.pxhere.com/photos/67/79/garage_parking_parking_lot_underground_the_wine_cellar_dungeon-649589.jpg!d';
    const timestamp = new Date().getTime(); // Получаем текущее время в миллисекундах
    const img = new Image();
    img.src = `${backgroundUrl}?timestamp=${timestamp}`; // Добавляем случайный параметр в URL
    img.onload = function () {
        document.body.style.backgroundImage = `url(${backgroundUrl}?timestamp=${timestamp})`; // Обновляем фоновое изображение
        localStorage.setItem('background', backgroundUrl);
    };
});
