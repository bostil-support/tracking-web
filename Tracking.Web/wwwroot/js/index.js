(function() {
    const filters = document.querySelector('.filters');
    const filters_label = document.querySelector('.filters__label');
    const filters_popover = document.querySelector('.filters__popover');
    const filters_arrow = document.querySelector('.filters__arrow-icon');

    filters_label.onclick = () => {
        filters_popover.classList.toggle('filters__popover--active');
        filters_arrow.classList.toggle('filters__arrow-icon--active');
    }

    window.onclick = (e) => {
        if (filters_popover.classList.contains('filters__popover--active')) {
            if (!filters_popover.contains(e.target) && !filters_label.contains(e.target)) {
                filters_popover.classList.remove('filters__popover--active');
                filters_arrow.classList.remove('filters__arrow-icon--active');
            }
        }
    }
})();