import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PetByOwnerGender } from '../models/pet-by-owner-gender';

@Injectable({
  providedIn: 'root'
})
export class PetServiceService {

  private AGL_TEST_URL = 'http://agl-developer-test.azurewebsites.net/people.json';
  private LOCAL_DEV_URL = 'http://localhost:12073/api/people/cats';
  constructor(private httpClient: HttpClient) { }

  /**
   *  Get data from local dev URL
   */
  getPetList(): Observable<Array<PetByOwnerGender>> {
    return this.httpClient.get<Array<PetByOwnerGender>>(this.LOCAL_DEV_URL);
  }

  /**
   *  Get data directly from AGL_TEST_URL
   */
  getPetListDirect(): Observable<any> {
    return this.httpClient.get(this.AGL_TEST_URL);
  }  
}
