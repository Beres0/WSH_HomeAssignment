import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CustomFormat } from './models/types';

export abstract class ApiService {
    url: string = 'api';
    constructor(protected http: HttpClient) {}
    protected combineToRoute(...values: any[]): string {
        const mapped = values.map((v) => this.mapParameter(v));
        return mapped.join('/');
    }

    protected mapParameter(value: any): string {
        var customFormat = value as CustomFormat;
        if (customFormat.getFormat != undefined) {
            return customFormat.getFormat();
        } else {
            return String(value);
        }
    }

    protected convertToQueryParams(obj: any) {
        let params = new HttpParams();
        if (!obj) return params;
        Object.keys(obj).forEach((k) => {
            if (obj[k]) {
                params = params.append(k, this.mapParameter(obj[k]));
            }
        });
        return params;
    }
}
