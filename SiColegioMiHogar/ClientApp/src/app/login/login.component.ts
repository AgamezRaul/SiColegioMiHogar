import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm = this.fb.group({
    usuario: ['', [Validators.required]],
    password: ['', [Validators.required]],
  });
  hide = true;
  private subscription: Subscription;
  constructor(private router: Router, private location: Location, private fb: FormBuilder)
  {
    this.subscription = new Subscription();
  }

  ngOnInit(): void {
  }

}
