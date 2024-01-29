(function () {
    window.addEventListener("load", function () {
        // run code
        if (document.getElementById('swagger-ui')) {
            /*document.getElementsByClassName('description')[0].setAttribute('style', 'display: none;');;*/
        }

        setTimeout(function () {
            // Section 01 - Set url link 
            var logo = document.getElementsByClassName('link');
            logo[0].href = "https://www.heinekamp.com/";
            logo[0].target = "_blank";

            // Section 02 - Set logo
            logo[0].children[0].alt = "Verivox";
            logo[0].children[0].src = "https://assets-global.website-files.com/620fec4f002dc418fba628fd/621145e5f5c790f01ba3a8cb_Logo.svg";

            // Section 03 - Set 32x32 favicon
            var linkIcon32 = document.createElement('link');
            linkIcon32.type = 'image/png';
            linkIcon32.rel = 'icon';
            linkIcon32.href = 'https://assets-global.website-files.com/620fec4f002dc418fba628fd/621145e5f5c790f01ba3a8cb_Logo.svg';
            linkIcon32.sizes = '32x32';
            document.getElementsByTagName('head')[0].appendChild(linkIcon32);

            // Section 03 - Set 16x16 favicon
            var linkIcon16 = document.createElement('link');
            linkIcon16.type = 'image/png';
            linkIcon16.rel = 'icon';
            linkIcon16.href = 'https://assets-global.website-files.com/620fec4f002dc418fba628fd/62157f468fcaf476deb54aea_favicon.jpg';
            linkIcon16.sizes = '16x16';
            document.getElementsByTagName('head')[0].appendChild(linkIcon16);
        });
    });
})();