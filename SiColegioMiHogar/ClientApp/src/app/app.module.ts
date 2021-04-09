import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MaterialModule } from './material-module';
import { CheckLoginGuard } from './shared/guards/check-login.guard';
import { CheckNotloginGuard } from './shared/guards/check-notlogin.guard';

//COMPONENTES
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { SidenavMenuComponent } from './sidenav-menu/sidenav-menu.component';
import { HomeComponent } from './home/home.component';
import { EstudianteComponent } from './estudiante/estudiante.component';
import { FormEstudianteComponent } from './estudiante/form-estudiante/form-estudiante.component';
import { PreMatriculaComponent } from './pre-matricula/pre-matricula.component';
import { ResponsableComponent } from './responsable/responsable.component';
import { FormResponsablePadreComponent } from './responsable/form-responsable-padre/form-responsable-padre.component';
import { FormResponsableMadreComponent } from './responsable/form-responsable-madre/form-responsable-madre.component';
import { FormResponsableAcudienteComponent } from './responsable/form-responsable-acudiente/form-responsable-acudiente.component';
import { LoginComponent } from './login/login.component';
import { UsuarioComponent } from './login/usuario/usuario.component';
import { FormUsuarioComponent } from './login/usuario/form-usuario/form-usuario.component';
import { PerfilComponent } from './login/perfil/perfil.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MensualidadComponent } from './mensualidad/mensualidad.component';
import { FormMensualidadComponent } from './mensualidad/form-mensualidad/form-mensualidad.component';
import { ListMensualidadComponent } from './mensualidad/list-mensualidad/list-mensualidad.component';
import { EditMensualidadComponent } from './mensualidad/edit-mensualidad/edit-mensualidad.component';
import { FormDocenteComponent } from './Docente/form-docente/form-docente.component';
import { GestionDeMateriasComponent } from './gestion-de-materias/gestion-de-materias.component';
import { UsuarioService } from './login/usuario/usuario.service';
import { PreMatriculaService } from './pre-matricula/pre-matricula.service';
import { TablePrematriculaComponent } from './pre-matricula/table-prematricula/table-prematricula.component';
import { FormPreMatriculaComponent } from './pre-matricula/form-pre-matricula/form-pre-matricula.component';
import { CdkColumnDef } from '@angular/cdk/table';
import { MatriculaComponent } from './matricula/matricula.component';
import { TableMatriculaComponent } from './matricula/table-matricula/table-matricula.component';
import { CursoComponent } from './curso/curso.component';
import { FormCursoComponent } from './curso/form-curso/form-curso.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    SidenavMenuComponent,
    HomeComponent,
    EstudianteComponent,
    FormEstudianteComponent,
    PreMatriculaComponent,
    ResponsableComponent,
    FormResponsablePadreComponent,
    FormResponsableMadreComponent,
    FormResponsableAcudienteComponent,
    LoginComponent,
    UsuarioComponent,
    FormUsuarioComponent,
    PerfilComponent,
    MensualidadComponent,
    FormMensualidadComponent,
    ListMensualidadComponent,
    EditMensualidadComponent,
  
    FormDocenteComponent,
    GestionDeMateriasComponent,
    TablePrematriculaComponent,
    FormPreMatriculaComponent,
    MatriculaComponent,
    TableMatriculaComponent,
    CursoComponent,
    FormCursoComponent,

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    MaterialModule,
    HttpClientModule,
    FormsModule,
    MatDatepickerModule, MatNativeDateModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'registrar-usuario', component: FormUsuarioComponent },
      { path: 'registrar-prematricula', component: FormPreMatriculaComponent },
      { path: 'prematricula', component: PreMatriculaComponent },
      { path: 'matricula', component: MatriculaComponent },
      { path: 'login', component: LoginComponent },
      { path: 'registrar-mensualidad/:id', component: FormMensualidadComponent },
      { path: 'list-mensualidad', component: MensualidadComponent },
      { path: 'edit-mensualidad/:mes', component: EditMensualidadComponent },

      { path: 'login', component: LoginComponent, canActivate: [CheckLoginGuard] },
      { path: 'gestion-de-materias', component: GestionDeMateriasComponent }
], { relativeLinkResolution: 'legacy' })
  ],
  //Aquí en providers se agregan todos los services de angular
  providers: [UsuarioService, PreMatriculaService, CdkColumnDef],
  bootstrap: [AppComponent]
})
export class AppModule { }

