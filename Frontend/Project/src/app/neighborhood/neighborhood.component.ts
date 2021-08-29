import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from '../Models/User';
import {UserService} from '../Services/user.service';

var map;
var geocoder;

@Component({
  selector: 'app-neighborhood',
  templateUrl: './neighborhood.component.html',
  styleUrls: ['./neighborhood.component.css']
})
export class NeighborhoodComponent implements OnInit {

  lat: number=46.76766536697466;
  long: number=23.591401755766128;
  neighborhoodName: string;
  usersByNeighBourhood: User[];
  constructor(
    private _Activatedroute: ActivatedRoute,
    private userService: UserService
  ) {
    this.neighborhoodName = this._Activatedroute.snapshot.paramMap.get("neighborhoodName");
    this.userService.GetUsersByNeighbourhood(this.neighborhoodName).subscribe(response => {
      this.usersByNeighBourhood =  response.filter(x=> x.Type == "RECYCLING_CENTER");
      this.usersByNeighBourhood.forEach(element => {
        element.RecycledMaterials = "";
        element.UserMaterialTypes.forEach(element2 => {
          if (element2.MaterialTypeId == 1)
          element.RecycledMaterials += "Plastic, ";
          if (element2.MaterialTypeId == 2)
          element.RecycledMaterials += "Paper, ";
          if (element2.MaterialTypeId == 3)
          element.RecycledMaterials += "Metal, ";
          if (element2.MaterialTypeId == 4)
          element.RecycledMaterials += "Textiles, "; 
        });

        element.RecycledMaterials = element.RecycledMaterials.slice(0, -2);
      });
      })
  }

  ngOnInit(): void {
    this.initializeMap();
  }

  initializeMap() {
    geocoder = new google.maps.Geocoder();
    var latlng = new google.maps.LatLng(this.lat,this.long);
    var mapOptions = {
      zoom: 17,
      center: latlng
    }
    map = new google.maps.Map(document.getElementById('googleMapsDiv'), mapOptions);
  }

  getGeoLocation(name: string) {
    let geocoder = new google.maps.Geocoder();

    geocoder.geocode( { 'address': name + ' Cluj Napoca'}, function(results, status) {
      if (status == 'OK') {
      map.setCenter(results[0].geometry.location);
        var marker = new google.maps.Marker({
            map: map,
            position: results[0].geometry.location
        });
      } else {
        alert('Geocode was not successful for the following reason: ' + status);
      }
    })
  }

}
