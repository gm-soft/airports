import { Airport } from '../airport';
import { Difference } from '../difference';

export interface DifferenceResponse {
    first: Airport;
    second: Airport;
    difference: Difference;
}
