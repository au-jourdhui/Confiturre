;(function () {
	
	'use strict';

	var isiPad = function(){
		return (navigator.platform.indexOf("iPad") != -1);
	};

	var isiPhone = function(){
	    return (
			(navigator.platform.indexOf("iPhone") != -1) || 
			(navigator.platform.indexOf("iPod") != -1)
	    );
	};

	var burgerMenu = function() {
		$('body').on('click', '.js-confiturre-nav-toggle', function(){
			if ( $('#confiturre-navbar').is(':visible') ) {
				$(this).removeClass('active');	
			} else {
				$(this).addClass('active');	
			}
			
		});
	};

	var owlCrouselFeatureSlide = function() {
		
		var owl = $('.owl-carousel');

		owl.on('initialized.owl.carousel change.owl.carousel',function(elem){
			var current = elem.item.index;
			$(elem.target).find(".owl-item").eq(current).find(".to-animate").removeClass('fadeInUp animated');
		});
		owl.on('initialized.owl.carousel changed.owl.carousel',function(elem){
			window.setTimeout(function(){
				var current = elem.item.index;
				$(elem.target).find(".owl-item").eq(current).find(".to-animate").addClass('fadeInUp animated');
			}, 400);
     	});

		owl.owlCarousel({
			items: 1,
		    loop: true,
		    margin: 0,
		    responsiveClass: true,
		    nav: true,
		    dots: true,
		    smartSpeed: 500,
		    autoplay: true,
			autoplayTimeout: 5000,
			autoplayHoverPause: true,
		    navText: [	
		      "<i class='icon-arrow-left2 owl-direction'></i>",
		      "<i class='icon-arrow-right2 owl-direction'></i>"
	     	],

		});
		
	};


	var magnifPopup = function() {
		$('.image-popup').magnificPopup({
			type: 'image',
			removalDelay: 300,
			mainClass: 'mfp-with-zoom',
			gallery:{
				enabled:true
			},
			zoom: {
				enabled: true, 

				duration: 300, 
				easing: 'ease-in-out', 

				opener: function(openerElement) {
				return openerElement.is('img') ? openerElement : openerElement.find('img');
				}
			}
		});
	};


	var animateFeatureIcons = function() {
		if ( $('#confiturre-features').length > 0 ) {	
			$('#confiturre-features .to-animate').each(function( k ) {
				
				var el = $(this);
				
				setTimeout ( function () {
					el.addClass('bounceIn animated');
				},  k * 200, 'easeInOutExpo' );
				
			});
		}
	};

	var animateProducts = function() {
		if ( $('#confiturre-products').length > 0 ) {	
			$('#confiturre-products .to-animate').each(function( k ) {
				
				var el = $(this);
				
				setTimeout ( function () {
					el.addClass('bounceIn animated');
				},  k * 200, 'easeInOutExpo' );
				
			});
		}
	};

	var animateClientLogo = function() {
		if ( $('#confiturre-clients').length > 0 ) {	
			$('#confiturre-clients .to-animate').each(function( k ) {
				
				var el = $(this);
				
				setTimeout ( function () {
					el.addClass('bounceIn animated');
				},  k * 200, 'easeInOutExpo' );
				
			});
		}
	};

	var featureIconsWayPoint = function() {
		if ( $('#confiturre-features').length > 0 ) {
			$('#confiturre-features').waypoint( function( direction ) {
										
				if( direction === 'down' && !$(this).hasClass('animated') ) {
					
					
					

					setTimeout(animateFeatureIcons, 200);
					
					
					$(this).addClass('animated');
						
				}
			} , { offset: '80%' } );
		}
	};
	var productsWayPoint = function() {
		if ( $('#confiturre-products').length > 0 ) {
			$('#confiturre-products').waypoint( function( direction ) {
										
				if( direction === 'down' && !$(this).hasClass('animated') ) {
					
					
					

					setTimeout(animateProducts, 200);
					
					
					$(this).addClass('animated');
						
				}
			} , { offset: '80%' } );
		}
	};

	var clientsWayPoint = function() {
		if ( $('#confiturre-products').length > 0 ) {
			$('#confiturre-products').waypoint( function( direction ) {
										
				if( direction === 'down' && !$(this).hasClass('animated') ) {
					
					
					

					setTimeout(animateClientLogo, 200);
					
					
					$(this).addClass('animated');
						
				}
			} , { offset: '80%' } );
		}
	};
	
	$(function(){
		burgerMenu();
		owlCrouselFeatureSlide();
		magnifPopup();
		featureIconsWayPoint();
		productsWayPoint();
		clientsWayPoint();
	});
}());