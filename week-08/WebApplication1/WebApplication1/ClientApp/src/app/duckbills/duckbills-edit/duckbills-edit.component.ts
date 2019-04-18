import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl, FormArray, FormBuilder } from '@angular/forms';
import { map } from 'rxjs/operators';

import { Duckbill } from './../duckbills.models';
import { Router, ActivatedRoute } from '@angular/router';
import { DuckbillsService } from '../duckbills.service';


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

    if (this.duckbillID)
      this.routerLink = '../../list';

    this.duckbillsService.loadDuckbill(this.duckbillID).subscribe(res => {
      this.duckbill = res;
      this.initForm(this.duckbill ? this.duckbill : <Duckbill>{});
      this.isEdit = true;
    });

  }

  //save() {
  //  this.clearErrorMessages();

  //  Object.keys(this.formGroup.controls).forEach(control => {
  //    this.formGroup.get(control).markAsTouched();
  //  });

  //  if (this.formGroup.valid) {
  //    let periodicElement = this.formGroup.value as PeriodicElement;

  //    if (this.isEdit) {
  //      periodicElement.id = this.periodicElementID;
  //    }

  //    this.periodicElementService.savePeriodicElement(periodicElement).subscribe((validationErrors: ValidationError[]) => {
  //      if (validationErrors.length != 0) {
  //        this.displayErrorMessages(validationErrors)
  //      } else {
  //        this.router.navigate(['/periodic-elements']);
  //      }
  //    });
  //  }
  //}

  //displayErrorMessages(validationErrors: ValidationError[]) {
  //  this.errorMessage = validationErrors.map(x => x.message).join(' | ');
  //}

  //clearErrorMessages() {
  //  this.errorMessage = null;
  //}

  initForm(duckbill: Duckbill) {
    this.formGroup = this.formBuilder.group({
      name: [duckbill.name, [Validators.required, Validators.max(118)] ],
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
