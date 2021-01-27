import { MapLocation } from './map-location';

export interface Airport {
    city: string;
    iata: string;
    country: string;
    location: MapLocation;
}
