import {Component} from '@angular/core';
import {UserService} from "./services/user.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
  title = 'anyu-ui';

  constructor(private userService: UserService) { // todo: delete, this is just for debug
    try {
      userService.getPagedList("", 1, 1).then((res) => {
        console.log(JSON.stringify(res));
      });
    } catch (e) {
      console.log(e);
    }
  }
}
