import { Component, OnInit } from '@angular/core';

import { Duckbill } from './../duckbills.models';

import { DuckbillsService } from './../duckbills.service';

@Component({
    selector: 'app-duckbills-list',
    templateUrl: './duckbills-list.component.html',
    styleUrls: ['./duckbills-list.component.css']
})

export class DuckbillsListComponent implements OnInit {

    public displayedColumns: string[] = ['name', 'email', 'action'];
    public duckbills: Duckbill[];

    constructor(private duckbillsService: DuckbillsService) { }

    ngOnInit() {
        this.loadDuckbills();
    }

    deleteDuckbill(duckbill: Duckbill) {
        this.duckbillsService.deleteDuckbill(duckbill.id).subscribe(x => {
            this.loadDuckbills();
        });
    }


    loadDuckbills() {
        this.duckbillsService.listDuckbills().subscribe(res => {
            this.duckbills = res;
        });
    }
}
