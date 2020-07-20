import {   Component  } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { LoginModel } from './app.LoginModel';
import { Router } from '@angular/router';
import {FormControl, Validators} from '@angular/forms';


@Component({
  selector: 'app-root',
  templateUrl: './app.Logincomponent.html',
  styleUrls: ['./app.HomeCSS.css']
  
  
})

export class LoginComponent {
  //Loginobj:LoginModel= new LoginModel();
 
 
  constructor(public http:HttpClient ,
     public Loginobj:LoginModel,
    public routing:Router){
   
 }
SignIn()
  {
    let Dto={
      userName:this.Loginobj.userName,
      password:this.Loginobj.password
    }
  
    //call the mvc core and get the token

    this.http.post("https://localhost:44316/api/security", Dto)
      .subscribe(res=>this.success(res), res=>this.error(res));
  }
  success(res){
     this.Loginobj.token = res.token;
     this.routing.navigate(["Home"]);
  }
  error(res){

  }
  signup(){
    this.routing.navigate(['Registration'])
    
  }
  userName = new FormControl('', [Validators.required, Validators.pattern["^[A-Z][a-z]{1,10}$"]] );

  ErrorMessage() {
    if (this.userName.hasError('required')) {
      return '*You must enter a value';
    }

  
  }
 
}

