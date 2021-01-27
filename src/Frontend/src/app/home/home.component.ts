import { Component } from '@angular/core';
import { Airport } from '../models/airport';
import { DifferenceResponse } from '../models/reponses/difference.response';
import { AirportsService } from '../services/airports.service';
import { AirportByIataForm } from './airport-by-iata.form';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  form: AirportByIataForm;

  get firstAirport(): Airport { return this.difference?.first; }
  get secondAirport(): Airport { return this.difference?.second; }

  difference: DifferenceResponse;

  constructor(service: AirportsService) {
    this.form = new AirportByIataForm(service);
  }

  getDifference(): void {
    this.form.difference().subscribe(x => {
      this.difference = x;
    });
  }
}
