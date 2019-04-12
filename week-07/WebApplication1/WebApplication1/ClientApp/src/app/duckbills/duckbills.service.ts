import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Duckbill } from './duckbills.models';

@Injectable()
export class DuckbillsService {

  constructor(
    private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  listDuckbills() {
    return this.http.get<Duckbill[]>(this.baseUrl + 'api/Duckbills/GetDuckbills');
  }

  loadDuckbill(duckbillID: string) {
    return this.http.get<Duckbill>(this.baseUrl + 'api/Duckbills/GetDuckbill?duckbillID=' + duckbillID);
  }

  //savePeriodicElement(periodicElement: PeriodicElement) {
  //    //return this.http.post<ValidationError[]>(`${this.applicationService.baseUrl}PeriodicElement/SavePeriodicElement`, periodicElement);
  //}

  //deletePeriodicElement(periodicElementID: string) {
  //    //return this.http.delete<any>(`${this.applicationService.baseUrl}PeriodicElement/DeletePeriodicElement?periodicElementID=${periodicElementID}`);
  //}
}
