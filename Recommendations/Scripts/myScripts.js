;
(function($, window, document, undefined) {


    $(document)
        .off('.')
        .on('click', '.js-search-submit', function() {

            var searchInputValue = $('.js-search-input').val();

            if (searchInputValue !== "") {

                var url = $(this).data('search-request-url');

                $.get(url, { "q": searchInputValue }).done(function (data) {
                    // Validate result of return
                    if (data.length > 0) {
                        $('.js-api-result').html(data);
                    } else {
                        $('.js-api-result').html('<p>No search results..</p>'); 
                    }

                    $('html,body').animate({
                        scrollTop: $('.js-api-result').offset().top
                    }, 'slow');
                });

            }
        })
        .on('click', '.js-dropdown-menu', function (e) {
            e.preventDefault();
            $(this).toggleClass('open');
            $(this).children('.js-dropdown-menu-wrapper').slideToggle('fast');
        })
        .on('click', '.js-dropdown-item-link', function (e) {
            e.preventDefault();
            e.stopPropagation();
            var value = $(this).data('value');

            if ($(this).hasClass('active')) {
                $(this).removeClass('active');
                $('.js-selected-genres').find('.js-' + value).remove();

            } else {
                $(this).addClass('js-' + value).addClass('active');
                $('.js-selected-genres').append('<div data-value='+value+ ' class="dropdown-menu__selected-genres js-selected-genres-item js-' + value + '">' + value + '<i class="svg-icon--cross"></i></div>');
            }
    
        })
        .on('click', '.js-selected-genres-item', function (e) {
            e.preventDefault();
            var value = $(this).data('value');
            $(this).remove();

            $('.js-dropdown-menu-wrapper').find('.js-' + value).removeClass('active');
        })
        .on('click', '.js-button-get-recommendations', function (e) {
            e.preventDefault();

            var url = $(this).data('request-url');

            var genres = new Array();

            $('.js-selected-genres').find('.js-selected-genres-item').each(function(index, value) {
                genres.push($(value).data('value'));
            });

            var instrumentalness = $('.js-instrumentalness').val();
            var danceability = $('.js-danceability').val();
            var valence = $('.js-valence').val();
            var popularity = $('.js-popularity').val();
            console.log({ genres: genres });

            $.get(url,
                {
                    genres: JSON.stringify(genres),
                    "danceability": danceability,
                    "instrumentalness": instrumentalness,
                    "valence": valence,
                    "popularity": popularity
                }).done(function(data) {
                if (data.length > 0) {
                    $('.js-api-result').html(data);
                } else {
                    $('.js-api-result').html('<p>No search results..</p>');
                }

                $('html,body').animate({
                    scrollTop: $('.js-api-result').offset().top
                }, 'slow');
            });

        });


}(jQuery, window, window.document));