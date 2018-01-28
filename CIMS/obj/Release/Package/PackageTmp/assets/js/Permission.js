


function AddConfirm(action) {
    //return true;
    var control = action;
   
    if (control == '1' || control == '3' || control == '5' || control == '7' || control == '9' || control == '11' || control == '13' || control == '15') {

            return true;

        }
        else {
            var a = alert('You dont have permission to add');


            return false;
        }

}
function EditConfirm(action) {
    //return true;
        var control = action;
       
        if (control == '4' || control == '5' || control == '6' || control == '7' || control == '12' || control == '13' || control == '14' || control == '15') {
      

            return true;

        }
        else {
      
            var a = alert('You dont have permission to edit');


            return false;
        }

}

    
    function DeleteConfirm(action) {
        //return true;
        var control = action;

        if (control == '8' || control == '9' || control == '10' || control == '11' || control == '12' || control == '13' || control == '14' || control == '15') {

          
            var a = confirm('Are you sure to delete?');

            if (a == true) {              
                return true;
            }
            else {

                return false;
            }
        }
        else {
            var a = alert('You dont have permission to delete');


            return false;
        }

    }

    function checkReportPermission(obj) {
        var permission = $(obj).attr('data-permission');

        if (permission != 'False') {
            return true;
        }
        else {
            alert("You don't have permission to view reports.");
            return false;
        }
    }


 

  
   