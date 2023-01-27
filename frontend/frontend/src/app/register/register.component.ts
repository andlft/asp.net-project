import { Component } from '@angular/core';
import {FormBuilder, Validators} from "@angular/forms";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  public hide = true;

  public registerForm = this.formBuilder.group({
    email:['', Validators.required],
    password:['', Validators.required]
  })
  constructor(private readonly formBuilder: FormBuilder) {
  }

  ngOnInit():void {

  }

  checkForm(){
    console.error(this.registerForm.value);
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
