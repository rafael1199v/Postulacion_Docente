import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { reduce } from 'rxjs';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {

  public pdfSrc: string | null = null;
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string){

  }






  getPdf(){
    this.http.get(this.baseUrl + "pdf/generarPdf/1", {responseType: 'blob', reportProgress: true}).subscribe(result => {
      this.blobToBase64(result); console.log(this.pdfSrc);
      const link = document.createElement('a');
      console.log(result);
      for(let campo in result)
      {
        console.log(campo);
      }
      link.download = "hola.pdf";
      document.body.append(link);
      link.click();
      link.remove();

      setTimeout(() => {
        URL.revokeObjectURL(link.href)
      }, 7000);
      }, error => console.log(error));
  }


  blobToBase64(blob: Blob) : void {
    var reader = new FileReader();
    reader.readAsDataURL(blob);
    reader.onload = (e) => {
      this.pdfSrc = (e.target?.result as string).split(",")[1];
    }
  }
  
}
