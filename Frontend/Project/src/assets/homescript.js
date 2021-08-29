const navSlide = () => {
    const burger = document.querySelector('.burger');
    const navi = document.querySelector('.nav-links');
    const navLinks = document.querySelectorAll('.nav-links li');
    //togle nav
    burger.addEventListener('click', () => {
        navi.classList.toggle('nav-active');
        navLinks.forEach((link,index) =>{
            if(link.style.animation) { 
                link.style.animation = ''
    
            }else{
                link.style.animation = `navLinkFade 0.5s ease forwards ${index / 7 + 1.5}s`;
            }
            });
    });

}
