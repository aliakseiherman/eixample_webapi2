import { Injectable } from "@angular/core";
import { AuthServiceProxy, AuthenticateInput, AuthenticateOutput } from "@shared/service-proxies/service-proxies";
import { Router } from "@angular/router";
import { AppConsts } from "@shared/AppConsts";
import { UrlHelper } from "@shared/UrlHelper";
import { SessionService } from "@shared/session/session.service";

@Injectable()
export class LoginService {

    loginModel: AuthenticateInput;
    loginResult: AuthenticateOutput;

    constructor(
        private _router: Router,
        private _authService: AuthServiceProxy,
        private _sessionService: SessionService
    ) {
        this.clear();
    }

    login(finallyCallback?: () => void): void {
        finallyCallback = finallyCallback || (() => { });

        this._authService.authenticate(this.loginModel)
            .finally(finallyCallback)
            .subscribe((result: AuthenticateOutput) => {

                localStorage.setItem(AppConsts.auth.token, result.token);
                location.href = UrlHelper.getInitialUrl();
            });
    }

    private clear(): void {
        this.loginModel = new AuthenticateInput();
        this.loginModel.rememberMe = true;
        this.loginResult = null;
    }
}