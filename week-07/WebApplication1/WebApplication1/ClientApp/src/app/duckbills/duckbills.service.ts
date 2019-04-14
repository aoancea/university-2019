import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Duckbill } from './duckbills.models';

@Injectable()
export class DuckbillsService {

    constructor(
        private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

    listDuckbills() {
        return this.http.get<Duckbill[]>(this.baseUrl + 'api/Duckbills/ListDuckbills');
    }

    loadDuckbill(duckbillID: string) {
        return this.http.get<Duckbill>(this.baseUrl + 'api/Duckbills/DetailDuckbill?duckbillID=' + duckbillID);
    }

    saveDuckbill(duckbill: Duckbill) {
        return this.http.post<any>(this.baseUrl + `api/Duckbills/SaveDuckbill`, duckbill);
    }

    deleteDuckbill(duckbillID: string) {
        return this.http.delete<any>(this.baseUrl + `api/Duckbills/DeleteDuckbill?duckbillID=${duckbillID}`);
    }
}
