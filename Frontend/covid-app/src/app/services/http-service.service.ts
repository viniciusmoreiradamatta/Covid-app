import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http"
import { Observable, from } from 'rxjs';
import { environment } from '../../environments/environment.prod'


import { Covid } from '../models/covid'
@Injectable({
  providedIn: 'root'
})

export class HttpServiceService {

  private controller = '';
  private url = environment.apiUrl;
  protected UrlService: string;

  constructor(private _client: HttpClient) {
    this.UrlService = this.url + this.controller;
  }

  ObterCasos(): Observable<Covid[]> {
    return this._client.get<Covid[]>(this.UrlService);
  }
}
