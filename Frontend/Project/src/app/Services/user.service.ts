import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../Models/User';


@Injectable({
    providedIn: 'root'
})
export class UserService {
    constructor(
        private http: HttpClient
    ) { }

    GetAllUsers() {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };
        const url = 'https://localhost:44326/api/User/GetAllUsers';
        return this.http.get<User[]>(url, httpOptions);
    }

    Login(user: User) {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        }
        const path = 'https://localhost:44326/api/User/Login/';
        return this.http.post<boolean>(path, user, httpOptions);
    }
    AddUser(user: User) {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        }
        const path = 'https://localhost:44326/api/User/AddUser/';
        return this.http.post<boolean>(path, user, httpOptions);
    }
    DeleteUser(id: number) {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        }
        const path = 'https://localhost:44326/api/User/DeleteUser/';
        return this.http.post<boolean>(path, id, httpOptions);
    }
    UpdateUser(user: User) {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        }
        const path = 'https://localhost:44326/api/User/UpdateUser';
        return this.http.post<boolean>(path, user, httpOptions);
    }
    GetByID(id: number) {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        }
        const path = 'https://localhost:44326/api/User/GetByID/';
        return this.http.post<User>(path, id, httpOptions);
    }
    GetUserByEmail(userEmail: string) {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };
        const url = 'https://localhost:44326/api/User/GetUserByEmail/' + userEmail;
        return this.http.get<User>(url, httpOptions);
    }
    GetUsersByNeighbourhood(neighbourhood: string) {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };
        const url = 'https://localhost:44326/api/User/GetUsersByNeighbourhood/' + neighbourhood;
        return this.http.get<User[]>(url, httpOptions);
    }

    GetUsersByMaterialType(materialType: string) {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };
        const url = 'https://localhost:44326/api/User/GetUsersByMaterialType/' + materialType;
        return this.http.get<User[]>(url, httpOptions);
    }
    GetUserByType(type: string) {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };
        const url = 'https://localhost:44326/api/User/GetUserByType/' + type;
        return this.http.get<User[]>(url, httpOptions);
    }
}