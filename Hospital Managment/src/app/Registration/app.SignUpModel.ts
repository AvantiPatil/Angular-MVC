import { NgForm,
        FormGroup,
           FormControl,
               Validators,
          FormBuilder} from '@angular/forms';


export class Registration{
    
        userName:string="";
        password: string="";
        Email: string="";
        FirstName: string="";
        LastName: string="";
       
        //formRegGroup:FormGroup = null;

   // constructor(){
        //tree structure
       // var _builder = new FormBuilder();
        //use the builder
        //this.formRegGroup = _builder.group({}); 
        //add vlidation to formGroup
        //this.formRegGroup.addControl("Fnamecontrol",
        //new FormControl('',Validators.required));
        //this.formRegGroup.addControl("Lnamecontrol",
       // new FormControl('',Validators.required));
         //this.formRegGroup.addControl("Unamecontrol",
         //    new FormControl('',Validators.required));
 
        // this.formRegGroup.addControl("passwordcontrol",
          //   new FormControl('',
             // [Validators.minLength(8),
              //   Validators.required]));


                 
    
             // }
       
}