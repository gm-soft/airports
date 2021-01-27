import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { Airport } from '../models/airport';
import { DifferenceResponse } from '../models/reponses/difference.response';
import { AirportsService } from '../services/airports.service';
import Assertion from '../shared/assertion';

export class AirportByIataForm extends FormGroup {

    private readonly airportsService: AirportsService;

    constructor(airportsService: AirportsService) {
        super({
            first: new FormControl(null, [Validators.required]),
            second: new FormControl(null, [Validators.required])
        });
        Assertion.notNull(airportsService, 'airportsService');
        this.airportsService = airportsService;
    }

    showFirst(): Observable<Airport> {
        return this.airportsService.airport(this.first());
    }

    showSecond(): Observable<Airport> {
        return this.airportsService.airport(this.second());
    }

    difference(): Observable<DifferenceResponse> {
        return this.airportsService.difference(this.first(), this.second());
    }

    private first(): string {
        const first = this.value.first as string;
        Assertion.notNull(first, 'first');
        return first;
    }

    private second(): string {
        const second = this.value.second as string;
        Assertion.notNull(second, 'second');
        return second;
    }

}
