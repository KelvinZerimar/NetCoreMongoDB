import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class SaleService {

  readonly BaseURI = 'http://localhost:57877/';

  constructor(private http: HttpClient) { }

  getListValues() {
    return this.http.get(this.BaseURI + 'api/sales');
  }
}

