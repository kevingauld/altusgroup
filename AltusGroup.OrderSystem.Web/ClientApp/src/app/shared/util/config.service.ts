import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {

  _apiUri: string;

  constructor() { 
    this._apiUri = environment.envWebServiceUri;
  }

  getApiUri(){
    return this._apiUri;
  }
}
