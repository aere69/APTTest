import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProcessFileComponent } from './process-file/process-file.component';
import { HttpClientModule } from  '@angular/common/http';
import { PostManagerComponent } from './post-manager/post-manager.component';

@NgModule({
  declarations: [
    AppComponent,
    ProcessFileComponent,
    PostManagerComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
