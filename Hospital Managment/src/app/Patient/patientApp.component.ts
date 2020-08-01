import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Patient, patientProblem} from './patientApp.Model'

@Component({
  selector: 'app-root',
  templateUrl: './patientApp.component.html',
  styleUrls: ['./patientApp.Patient.css']
  
})
export class PatientComponent {
  
  Patientobj:Patient= null;
  patientProblem:patientProblem=new patientProblem();

  Patientobjs:Array<Patient> = new Array<Patient>();
  
      constructor(private Http:HttpClient){
      this.Patientobj=new Patient();
      }
      AddProblem(){
        this.Patientobj.patientProblems.push(this.patientProblem);
        this.patientProblem= new patientProblem();
    }
      
      Submit(){

        //let patientDetail={
          //id:this.Patientobj.id,
          //name: this.Patientobj.name,
          //patientDetail.problems=[];
          //problemDescription:this.Patientobj.patientProblems
        //}
         var obj:any ={};
         obj.id=this.Patientobj.id;
         obj.name=this.Patientobj.name;
         obj.problems = [];
         obj.problems=this.Patientobj.patientProblems;
        
        this.Http.post("https://localhost:44316/api/PatientAPI", obj)
        .subscribe(res => this.success(res),
        res => this.Error(res));
      
      }
      success(res){
        this.Patientobjs= res;
        this.Patientobj = new Patient();
      }
      Error(res){
        
    alert(res);
      }

 
}

