export class signupDTO {
    userName: string;
    email: string;
    password: string;
    ConfirmPassword: string;
    TelephoneNumber: string;

    constructor(
        userName: string,
        email: string,
        password: string,
        ConfirmPassword: string,
        TelephoneNumber: string
    ) {
        this.userName = userName
        this.email = email
        this.password = password
        this.ConfirmPassword = ConfirmPassword
        this.TelephoneNumber = TelephoneNumber
    }

}