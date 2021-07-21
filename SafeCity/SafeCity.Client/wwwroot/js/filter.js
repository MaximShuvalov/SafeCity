$(document).ready(function(){
    function filter(item){
        $(item).each(function(i){
            $(this).on('click', function(e){ 
                e.preventDefault();
                if(item === ('.appeals__tab_all')){
                    $(this).closest('div.container').find('div.appeals__wraper').find('div.appeal-item').addClass('appeal-item_active');
                }
                if(item === ('.appeals__tab_road')){

                    $(this).closest('div.container').find('div.appeals__wraper').find('div.appeal-item_live').removeClass('appeal-item_active');
                    $(this).closest('div.container').find('div.appeals__wraper').find('div.appeal-item_solved').removeClass('appeal-item_active');
                    $(this).closest('div.container').find('div.appeals__wraper').find('div.appeal-item_road').addClass('appeal-item_active');
                }
                if(item === ('.appeals__tab_live')){
                    $(this).closest('div.container').find('div.appeals__wraper').find('div.appeal-item_road').removeClass('appeal-item_active');
                    $(this).closest('div.container').find('div.appeals__wraper').find('div.appeal-item_solved').removeClass('appeal-item_active');
                    $(this).closest('div.container').find('div.appeals__wraper').find('div.appeal-item_live').addClass('appeal-item_active');
                }
                if(item === ('.appeals__tab_solved')){
                    $(this).closest('div.container').find('div.appeals__wraper').find('div.appeal-item_road').removeClass('appeal-item_active');
                    $(this).closest('div.container').find('div.appeals__wraper').find('div.appeal-item_live').removeClass('appeal-item_active');

                    $(this).closest('div.container').find('div.appeals__wraper').find('div.appeal-item_solved').addClass('appeal-item_active');
                }
            })
        })
    }
    $(function() {
        $('ul.appeals__tabs').on('click', 'li:not(.appeals__tab_active)', function() {
            $(this).addClass('appeals__tab_active').siblings().removeClass('appeals__tab_active');
        });
    });

    filter('.appeals__tab_all');
    filter('.appeals__tab_road');
    filter('.appeals__tab_live');
    filter('.appeals__tab_solved');
})