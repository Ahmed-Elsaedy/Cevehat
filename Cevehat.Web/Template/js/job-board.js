jQuery(document).ready(function($) {
	"use strict";
	////////////////////////////////////tab
	$(function(){
		$('#tab-container').easytabs();
	});
	
	////////////////////////////////////mainnav
	$(function(){ 
		var touch 	= $('#touch-menu');
		var menu 	= $('.menu');

		$(touch).on('click', function(e) {
			e.preventDefault();
			menu.slideToggle();
		});
		
		$(window).resize(function(){
			var w = $(window).width();
			if(w > 767 && menu.is(':hidden')) {
				menu.removeAttr('style');
			}
		});
	});
	
	////////////////////////////////////Home Slider
	$(function() {
		var owl = $("#home-slider");
		  owl.owlCarousel({
		  autoPlay: 5000,
		  goToFirstSpeed : 3000,
		  singleItem : true,
		  transitionStyle:"goDown",
		  stopOnHover : true,
		  pagination : false
		  });

		  // Custom Navigation Events
		  $(".slider-next").click(function(){
			owl.trigger('owl.next');
		  })
		  $(".slider-prev").click(function(){
			owl.trigger('owl.prev');
		  })
    });
	
	////////////////////////////////////Home Sidebar Carousel
	$(function() {
      var owl = $("#job-opening-carousel");

      owl.owlCarousel({
	  autoPlay: 5000,
      singleItem : true
      
      });

      // Custom Navigation Events
      $(".next").click(function(){
        owl.trigger('owl.next');
      })
      $(".prev").click(function(){
        owl.trigger('owl.prev');
      })
	});
	
	////////////////////////////////////Home Company Carousel
	$(function() {
      var owl = $("#company-post-list");
      owl.owlCarousel({

      items : 6, //10 items above 1000px browser width
	  autoPlay: 3000
	  
      });
    });
	
	////////////////////////////////////Testimony Home Carousel
	$(function() {
     
		var sync1 = $("#sync1");
		var sync2 = $("#sync2");
		 
		sync1.owlCarousel({
			singleItem : true,
			slideSpeed : 1000,
			navigation: false,
			pagination:false,
			mouseDrag: false,
			touchDrag: false,
			afterAction : syncPosition,
			responsiveRefreshRate : 200,
			transitionStyle : "goDown"
		});
     
		sync2.owlCarousel({
			items : 9,
			itemsDesktop : [1000,5], //5 items between 1000px and 901px
			itemsDesktopSmall : [900,3], // betweem 900px and 601px
			itemsTablet: [600,2], //2 items between 600 and 0
			itemsMobile : false, // itemsMobile disabled - inherit from itemsTablet option
			pagination:false,
			
			afterInit : function(el){
			el.find(".owl-item").eq(0).addClass("synced");
			}
		});
     
		function syncPosition(el){
			var current = this.currentItem;
			$("#sync2")
			.find(".owl-item")
			.removeClass("synced")
			.eq(current)
			.addClass("synced")
			if($("#sync2").data("owlCarousel") !== undefined){
			center(current)
			}
		}
		 
		$("#sync2").on("click", ".owl-item", function(e){
			e.preventDefault();
			var number = $(this).data("owlItem");
			sync1.trigger("owl.goTo",number);
		});
		 
		function center(number){
			var sync2visible = sync2.data("owlCarousel").owl.visibleItems;
			var num = number;
			var found = false;
			for(var i in sync2visible){
			if(num === sync2visible[i]){
				var found = true;
			}
			}
			 
			if(found===false){
			if(num>sync2visible[sync2visible.length-1]){
			sync2.trigger("owl.goTo", num - sync2visible.length+2)
			}else{
				if(num - 1 === -1){
					num = 0;
				}
				sync2.trigger("owl.goTo", num);
			}
			} else if(num === sync2visible[sync2visible.length-1]){
				sync2.trigger("owl.goTo", sync2visible[1])
			} else if(num === sync2visible[0]){
				sync2.trigger("owl.goTo", num-1)
			}
		}
    });
	
	////////////////////////////////////Page Slider
	$(function() {
		var owl = $("#page-slider");
		owl.owlCarousel({
		singleItem : true,

		});
	});
	
	////////////////////////////////////Page Joblisting Carousel
	$(function(){
      var owl = $("#job-listing-carousel");

      owl.owlCarousel({
	  autoPlay: 5000,
      items : 3 //10 items above 1000px browser width
      
      });

      // Custom Navigation Events
      $(".next").click(function(){
        owl.trigger('owl.next');
      })
      $(".prev").click(function(){
        owl.trigger('owl.prev');
      })
	});
	
	////////////////////////////////////Form Value Slider
	$(function() {
		$("#experiences").slider({ 
			from: 1, 
			to: 10,  
			scale: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 
			limits: false, 
			step: 1, 
			dimension: '', 
			skin: "round",  
			callback: function( value ){ console.dir( this ); }
		});
	});
	$(function() {
		$("#salary").slider({ 
			from: 0, to: 500, 
			step: 1, 
			scale: [0, '|', 50, '|' , '100', '|', 250, '|', 500], 
			heterogeneity: ['50/100', '75/250'], 
			limits: false, 
			dimension: 'K', 
			skin: "round", 
			callback: function( value ){ console.dir( this ); }
		});
	});
	////////////////////////////////////Contact Map
	$(function() {
			$.fn.CustomMap = function( options ) {
				var settings = $.extend({
					home: { latitude: 40.7737704, longitude: -73.9660893 },
					text: '<div class="map-popup"><h6><div class="glyphicon glyphicon-map-marker">&nbsp;</div>5th Avenue Street, 103 Floor, Trump Tower Crosss Road, LA 450001 </h6><h6><div class="glyphicon glyphicon-earphone">&nbsp;</div>+1 81000 0001</h6><h6><div class="glyphicon glyphicon-envelope">&nbsp;</div>hello@jobboard.com</h6></div>',
					icon_url: 'images/pin.png',	
					zoom: 15
				}, options );
				var coords = new google.maps.LatLng(settings.home.latitude, settings.home.longitude);
				return this.each(function() {	
					var element = $(this);
					
					var options = {
						zoom: settings.zoom,
						center: coords,
						mapTypeId: google.maps.MapTypeId.ROADMAP,
						mapTypeControl: true,
						scaleControl: true,
						zoomControlOptions: {
							style: google.maps.ZoomControlStyle.DEFAULT
						},
						overviewMapControl: true,	
					};
					
					var map = new google.maps.Map(element[0], options);
					
					var icon = { 
						url: settings.icon_url, 
						origin: new google.maps.Point(0, 0)
					};

					var marker = new google.maps.Marker({
						position: coords,
						map: map,
						icon: icon,
						draggable: false
					});
					
					var info = new google.maps.InfoWindow({
						content: settings.text
					});

					google.maps.event.addListener(marker, 'click', function() { 
						info.open(map, marker);
					});

					var styles = [{
							featureType: "all",
							stylers: [
							  { saturation: -80 }
							]
						},{
							featureType: "road",
							elementType: "geometry",
							stylers: [
							  { hue: "#00ffee" },
							  { saturation: 50 }
							]
						}, {
							featureType: "road",
							elementType: "labels",
							stylers: [
								{ hue: "#4f2a0b" },
								{ saturation: 50 }
							]
						}, {
							featureType: 'poi.school',
							elementType: 'geometry',
							stylers: [
								{ hue: '#4f2a0b' },
								{ lightness: -15 },
								{ saturation: 99 }
							]
						}, {
							featureType: 'poi.park',
							elementType: 'geometry',
							stylers: [
								{ hue: '#a3e36b' },
								{ lightness: -15 },
								{ saturation: 99 }
							]
						}, {
							featureType: 'poi.park',
							elementType: 'labels.icon',
							stylers: [
								{ hue: '#450b4f' },
								{ lightness: -15 },
								{ saturation: 99 }
							]
						}
					];

					map.setOptions({styles: styles});
				});
		 
			};
		});

		$(function() {
			jQuery('div.location').CustomMap();
		});
});