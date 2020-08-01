import {NgModule, CUSTOM_ELEMENTS_SCHEMA} from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatInputModule} from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import {
  MatCardModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatListModule,
    MatFormFieldModule,
  } from '@angular/material';
import { LayoutModule } from '@angular/cdk/layout';

  const modules = [
    MatCardModule,
    MatInputModule,
    MatButtonModule
  ];

@NgModule({
  imports: [MatSidenavModule,
    MatToolbarModule,
   
    MatIconModule,
    MatMenuModule,
    MatInputModule,
    MatListModule,
   MatFormFieldModule,
    MatButtonModule,
   
    LayoutModule,],
  exports: [ MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatListModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatFormFieldModule,
  ],
    schemas: [
        CUSTOM_ELEMENTS_SCHEMA
      ],
    declarations: [],
    
})
export class MaterialModule {}