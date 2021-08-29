import { Injectable } from '@angular/core'
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { MaterialType } from '../Models/MaterialType';

@Injectable({
    providedIn: 'root'
})
export class MaterialTypeService {
    constructor(
        private http: HttpClient
    ) { }
    GetAllMaterialTypes() {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json'
            })
        };
        const url = 'https://localhost:44326/api/MaterialType/GetAllMaterialTypes';
        return this.http.get<MaterialType[]>(url, httpOptions);
    }
}