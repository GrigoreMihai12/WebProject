import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-material',
  templateUrl: './material.component.html',
  styleUrls: ['./material.component.css']
})
export class MaterialComponent implements OnInit {
  typeMaterial: string;
  constructor(
    private _Activatedroute: ActivatedRoute
  ) {
  }

  ngOnInit(): void {
    this.typeMaterial = this._Activatedroute.snapshot.paramMap.get("typeMaterial");
  }

}
