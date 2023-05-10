import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LayoutComponent } from './layout/layout.component';
import { LoginComponent } from './login/login.component';
import { AccessForbiddenComponent } from './access-forbidden/access-forbidden.component';
import { authGuard } from './shared/guard/auth.guard';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { AuthenticationService } from './shared/services/authentication.service';
import { AuthInterceptor } from './shared/interceptors/auth.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
    LoginComponent,
    AccessForbiddenComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [AuthenticationService, {
    provide:HTTP_INTERCEPTORS, 
    useClass: AuthInterceptor,
    multi:true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
