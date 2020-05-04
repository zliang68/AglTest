import { Component, OnInit } from '@angular/core';
import { PetServiceService } from '../../services/pet-service.service';
import { PetByOwnerGender } from '../../models/pet-by-owner-gender';

@Component({
  selector: 'app-pet-list',
  templateUrl: './pet-list.component.html',
  styleUrls: ['./pet-list.component.css']
})

export class PetListComponent implements OnInit {
  pets: Array<PetByOwnerGender>;
  errorMesssage: string = '';

  constructor(private petService: PetServiceService) { }

  ngOnInit(): void {
    //get data from AGL_TEST_URL
    //this.listCatsDirect();

    //get data from local server
    this.listCats();
  }

  /**
  * Get data and transform to viewmodel
  */
  listCatsDirect(): void {
    this.petService
      .getPetListDirect()
      .subscribe(
        data => {          
          this.errorMesssage = '';
          this.pets = this.transform(data);
        },
        error => {
          this.errorHandler(error);
        }
      );
  }

  /**
   *  Get data
   */
  listCats(): void {
    this.petService
      .getPetList()
      .subscribe(
        data => {
          this.errorMesssage = '';
          this.pets = data;
        },
        error => {
          this.errorHandler(error);
        }
      );
  }

  /**
   * Use to transform data directly for AGL_TEST_URL 
   * @param data 
   */
  private transform(data: any): Array<PetByOwnerGender> {
    let maleOwner = new PetByOwnerGender('Male');
    let femaleOwner = new PetByOwnerGender('female');
    let result = new Array<PetByOwnerGender>();
    result.push(maleOwner);
    result.push(femaleOwner);

    data.forEach(o => {
      if (o.gender === 'Male' && o.pets != null) {
        o.pets.forEach(p => {
          if (p.type === 'Cat') {
            maleOwner.catNames.push(p.name);
          }
        });
      }
      if (o.gender === 'Female' && o.pets != null) {
        o.pets.forEach(p => {
          if (p.type === 'Cat') {
            femaleOwner.catNames.push(p.name);
          }
        });
      } 
    });

    maleOwner.catNames.sort();
    femaleOwner.catNames.sort();

    return result;    
  }

  /**
   * Error handling 
   * @param error 
   */
  errorHandler(error: any): void {
    this.errorMesssage = JSON.parse(error.error); 
    console.log(error);
  }
}
