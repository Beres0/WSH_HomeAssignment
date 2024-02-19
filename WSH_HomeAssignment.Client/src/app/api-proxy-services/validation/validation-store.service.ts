import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiService } from '../api.service';
import { ValidationDto } from '../models/types';
import { Observable, lastValueFrom } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class ValidationStoreService extends ApiService {
    override url = 'api/validation';
    private values?: ValidationDto;
    constructor(http: HttpClient) {
        super(http);
    }

    async getValues() {
        if (this.values == undefined) {
            this.values = await lastValueFrom(
                this.http.get<ValidationDto>(this.url + '/values')
            );
        }
        return this.values;
    }
}
