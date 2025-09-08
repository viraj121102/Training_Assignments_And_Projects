import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { noSpacesValidator } from '../validators/no_space.validators';
import { tenDigitMobileValidator } from '../validators/number.validation';
import { Pincode } from '../validators/pincode.validator';
@Component({
  selector: 'app-reactive',
  standalone: false,
  templateUrl: './reactive.html',
  styleUrl: './reactive.css'
})
export class ReactiveformComponent {
loginForm: FormGroup;
  constructor(private fb: FormBuilder) {
    this.loginForm = fb.group({
      email: ['', [Validators.required, Validators.email,noSpacesValidator()]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      number: ['', [tenDigitMobileValidator]],
      country: ['IN'],  // default
  postalCode: ['', [Pincode(() => this.loginForm?.get('country')?.value)]]
    });
  }
  onSubmit() {
    if (this.loginForm.valid) {
      console.log('Login data:', this.loginForm.value);
      alert('Login Successful!');
    } else {
      this.loginForm.markAllAsTouched(); // Show errors
    }
  }
}