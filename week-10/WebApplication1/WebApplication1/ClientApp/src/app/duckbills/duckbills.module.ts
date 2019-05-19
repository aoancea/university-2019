import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CoreModule } from '../core/core.module';

import { AngularMaterialModule } from '../shared/angular-material.module';

import { DuckbillsService } from './duckbills.service';

import { DuckbillsRoutingModule } from './duckbills-routing.module';

@NgModule({
    declarations: [DuckbillsRoutingModule.routedComponents],
    imports: [
        CommonModule,
        FormsModule,
        HttpClientModule,
        CoreModule,
        AngularMaterialModule,
        ReactiveFormsModule,
        DuckbillsRoutingModule
    ],
    providers: [DuckbillsService]
})
export class DuckbillsModule { }
