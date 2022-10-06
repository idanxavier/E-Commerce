export class User {
    id: string;
    userName: string;
    telephoneNumber: string;
    email: string;
    fullName: string;

    constructor(
        id: string,
        userName: string,
        telephoneNumber: string,
        email: string,
        fullName: string
    ) {
        this.id = id
        this.userName = userName
        this.telephoneNumber = telephoneNumber
        this.email = email
        this.fullName = fullName
    }

}