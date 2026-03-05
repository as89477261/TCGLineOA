//Image Sliders
var indexActive = 0;
var splide = document.getElementsByClassName('splide');
if (splide.length) {
    var singleSlider = document.querySelectorAll('.single-slider');
    if (singleSlider.length) {
        singleSlider.forEach(function (e) {
            var single = new Splide('#' + e.id, {
                type: 'loop',
                //autoplay:false,
                //interval:4000,
                perPage: 1,
            }).mount();
            var sliderNext = document.querySelectorAll('.slider-next');
            var sliderPrev = document.querySelectorAll('.slider-prev');
            sliderNext.forEach(el => el.addEventListener('click', el => { single.go('>'); }));
            sliderPrev.forEach(el => el.addEventListener('click', el => { single.go('<'); }));

            single.on('moved', function (newIndex, prevIndex, destIndex) {
                // alert(newIndex);
                BindingMYLGDetail(newIndex);

               

            });

        });
    }

    var doubleSlider = document.querySelectorAll('.double-slider');
    if (doubleSlider.length) {
        doubleSlider.forEach(function (e) {
            var double = new Splide('#' + e.id, {
                type: 'loop',
                autoplay: true,
                interval: 4000,
                arrows: false,
                perPage: 2,
            }).mount();
        });
    }

    var tripleSlider = document.querySelectorAll('.triple-slider');
    if (tripleSlider.length) {
        tripleSlider.forEach(function (e) {
            var triple = new Splide('#' + e.id, {
                type: 'loop',
                autoplay: true,
                interval: 4000,
                arrows: false,
                perPage: 3,
                perMove: 1,
            }).mount();
        });
    }

    var quadSlider = document.querySelectorAll('.quad-slider');
    if (quadSlider.length) {
        quadSlider.forEach(function (e) {
            var quad = new Splide('#' + e.id, {
                type: 'loop',
                autoplay: true,
                interval: 4000,
                arrows: false,
                perPage: 4,
                perMove: 1,
            }).mount();
        });
    }
}

//Don't jump when Empty Links
const emptyHref = document.querySelectorAll('a[href="#"]')
emptyHref.forEach(el => el.addEventListener('click', e => {
    e.preventDefault();
    return false;
}));

//Opening Submenu
function submenus() {
    var subTrigger = document.querySelectorAll('[data-submenu]');
    if (subTrigger.length) {
        var submenuActive = document.querySelectorAll('.submenu-active')[0];
        if (submenuActive) {
            var subData = document.querySelectorAll('.submenu-active')[0].getAttribute('data-submenu');
            var subId = document.querySelectorAll('#' + subData);
            var subIdNodes = document.querySelectorAll('#' + subData + ' a');
            var subChildren = subIdNodes.length
            var subHeight = subChildren * 43;
            subId[0].style.height = subHeight + 'px';
        }

        subTrigger.forEach(el => el.addEventListener('click', e => {
            const subData = el.getAttribute('data-submenu');
            var subId = document.querySelectorAll('#' + subData);
            var subIdNodes = document.querySelectorAll('#' + subData + ' a');
            var subChildren = subIdNodes.length
            var subHeight = subChildren * 43;
            if (el.classList.contains('submenu-active')) {
                subId[0].style.height = '0px';
                el.classList.remove('submenu-active');
            } else {
                subId[0].style.height = subHeight + 'px';
                el.classList.add('submenu-active');
            }
            return false
        }));
    }
}

//Activate Selected Menu
function activatePage() {

    var activeMenu = document.querySelectorAll('[data-menu-active]');
    if (activeMenu) {
        var activeData = activeMenu[0].getAttribute('data-menu-active');
        var activeID = document.querySelectorAll('#' + activeData)[0]
        activeID.classList.add('list-group-item-active')
        if (activeID.parentNode.classList.contains('list-submenu')) {
            var triggerSub = activeID.parentNode.getAttribute('id')
            document.querySelectorAll('[data-submenu="' + triggerSub + '"]')[0].classList.add('submenu-active');
            submenus();
        }
    }
}