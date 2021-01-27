import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Airport } from '../models/airport';
import { ApiService } from './api.service';
import Assertion from '../shared/assertion';
import { DifferenceResponse } from '../models/reponses/difference.response';

@Injectable({
    providedIn: 'root'
})
export class AirportsService {
    private readonly url = '/api/airports';
    constructor(private readonly api: ApiService) {}

    airport(code: string): Observable<Airport> {
        Assertion.notNull(code, 'code');
        return this.api.get<Airport>(this.url + `/${code}`);
    }

    difference(first: string, second: string): Observable<DifferenceResponse> {
        return this.api.post<DifferenceResponse>(this.url + '/difference', {
            first,
            second
        });
    }
}
