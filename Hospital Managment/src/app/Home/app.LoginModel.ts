import { NgForm,
    FormGroup,
       FormControl,
           Validators,
      FormBuilder} from '@angular/forms'

export class LoginModel{
    userName:string="";
    password:string="";
    token:string="";


    //formloginGroup:FormGroup = null;

    //constructor(){
        //tree structure
        //var _builder = new FormBuilder();
        //use the builder
      //  this.formloginGroup = _builder.group({}); 
        //add vlidation to formGroup
        // this.formloginGroup.addControl("Unamecontrol",
          //   new FormControl('',Validators.required));
 
        // this.formloginGroup.addControl("passwordcontrol",
        //     new FormControl('',
           //   [Validators.minLength(8),
           //      Validators.required]));
          
        //}
    
}