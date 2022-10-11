import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, map, Observable } from "rxjs";
import { signupDTO } from "src/app/model/DTOs/signUpDTO";
import { User } from "src/app/model/User";
import { UserDTO } from "src/app/model/DTOs/userDTO";
import { environment } from "src/environments/environment";

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private currentUserSubject: BehaviorSubject<User | null>;
    public currentUserObservable: Observable<User | null>;

    private accessTokenSubject: BehaviorSubject<string | null>;
    public accessTokenObservable: Observable<string | null>;

    constructor(private http: HttpClient) {
        this.currentUserSubject = new BehaviorSubject<User | null>(JSON.parse(localStorage.getItem('currentUser')!));
        this.currentUserObservable = this.currentUserSubject.asObservable();

        this.accessTokenSubject = new BehaviorSubject<string | null>(JSON.parse(localStorage.getItem('accessToken')!));
        this.accessTokenObservable = this.accessTokenSubject.asObservable();
    }


    public get currentUser(): User | null {
        return this.currentUserSubject.value;
    }

    public get accessToken(): string | null {
        return this.accessTokenSubject.value;
    }

    login(username: string, password: string) {
        return this.http.post<any>(`${environment.apiUrl}/Auth/sign-in`, { username, password })
            .pipe(map((data: UserDTO) => {
                localStorage.setItem('currentUser', JSON.stringify(data.user));
                localStorage.setItem('accessToken', JSON.stringify(data.access_token));
                this.currentUserSubject.next(data.user);
                this.accessTokenSubject.next(data.access_token);
                return data;
            }))
    }

    logout() {
        localStorage.removeItem('currentUser');
        localStorage.removeItem('accessToken');
        this.currentUserSubject.next(null)
        this.accessTokenSubject.next(null);
        window.location.reload();
        return true
    }

    register(user: signupDTO) {
        return this.http.post<any>(`${environment.apiUrl}/Auth/sign-up`, user)
            .pipe(map((data: UserDTO) => {
                return data;
            }))
    }

    listUsers() {
        return this.http.get<any>(`${environment.apiUrl}/Auth/list-users`)
            .pipe(map((data: User[]) => {
                return data;
            }))
    }

    getUserById(id: string) {
        return this.http.get<any>(`${environment.apiUrl}/Auth/get-user-by-id?userId=` + id)
            .pipe(map((data: User) => {
                return data;
            }))
    }
}