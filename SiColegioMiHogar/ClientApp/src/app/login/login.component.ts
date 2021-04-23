import { Component, OnDestroy, OnInit } from '@angular/core';
import { LoginService } from 'src/app/login/login.service';
import { User } from 'src/app/login/user-interface';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { from, Subscription } from 'rxjs';
import { AlertService } from '../notifications/_services';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {
  formGroup = this.fb.group({
    correo: ['', [Validators.required]],
    password: ['', [Validators.required]]
  });
  hide = true;
  private subscription: Subscription;
  constructor(private loginService: LoginService, private router: Router,
    private location: Location, private fb: FormBuilder,
    private alertService: AlertService  ) {
    this.subscription = new Subscription();
  }

  ngOnInit(): void {
  }

  onLogin(): void {
    const formValue = this.formGroup.value;
    this.subscription.add(
      this.loginService.login(formValue).subscribe((res) => {
        if (res) {
          this.router.navigate(['']);
        }
      })
    );
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
