import { Injectable } from '@angular/core'
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Material } from '../Models/Material';

@Injectable({
    providedIn: 'root'
})
export class MaterialService {
    constructor(
        private http: HttpClient
    ) { }
    GetAllMaterials() {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };
        const url = 'https://localhost:44326/api/Material/GetAllMaterials';
        return this.http.get<Material[]>(url, httpOptions);
    }
    GroupByType(type:string) {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };
        const url = 'https://localhost:44326/api/Material/GroupByType/'+type;
        return this.http.get<Material[]>( url, httpOptions);
    }
}