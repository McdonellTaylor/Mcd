// home-blogs.js: IntersectionObserver for reveal animations and client-side search filtering
(function(){
    'use strict';

    const observerOptions = { root: null, rootMargin: '0px', threshold: 0.12 };
    const items = document.querySelectorAll('.animate-item');
    if ('IntersectionObserver' in window && items.length) {
        const io = new IntersectionObserver((entries)=>{
            entries.forEach(e=>{
                if(e.isIntersecting){
                    e.target.classList.add('visible');
                    // optionally unobserve to avoid toggling
                    io.unobserve(e.target);
                }
            });
        }, observerOptions);
        items.forEach(i=> io.observe(i));
    } else {
        // fallback: reveal all
        items.forEach(i=> i.classList.add('visible'));
    }

    // search/filter
    const searchEl = document.getElementById('blogSearch');
    const grid = document.getElementById('blogGrid');
    if (searchEl && grid) {
        let timer = null;
        searchEl.addEventListener('input', function(e){
            clearTimeout(timer);
            const q = e.target.value.trim().toLowerCase();
            timer = setTimeout(()=> applyFilter(q), 150);
        });

        function applyFilter(query){
            const cards = grid.querySelectorAll('.blog-item');
            if(!query){
                cards.forEach(c=> c.classList.remove('hidden'));
                return;
            }
            cards.forEach(c=>{
                const text = (c.dataset.search || '').toLowerCase();
                if(text.indexOf(query) !== -1){
                    c.classList.remove('hidden');
                    // ensure visible class (reveal)
                    c.classList.add('visible');
                } else {
                    c.classList.add('hidden');
                }
            });
        }
    }

    // click-to-play overlay handler (same as publicity index)
    document.addEventListener('click', function (e) {
        var el = e.target;
        while (el && !el.classList.contains('video-thumb')) el = el.parentElement;
        if (el && el.dataset && el.dataset.videoUrl) {
            var url = el.dataset.videoUrl;
            window.open(url, '_blank');
        }
    });
})();
