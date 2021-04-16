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
import { TableCursoComponent } from './curso/table-curso/table-curso.component';
import { DocenteComponent } from './docente/docente.component';
import { ListMateriaComponent } from './gestion-de-materias/list-materia/list-materia.component';
import { GestionDeMateriasService } from './gestion-de-materias/gestion-de-materias.service';
import { FromMateriaComponent } from './gestion-de-materias/from-materia/from-materia.component';
import { EditMateriaComponent } from './gestion-de-materias/edit-materia/edit-materia.component';
import { PeriodoComponent } from './periodo/periodo.component';
import { FormPeriodoComponent } from './periodo/form-periodo/form-periodo.component';
import { TablePeriodoComponent } from './periodo/table-periodo/table-periodo.component';
import { ListDocenteComponent } from './Docente/list-docente/list-docente.component';
import { EditDocenteComponent } from './Docente/edit-docente/edit-docente.component';
import { NotaComponent } from './nota/nota.component';
import { FormNotaComponent } from './nota/form-nota/form-nota.component';
import { TableNotaComponent } from './nota/table-nota/table-nota.component';


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
    FormDocenteComponent,
    GestionDeMateriasComponent,
    TablePrematriculaComponent,
    FormPreMatriculaComponent,
    MatriculaComponent,
    TableMatriculaComponent,
    CursoComponent,
    FormCursoComponent,
    TableCursoComponent,
    DocenteComponent,
    ListMateriaComponent,
    FromMateriaComponent,
    EditMateriaComponent,
    PeriodoComponent,
    FormPeriodoComponent,
    TablePeriodoComponent,
    ListDocenteComponent,
    EditDocenteComponent,
    NotaComponent,
    FormNotaComponent,
    TableNotaComponent,

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
      { path: 'prematricula', component: PreMatriculaComponent },
      { path: 'registrar-prematricula', component: FormPreMatriculaComponent },
      { path: 'editar-prematricula/:id', component: FormPreMatriculaComponent },
      { path: 'matricula', component: MatriculaComponent },
      { path: 'login', component: LoginComponent },
      { path: 'registrar-mensualidad/:id', component: FormMensualidadComponent },
      { path: 'editar-mensualidad/:idMensualidad', component: FormMensualidadComponent },
      { path: 'consultar-mensualidad/:id', component: MensualidadComponent },
      { path: 'registrar-curso', component: FormCursoComponent },
      { path: 'login', component: LoginComponent, canActivate: [CheckLoginGuard] },
      { path: 'materias', component: ListMateriaComponent },
      { path: 'registrar-materia', component: FromMateriaComponent },
      { path: 'registrar-materia/:idMateria', component: FromMateriaComponent },
      { path: 'listar-periodos', component: TablePeriodoComponent },
      { path: 'registrar-periodo', component: FormPeriodoComponent },
      { path: 'registrar-Docente', component: DocenteComponent },
      { path: 'lista-docente', component: ListDocenteComponent },
      { path: 'editar-docente',component:EditDocenteComponent},
      { path: 'registrar-periodo', component: FormPeriodoComponent },
      { path: 'listar-notas', component: TableNotaComponent },
      { path: 'registrar-nota', component: FormNotaComponent },
], { relativeLinkResolution: 'legacy' })
  ],
  //Aquí en providers se agregan todos los services de angular
  providers: [UsuarioService, PreMatriculaService, CdkColumnDef, GestionDeMateriasService],
  bootstrap: [AppComponent]
})
export class AppModule { }

