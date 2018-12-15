import { NgModule, ModuleWithProviders } from "@angular/core";
import { CommonModule } from '@angular/common';
import { SessionService } from "@shared/session/session.service";
import { AppRouteGuard } from "@shared/auth/app-route-guard";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from "@angular/forms";
import { DialogComponent } from "@shared/components/dialog/dialog.component";
import { Dialog } from "@shared/services/dialog/dialog.service";
import { NgNotifyComponent } from "@shared/components/ng-notify/ng-notify.component";

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        NgbModule
    ],
    declarations: [
        DialogComponent,
        NgNotifyComponent
    ],
    exports: [
        DialogComponent,
        NgNotifyComponent
    ],
    entryComponents: [
        DialogComponent,
        NgNotifyComponent
    ],
    providers: [
    ],
})
export class SharedModule {
    static forRoot(): ModuleWithProviders {
        return {
            ngModule: SharedModule,
            providers: [
                SessionService,
                Dialog,
                AppRouteGuard
            ]
        }
    }
}
