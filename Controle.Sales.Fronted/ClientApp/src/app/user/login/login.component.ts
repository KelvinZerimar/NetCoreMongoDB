import { Component, OnInit } from '@angular/core';
import { UserService } from '../../Service/user.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {
  formModel = {
    Username: '',
    Password: ''
  }
  constructor(private service: UserService, private router: Router) {

  }

  ngOnInit() {
    if (localStorage.getitem('token' != null))
      this.router.navigateByUrl('/home');
  }

  onSubmit(form: NgForm) {
    this.service.login(form.value).subscribe(
      (res: any) => {
        localStorage.setItem('token', res.token);
        this.router.navigateByUrl('/home');
      },
      err => {
        if (err.status == 400)
          console.warn('Incorrect username or password.', 'Authentication failed.');
        else
          console.log(err);
      }
    );
  }
}
