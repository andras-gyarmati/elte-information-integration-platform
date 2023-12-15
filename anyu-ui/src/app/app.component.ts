import { Component, signal } from '@angular/core';
import { UserService } from "./services/user.service";
import { Router } from "@angular/router";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'anyu-ui';

  constructor(private router: Router, private userService: UserService) { // todo: delete, this is just for debug
    try {
      userService.getPagedList("", 1, 1).then((res) => {
        console.log(JSON.stringify(res));
      });
    } catch (e) {
      console.log(e);
    }
  }

  logoClicked() {
    this.router.navigate(['/']);
  }
}
