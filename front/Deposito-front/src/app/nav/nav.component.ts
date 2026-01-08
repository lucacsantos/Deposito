import { Component, OnInit } from '@angular/core';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { RouterLink } from "@angular/router";

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  imports: [CollapseModule, RouterLink],
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  isCollapsed = true;

  constructor() { }

  ngOnInit() {
  }

}
