
  $(function() {
     $("input:btnUpload").change(function (){
       var fileName = $(this).val();
       $(".filename").html(fileName);
     });
  });
