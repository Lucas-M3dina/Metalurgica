import { AbstractControl, ValidationErrors } from "@angular/forms";

export function passwordMatch(password : string, confirm : string ){
  return function(form : AbstractControl)  {

    const passwordValue = form.get(password)?.value
    const confirmValue = form.get(confirm)?.value

    if (passwordValue === confirmValue) {
      return null;
    } else {
      return { erroDiferentes: true };
    }
  }
}
