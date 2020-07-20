import { NgModule } from '@angular/core';
import { RouterModule} from '@angular/router';
import { PatientSearchRoutes } from '../Routes/patientApp.SearchRoutes';
import { SearchComponent} from './patientApp.searchComponent';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JWTInterceptor } from '../Utility/Utility.Interceptor';


@NgModule({
  declarations: [
    
    SearchComponent,
    
    
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(PatientSearchRoutes),
    HttpClientModule
   
  ],
  providers: [{provide:HTTP_INTERCEPTORS, useClass:JWTInterceptor,multi:true}],
  bootstrap: [SearchComponent]
})
export class SearchModule {
  
 }
