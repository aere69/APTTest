import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs'
import { map, catchError } from 'rxjs/operators'
import { Post } from './post';

@Injectable({
  providedIn: 'root'
})
export class PostsService {
  url = 'https://localhost:5001/api/Posts';

  constructor(private http: HttpClient) { }

  getDetails(id: any): Promise<string>{
    let newUrl = this.url + '/' + id.toString();
    return this.http.get(newUrl,{responseType: 'text'}).toPromise()
      .then(this.extractData)
      .catch(this.handleErrorPromise);
  }

  getPosts(): Promise<Post[]>{
    return this.http.get(this.url).toPromise()
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
