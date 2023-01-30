import { Component } from '@angular/core';
import {FormBuilder, Validators} from "@angular/forms";
import {AuthService} from "../../core/services/auth/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  public hide = true;

  public loginForm = this.formBuilder.group({
    email:['', Validators.required],
    password:['', Validators.required]
  })
  constructor(private readonly formBuilder: FormBuilder,
              private readonly router: Router,
              private readonly authService: AuthService) {
  }

  ngOnInit():void {

  }

  checkForm(){
    // console.error(this.registerForm.value);
    this.authService.login(this.loginForm.value).subscribe(data => {
      this.router.navigate(['/main']).then(() => window.location.reload());
    });
    this.getFormValidationErrors(['email']);
  }
  getFormValidationErrors(keys: any){
    keys.forEach((key: any) => {
      const controlErrors = this.loginForm.get(key)?.errors;
      if (controlErrors != null){
        alert(key + " has errors" + controlErrors);
      }
    });
  }

}
