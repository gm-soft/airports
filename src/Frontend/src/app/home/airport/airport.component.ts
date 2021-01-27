import { Component, Input, OnInit } from '@angular/core';
import { Airport } from 'src/app/models/airport';

@Component({
  selector: 'app-airport',
  templateUrl: './airport.component.html',
  styleUrls: ['./airport.component.css']
})
export class AirportComponent {
  @Input()
  airport: Airport;
}
