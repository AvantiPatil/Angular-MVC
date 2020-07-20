import { NgModule,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { RouterModule} from '@angular/router';
import { PatientHomeRoutes } from '../Routes/HomeRoutes';
import { CommonModule } from '@angular/common';
import { MasterPageComponent} from './app.Masterpagecomponent';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HomeComponent } from './Home.component';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

//import { LoginModel } from '../Login/app.LoginModel';
import { SecurityLogic } from '../Utility/Utility.Authguard';
import { JWTInterceptor } from '../Utility/Utility.Interceptor';
import { LoginModel } from './app.LoginModel';
import { LoginComponent } from './app.Logincomponent';
import { RegistrationComponent } from '../Registration/app.SignUpComponent';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '../material.module';



@NgModule({
  declarations: [
    HomeComponent,
    RegistrationComponent,
    LoginComponent,
    MasterPageComponent,
    
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(PatientHomeRoutes),
    BrowserAnimationsModule,
    MaterialModule,
   
   
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA
  ],
  providers: [LoginModel,SecurityLogic,
  {provide:HTTP_INTERCEPTORS, useClass:JWTInterceptor,multi:true}],
  
  bootstrap: [MasterPageComponent]
})
export class HomeModule {
  
 }
