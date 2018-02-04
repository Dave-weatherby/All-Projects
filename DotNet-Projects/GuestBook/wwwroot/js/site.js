$(document).ready(function(){
    
    // check if clicked over post back
    if($("#addForm").is(':checked')) {
        $("#hideMe").show();
    }

    // if the check box is clicked the form will toggole on and off
    $('#addForm').change(function() {
        $("#hideMe").toggle(this.checked);
    });

    // JQuery for char remaining test on txtbox
    $('#entry').keyup(function () {
        var max = 100;
        var len = $(this).val().length;
        var char = max - len;
        $('#charLeft').text(char + ' characters remaining');
        
      });
});
