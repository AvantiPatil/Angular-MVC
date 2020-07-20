import {NgModule, CUSTOM_ELEMENTS_SCHEMA} from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatInputModule} from '@angular/material/input';
import {
  MatCardModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatListModule,
  } from '@angular/material';
  const modules = [
    MatCardModule,
    MatInputModule,
    MatButtonModule
  ];

@NgModule({
  imports: [MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatInputModule,
    MatListModule,],
  exports: [ MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatListModule,
    MatButtonModule,
    MatButtonToggleModule,],
    schemas: [
        CUSTOM_ELEMENTS_SCHEMA
      ],
    
})
export class MaterialModule {}