import { AbstractControl, ValidationErrors } from '@angular/forms';

export function tenDigitMobileValidator(control: AbstractControl): ValidationErrors | null {
  const value = control.value;
  const isValid = /^[0-9]{10}$/.test(value);
  return isValid ? null : { invalidMobile: true };
}
