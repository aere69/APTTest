import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs'
import { map, catchError } from 'rxjs/operators'
import { SvcResponse } from './svcresponse';

@Injectable({
  providedIn: 'root'
})
export class ProcessorService {
  url = 'https://localhost:5001/api/Submission';

  constructor(private http: HttpClient) { }

  processFile(formData: any): Promise<SvcResponse>{
    return this.http.post(this.url, formData).toPromise()
      .then(this.extractData)
      .catch(this.handleErrorPromise);
  }

  private extractData(res: any){
    let body = res;
    return body;
  }

  private handleErrorPromise(error: Response | any){
    return Promise.reject(error.message || error);
  }
}
