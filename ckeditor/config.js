/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */
 
CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
    //config.basicEntities = false;
    //config.Entities = false;

    ////remove <p></p>
    //config.enterMode = CKEDITOR.ENTER_BR;
    

    ////helped for removing </br>
    //CKEDITOR.on('instanceReady', function (ev) {
    //    var writer = ev.editor.dataProcessor.writer;
    //    writer.indentationChars = ' ';

    //    var dtd = CKEDITOR.dtd;
    //    for (var e in CKEDITOR.tools.extend({}, dtd.$block, dtd.$listItem, dtd.$tableContent)) {
    //        ev.editor.dataProcessor.writer.setRules(e, {
    //            indent: false,
    //            breakAfterOpen: false,
    //            breakBeforeClose: false,
    //            breakAfterClose: false
    //        });
    //    }

    //    for (var e in CKEDITOR.tools.extend({}, dtd.$list, dtd.$listItem, dtd.$tableContent)) {
    //        ev.editor.dataProcessor.writer.setRules(e, {
    //            indent: true,
    //        });
    //    }
    //}); 
    //helped
};

