import { Component } from '@angular/core';
import { Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as FileSaver from 'file-saver'; 

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string){

  }


  getPdf()
  {
    this.http.get(this.baseUrl + "pdf/generarPdf/111", {responseType: 'blob'}).subscribe(result => {
      console.log(result);
      FileSaver.saveAs(result, "Curriculum.pdf");
    }, error => console.log(error));
  }
}
