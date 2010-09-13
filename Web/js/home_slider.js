jQuery.noConflict();

/*!
 * WorryFreeLabs Three-way Slider
 *
 * @version     1.0
 * @category    WorryFreeLabs
 * @package     js
 * @copyright   Copyright (c) 2010 Worry Free Labs, LLC. (http://worryfreelabs.com/)
 * @author      Jon Neubeck
 */
;(function(jQuery)
{
	jQuery.fn.extend
	({
		accordionSlider: function(options)
		{
			var defaults =
			{
				animationDuration: 500,
				ulClass: 'sheets-gallery'
				
			};
			
			var options = jQuery.extend(defaults, options);
			var masterCount = jQuery('.'+options.ulClass+' ul li').size();
			
			return this.each
			(
				function(idx, item)
				{
					var o = options;
					var itemNum = idx+1;
					var p_id = '#li'+itemNum;

					toggleForward(p_id);

				}
			);
			
			function toggleBack(id){
				jQuery(id).click(function(e) {
					var classN = id.replace('#','');
					
					if(switchC(id,classN+'Open',classN+'Closed')){
						jQuery(id).unbind();
						toggleForward(id);
						findElementsBack(id);
					}					
				});
			}
			
			function toggleForward(id){
				jQuery(id).click(function(e) {
					var classN = id.replace('#','');

					jQuery(id).unbind();
					toggleBack(id);
					findElementsForward(id);
					
				});
			}
			
			function findElementsForward(id){
			
				var tempId = id.replace('#li','');
				
				for( i=tempId; i >= 1; i--){
					if(i != tempId){
					
						var className = 'li'+i+'Open';
						var classNameC = 'li'+i+'Closed';
						if(jQuery('#li'+i).hasClass(className)){
							//do nothing
						}else{
							if(switchC('#li'+i,classNameC,className)){
								jQuery('#li'+i).unbind();
								toggleBack('#li'+i);
							}
						}
					}
				}
			}
			
			function findElementsBack(id){
			
				var tempIdBack = id.replace('#li','');

				for( i=tempIdBack; i <= masterCount; i++){
					if(i != tempIdBack){
						var className = 'li'+i+'Closed';
						var classNameO = 'li'+i+'Open';
						if(jQuery('#li'+i).hasClass(className)){
							//do nothing
						}else{
							if(switchC('#li'+i,classNameO,className)){
								jQuery('#li'+i).unbind();
								toggleForward('#li'+i);
							}
						}
					}				
				}
			}
			
			function switchC(id,from,to){
				jQuery(id).switchClass(from, to, options.animationDuration);
				return true;
			}			
		}
	});
})(jQuery);


