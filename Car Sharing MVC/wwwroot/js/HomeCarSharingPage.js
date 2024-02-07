const backgrounds = [
    'https://mobimg.b-cdn.net/v3/fetch/4d/4d46961fd88c2ac5af742e4768a69fe6.jpeg?w=2200',
    'https://s1.1zoom.me/b5050/652/Mercedes-Benz_AMG_GT_R_2018_539396_1920x1080.jpg',
    'https://wallpapercave.com/wp/wp9115851.jpg'
    // Добавьте другие URL-адреса изображений, если нужно
];

let currentBackgroundIndex = 0;

// Функция для предварительной загрузки фонового изображения
function preloadImage(url) {
    return new Promise((resolve, reject) => {
        const img = new Image();
        img.onload = () => resolve(img);
        img.onerror = reject;
        img.src = url;
    });
}

// Загружаем фоновые изображения
const imagePromises = backgrounds.map(url => preloadImage(url));

// После загрузки всех фоновых изображений
Promise.all(imagePromises).then(images => {
    // Устанавливаем первое фоновое изображение
    document.body.style.backgroundImage = `url('${backgrounds[currentBackgroundIndex]}')`;

    // Запускаем смену фонового изображения через каждые 10 секунд
    setInterval(() => {
        currentBackgroundIndex = (currentBackgroundIndex + 1) % backgrounds.length;
        document.body.style.backgroundImage = `url('${backgrounds[currentBackgroundIndex]}')`;
    }, 10000);
});
