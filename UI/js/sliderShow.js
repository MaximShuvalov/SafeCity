let position = 0;
const sliderShow = 4;
const sliderScroll = 1;

const container = document.querySelector('.slider-container');
const track = document.querySelector('.slider-track');
const btnPrev = document.querySelector('.btn-prev');
const btnNext = document.querySelector('.btn-next');
const items = document.querySelectorAll('.slider-item');

const itemsCount = items.length;
const itemWigth = container.clientWidth / sliderShow;
const movePosition = sliderScroll * itemWigth;


items.forEach((item) => {
    item.style.minWidth = `${itemWigth}px`;
})

btnPrev.addEventListener('click', () => {
    const itemsLeft = Math.abs(position) / itemWigth;
    position += itemsLeft >= sliderScroll ? movePosition : itemsLeft * itemWigth;

    setPosition();
    checkBtns();
});

btnNext.addEventListener('click', () => {
    const itemsLeft = itemsCount - (Math.abs(position) + sliderShow * itemWigth) / itemWigth;
    position -= itemsLeft >= sliderScroll ? movePosition : itemsLeft * itemWigth;

    setPosition();
    checkBtns();
});

const setPosition = () => {
    track.style.transform = `translateX(${position}px)`;
};

const checkBtns = () => {
    btnPrev.disabled = position === 0
    btnNext.disabled = position <= -(itemsCount - sliderShow) * itemWigth;
};

checkBtns();
