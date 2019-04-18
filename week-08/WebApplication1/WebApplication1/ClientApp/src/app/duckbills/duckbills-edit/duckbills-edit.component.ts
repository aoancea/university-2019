import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { DuckbillsService } from '../duckbills.service';
import { Duckbill } from './../duckbills.models';

@Component({
    selector: 'app-duckbills-edit',
    templateUrl: './duckbills-edit.component.html',
    styleUrls: ['./duckbills-edit.component.css']
})
export class DuckbillsEditComponent implements OnInit {

    private routerLink: string = '../list';

    public duckbill: Duckbill;

    private duckbillID: string;

    private isEdit: boolean = false;

    public formGroup: FormGroup;

    private errorMessage: string;

    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private duckbillsService: DuckbillsService,
        private formBuilder: FormBuilder) { }

    ngOnInit() {

        this.duckbillID = this.route.snapshot.params['id'];

        if (this.duckbillID) {
            this.routerLink = '../../list';
            this.isEdit = true;
        }

        this.duckbillsService.loadDuckbill(this.duckbillID).subscribe(res => {
            this.duckbill = res;
            this.initForm(this.duckbill ? this.duckbill : <Duckbill>{});
        });

    }

    save() {
        Object.keys(this.formGroup.controls).forEach(control => {
            this.formGroup.get(control).markAsTouched();
        });

        if (this.formGroup.valid) {
            let duckbill = this.formGroup.value as Duckbill;

            if (this.isEdit) {
                duckbill.id = this.duckbillID;
            }

            this.duckbillsService.saveDuckbill(duckbill).subscribe(res => {
                this.router.navigate(['/duckbills']);
            });
        }
    }




    initForm(duckbill: Duckbill) {
        this.formGroup = this.formBuilder.group({
            name: [duckbill.name, [Validators.required, Validators.maxLength(15)]],
        });
    }

    //createIsotopeFormGroup(isotope: Isotope) {
    //  return this.formBuilder.group({
    //    name: isotope.name
    //  });
    //}



    //validatePositionTaken(control: AbstractControl) {
    //  return this.periodicElementService.detailPeriodicElementHeaderByPosition(control.value).pipe(
    //    map(periodicElement => periodicElement ? null : { positionTaken: true })
    //  );
    //}

}
