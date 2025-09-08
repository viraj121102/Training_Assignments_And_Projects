import { AbstractControl, ValidationErrors } from '@angular/forms';

export function Pincode(countryGetter: () => string) {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.value;
      const countryRaw = countryGetter();
    const country = (countryRaw || '').toUpperCase();
    let regex;

    switch (country) {
      case 'IN':
        regex = /^[1-9][0-9]{5}$/;
        break;
      case 'US':
        regex = /^\d{5}(-\d{4})?$/;
        break;
      default:
        return { unsupportedCountry: true };
    }

    return regex.test(value) ? null : { invalidPostalCode: true };
  };
}
