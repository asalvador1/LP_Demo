 var btnListaPrecios=new Ext.Button({
	    text:'Lista de Precios',
	    id: "btnCerrarPer",
        height:50,
        width:300,
	    icon: App.utils.constants.ICONS_PATH + 'add.png',
	    cls: 'x-btn-text-icon',
	    handler:function(){
	        location.replace(App.utils.constants.URL_BASE_PATH + 'ListaPrecios.aspx/NuevaPaso1');
	    } // function

      });
    
        var btnProVta = new Ext.Button({
        text: 'Programa de Venta',
        id: 'btnClose',
        height:50,
        width:300,
        icon: App.utils.constants.ICONS_PATH  + 'add.png',
        cls: 'x-btn-text-icon',
        //tabIndex: 9,
        handler: function () {
            location.replace(App.utils.constants.URL_BASE_PATH + 'Venta.aspx/CierreProgramaVta');
        } // function
        });

MainLayout = function () {

    return {

        init: function () {
            Ext.BLANK_IMAGE_URL = App.utils.constants.BLANK_IMAGE_URL;
            Ext.QuickTips.init();
            this.initLayout();
        },

        initLayout: function () {

            var viewport = new Ext.Viewport({
                layout: "fit",
                items: [{
                    xtype: "form",
                    id: "frmmain",
                   // region:"center",
                    //buttonAlign: "center",
                    //buttons: [btnListaPrecios, btnProVta],
                    items: [btnListaPrecios, btnProVta],
                    frame: true,
                    autoScroll: true,
                    title: 'Demo Lista de precios y Programa de Venta',
//                    items: [
//                            northFieldset
//                       ]
                }]// items viewport
            });

        }
    }
} ();






Ext.EventManager.onDocumentReady(MainLayout.init, MainLayout, true);
