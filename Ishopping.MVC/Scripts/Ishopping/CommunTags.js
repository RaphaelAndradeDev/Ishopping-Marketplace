

// Ishopping Tags   ##############################################

var input, start, end;

$(document).ready(function () {

    var isspana = "[span]";
    var isspanb = "[/span]";
    var isia = "[i]";
    var isib = "[/i]";
    var isba = "[b]";
    var isbb = "[/b]";
    var isua = "[u]";
    var isub = "[/u]";
    var isdela = "[del]";
    var isdelb = "[/del]";
    var isbr = "[br/]";

    $('[name="isspan"]').on('click', function () {
        var tag = $(this).parents(".row").find('.texto');
        SetFormat(tag, isspana, isspanb);
    });    

    $('[name="isi"]').on('click', function () {
        var tag = $(this).parents(".row").find('.texto');
        SetFormat(tag, isia, isib);
    });

    $('[name="isb"]').on('click', function () {
        var tag = $(this).parents(".row").find('.texto');
        SetFormat(tag, isba, isbb);
    });

    $('[name="isu"]').on('click', function () {
        var tag = $(this).parents(".row").find('.texto');
        SetFormat(tag, isua, isub);    
    });

    $('[name="isdel"]').on('click', function () {
        var tag = $(this).parents(".row").find('.texto');
        SetFormat(tag, isdela, isdelb);
    });

    $('[name="isbr"]').on('click', function () {
        var tag = $(this).parents(".row").find('.texto');
        SetFormat(tag, "", isbr);
    });

    $("input,textarea")
      .mouseup(function () {
          input = $(this).attr("name");
          if (this.selectionStart != this.selectionEnd) { 
              start = this.selectionStart;
              end = this.selectionEnd;
          }          
      });

    function SetFormat(tag, tagA, tagB)
    {
        var text = tag.val();
        if (input === tag.attr("name") && start != end) {
            var format = tagA + text.substring(start, end) + tagB;
            var textStart = text.substring(0, start);
            var textEnd = text.substring(end);
            tag.val(textStart + format + textEnd);           
        }
        else {
            tag.val(text + " " + tagA + tagB);
        }
        start = 0; end = 0;
    }
   
});







