export class PetByOwnerGender {
    public ownerGender: string;
    public catNames: Array<string>;

    constructor(gender: string) {
        this.ownerGender = gender;
        this.catNames = new Array<string>();        
    }
}
