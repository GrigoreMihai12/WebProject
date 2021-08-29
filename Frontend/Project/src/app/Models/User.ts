import { UserMaterialType } from "./UserMaterialType";

export class User {
    ID: number;
    Name: string;
    Email: string;
    PhoneNumber: string;
    Address: string;
    Password: string;
    Type: string;
    Neighbourhood: string;
    UserMaterialTypes: UserMaterialType[];
    RecycledMaterials: string;
    /**
     *
     */
    constructor(
        id: number,
        name: string,
        email: string,
        phoneNumber: string,
        address: string,
        password: string,
        type: string,
        neighbourhood: string,
        userMtaerialTypes: UserMaterialType[]
    ) {
        this.ID = id;
        this.Name = name;
        this.Email = email;
        this.PhoneNumber = phoneNumber;
        this.Address = address;
        this.Password = password;
        this.Type = type;
        this.Neighbourhood = neighbourhood;
        this.UserMaterialTypes = userMtaerialTypes;
    }
}