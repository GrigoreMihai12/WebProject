import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RecyclingRequest } from '../Models/RecyclingRequest';


@Injectable({
    providedIn: 'root'
})
export class RequestService {
    constructor(
        private http: HttpClient
    ) { }

    GetAllRequests() {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };
        const url = 'https://localhost:44326/api/Request/GetAllRequests';
        return this.http.get<RecyclingRequest[]>(url, httpOptions);
    }

    AddRequest(request: RecyclingRequest) {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        }
        const path = 'https://localhost:44326/api/Request/AddRequest';
        return this.http.post<boolean>(path, request, httpOptions);
    }

    GetByID(id: number) {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        }
        const path = 'https://localhost:44326/api/Request/GetByID/';
        return this.http.post<RecyclingRequest>(path, id, httpOptions);
    }
    GetByUserID(id: number) {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        }
        const path = 'https://localhost:44326/api/Request/GetByUserID/' + id;
        return this.http.get<RecyclingRequest[]>(path, httpOptions);
    }
    GetPendingRequestByCenterID(id: number) {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        }
        const path = 'https://localhost:44326/api/Request/GetPendingRequestByCenterID/' + id;
        return this.http.get<RecyclingRequest[]>(path, httpOptions);
    }
    AcceptRequest(id){
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        }
        const path = 'https://localhost:44326/api/Request/AcceptRequest/';
        return this.http.post<RecyclingRequest>(path, id, httpOptions);
    }
    DeclinedRequest(id){
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        }
        const path = 'https://localhost:44326/api/Request/DeclinedRequest/';
        return this.http.post<RecyclingRequest>(path, id, httpOptions);
    }
}