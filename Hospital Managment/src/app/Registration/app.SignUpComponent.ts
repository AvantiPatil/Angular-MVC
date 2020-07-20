import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Registration } from './app.SignUpModel';
import { Router } from '@angular/router';
import {FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.SignUp.html',
  styleUrls: ['./app.SignUp.css']
  
})
export class RegistrationComponent {
  hide = true;
  RegisterObj:Registration= null;
  RegisterObjs:Array<Registration> = new Array<Registration>();
  constructor(private Http:HttpClient,private Routing:Router){
    this.RegisterObj=new Registration();
    }

 SignUp()
 {
  var obj:any ={};
  obj.userName=this.RegisterObj.userName;
  obj.password=this.RegisterObj.password;
  obj.Email=this.RegisterObj.Email;
  obj.FirstName=this.RegisterObj.FirstName;
  obj.LastName= this.RegisterObj.LastName;
 
  this.Http.post("https://localhost:44316/api/Register", obj)
  .subscribe(res => this.success(res),
  res => this.Error(res));
}
success(res){
  this.RegisterObjs= res;
  this.RegisterObj = new Registration();
}
Error(res){
  
alert(res);
}

  //Username
  userName = new FormControl('', [Validators.required, Validators.pattern["^[A-Z][a-z]{1,10}$"]] );

  ErrorMessage() {
    if (this.userName.hasError('required')) {
      return '*You must enter a value';
    }

  
  }
//Email
Email = new FormControl('', [Validators.required, Validators.email]);

                 getErrorMessage() {
                   if (this.Email.hasError('required')) {
                     return '*You must enter a value';
                   }
               
                   return this.Email.hasError('email') ? '*Not a valid email' : '';
                 }
          
                
}

   




 

 
 
 


