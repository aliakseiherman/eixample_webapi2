import { Component, Injectable } from "@angular/core";

@Injectable()
@Component({
    templateUrl: './ng-notify.component.html',
    styleUrls: ['./ng-notify.component.scss']
})
export class NgNotifyComponent {

    public title: string;
    public message: string;

    constructor(
        // public snackBarRef: MatSnackBarRef<NgNotifyComponent>
    ) { }

    public show() {
        // this.snackBarRef._open();
    }
}