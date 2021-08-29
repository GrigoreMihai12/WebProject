import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-how-to-recycle',
  templateUrl: './how-to-recycle.component.html',
  styleUrls: ['./how-to-recycle.component.css']
})
export class HowToRecycleComponent implements OnInit {

  constructor(
    private router: Router,
  ) { }

  ngOnInit(): void {
  }

GoToHome()
{
  this.router.navigate(['/home'])
}

}
