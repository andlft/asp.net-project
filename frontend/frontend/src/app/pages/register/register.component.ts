import { Component } from '@angular/core';
import {FormBuilder, Validators} from "@angular/forms";
import {AuthService} from "../../core/services/auth/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  public hide = true;

  public registerForm = this.formBuilder.group({
    firstName:['', Validators.required],
    lastName:['', Validators.required],
    phoneNumber:['', Validators.required],
    email:['', Validators.required],
    password:['', Validators.required],
    countyName:['', Validators.required],
    cityName:['', Validators.required],
    streetName:['', Validators.required],
    streetNo:[0, Validators.required],
    zipCode:['', Validators.required],
    buildingName:[''],
    floor:[''],
    flatNo:['']
  })



  constructor(private readonly formBuilder: FormBuilder,
              private readonly router: Router,
              private readonly authService: AuthService) {
  }

  ngOnInit():void {

  }

  sendForm(){
    // console.error(this.registerForm.value);
    this.authService.createUser(this.registerForm.value).subscribe(data => {
      this.router.navigate(['/login']).then(() => window.location.reload());
    });
    this.getFormValidationErrors(['email']);
  }
  getFormValidationErrors(keys: any){
    keys.forEach((key: any) => {
      const controlErrors = this.registerForm.get(key)?.errors;
      if (controlErrors != null){
        alert(key + " has errors" + controlErrors);
      }
    });
  }

}
