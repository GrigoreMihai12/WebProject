export class RecyclingRequest {
    ID: number;
    UserEmail: string;
    IDUsesr:number;
    IDCenter: number;
    Date: string;
    Status: string;
    CenterName:string;
    /**
     *
     */
    constructor(
        emailUser: string,
        idUser:number,
        idCenter: number,
        date: string,
        status: string
    ) {
        this.UserEmail = emailUser;
        this.IDUsesr=idUser;
        this.IDCenter = idCenter;
        this.Date = date;
        this.Status = status;
    }
}