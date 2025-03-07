import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { enviroment } from '../../../../enviroments/enviroment';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private httpClient:HttpClient) { }

  GetAll():Observable<any[]>{
    return this.httpClient.get<any[]>(`${enviroment.apiUrl}/api/posts`)
  }
}
