export class Profile {
    Name: string;
    Email: string;
    PhoneNumber: string;
    Address: string;

    constructor(
        name: string,
        email: string,
        phoneNumber: string,
        address: string
    ) {
        this.Name = name;
        this.Email = email;
        this.PhoneNumber = phoneNumber;
        this.Address = address;
    }
}