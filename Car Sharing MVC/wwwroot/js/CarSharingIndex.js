document.addEventListener("DOMContentLoaded", function () {
    const backgroundUrl = 'https://c.pxhere.com/photos/67/79/garage_parking_parking_lot_underground_the_wine_cellar_dungeon-649589.jpg!d';
    const timestamp = new Date().getTime(); // �������� ������� ����� � �������������
    const img = new Image();
    img.src = `${backgroundUrl}?timestamp=${timestamp}`; // ��������� ��������� �������� � URL
    img.onload = function () {
        document.body.style.backgroundImage = `url(${backgroundUrl}?timestamp=${timestamp})`; // ��������� ������� �����������
        localStorage.setItem('background', backgroundUrl);
    };
});
