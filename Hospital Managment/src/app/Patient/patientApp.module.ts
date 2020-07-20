import { NgModule } from '@angular/core';
import { RouterModule} from '@angular/router';
import { PatientRoutes } from '../Routes/patientRoutes';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { PatientComponent } from './patientApp.component';
import { JWTInterceptor } from '../Utility/Utility.Interceptor';



@NgModule({
  declarations: [
   PatientComponent
    
    
  ],
  imports: [
   
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(PatientRoutes),
    HttpClientModule
   
  ],
  providers: [ {provide:HTTP_INTERCEPTORS, useClass:JWTInterceptor,multi:true}],
  bootstrap: [PatientComponent]
})
export class PatientModule {
  
 }
