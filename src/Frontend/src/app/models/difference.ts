import { MapLocation } from './map-location';

export interface Difference {
    first: MapLocation;
    second: MapLocation;
    meters: number;
    miles: number;
}
