import { Component, Input } from '@angular/core';
import { MapLocation } from 'src/app/models/map-location';

@Component({
  selector: 'app-location',
  templateUrl: './location.component.html',
  styleUrls: ['./location.component.css']
})
export class LocationComponent {
  @Input()
  location: MapLocation;
}
