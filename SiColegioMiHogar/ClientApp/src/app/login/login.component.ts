import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  constructor(private fb: FormBuilder, private router: Router,
    private activatedRoute: ActivatedRoute) { }

  formGroup = this.fb.group({
    correo: ['', [Validators.required]],
    password: ['', [Validators.required]]
  });

  ngOnInit(): void {
  }

}
