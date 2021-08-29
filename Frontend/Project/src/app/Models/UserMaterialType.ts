export class UserMaterialType {
    UserId: number;
    MaterialTypeId: number;

    constructor(
        id_user: number,
        id_materialType: number
    ) {
        this.UserId = id_user;
        this.MaterialTypeId = id_materialType;
    }
       
}