//code check
import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';


import { LoginModel } from '../Home/app.LoginModel';


@Injectable()
export class SecurityLogic implements CanActivate {

    constructor(private _router:Router, public _user:LoginModel){

    }

    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
      ): Observable<boolean> | Promise<boolean> | boolean{
       if(this._user.token.length !=0){
           return true; //navigation allow
       }

       this._router.navigate(['/Login']);
       return false;
      }
}