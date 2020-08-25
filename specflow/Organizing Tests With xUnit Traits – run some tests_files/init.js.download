jQuery(function ($) {
	
	$('.nav-primary ul.menu-primary').superfish({
		delay:       100,								// 0.1 second delay on mouseout 
		animation:   {opacity:'show',height:'show'},	// fade-in and slide-down animation 
		dropShadows: false								// disable drop shadows 
	});

	$(".menu-icon").click(function(){
		$(".nav-primary ul.menu-primary").slideToggle();
		$(".menu-icon").toggleClass( "active" );
	});


	$(window).resize(function(){
		if(window.innerWidth > 768) {
			$(".nav-primary ul.menu-primary, nav .sub-menu").removeAttr("style");
		}
	});

});