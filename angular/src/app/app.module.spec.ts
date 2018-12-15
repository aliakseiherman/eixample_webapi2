import { AppModule } from './app.module';
import { TestBed } from '@angular/core/testing';
import { SessionService } from '@shared/session/session.service';

describe('AppModule', () => {
    let appModule: AppModule;

    TestBed.configureTestingModule({
        declarations: [SessionService],
        providers: []
    });
    
    it('should create an instance', () => {
        expect(appModule).toBeTruthy();
    });
});
