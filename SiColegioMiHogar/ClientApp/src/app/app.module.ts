import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MaterialModule } from './material-module';
import { CheckLoginGuard } from './shared/guards/check-login.guard';
import { CheckNotloginGuard } from './shared/guards/check-notlogin.guard';
import { AlertComponent } from './notifications/_directives/index';
import { AlertService } from './notifications/_services/index';

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
import { MatDatepicker, MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MensualidadComponent } from './mensualidad/mensualidad.component';
import { FormMensualidadComponent } from './mensualidad/form-mensualidad/form-mensualidad.component';
import { ListMensualidadComponent } from './mensualidad/list-mensualidad/list-mensualidad.component';
import { FormDocenteComponent } from './docente/form-docente/form-docente.component';
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
import { PeriodoComponent } from './periodo/periodo.component';
import { FormPeriodoComponent } from './periodo/form-periodo/form-periodo.component';
import { TablePeriodoComponent } from './periodo/table-periodo/table-periodo.component';
import { ListDocenteComponent } from './docente/list-docente/list-docente.component';
import { NotaComponent } from './nota/nota.component';
import { FormNotaComponent } from './nota/form-nota/form-nota.component';
import { TableNotaComponent } from './nota/table-nota/table-nota.component';
import { MateriaComponent } from './materia/materia.component';
import { FormMateriaComponent } from './materia/form-materia/form-materia.component';
import { ListMateriaComponent } from './materia/list-materia/list-materia.component';
import { MateriaService } from './materia/materia.service';
import { ConsultarNotaComponent } from './nota/consultar-nota/consultar-nota.component';
import { DocenteService } from './docente/docente.service';
import { CursoService } from './curso/curso.service';
import { MensualidadService } from './mensualidad/mensualidad.service';
import { MatriculaService } from './matricula/matricula.service';
import { NotaService } from './nota/nota.service';
import { PeriodoService } from './periodo/periodo.service';
import { EstudiantePrematriculaComponent } from './pre-matricula/estudiante-prematricula/estudiante-prematricula.component';
import { FormUsuarioDocenteComponent } from './login/usuario/form-usuario-docente/form-usuario-docente.component';
import { ListUsuarioComponent } from './login/usuario/list-usuario/list-usuario.component';
import { FormNotaPeriodoComponent } from './nota-periodo/form-nota-periodo/form-nota-periodo.component';
import { NotaPeriodoComponent } from './nota-periodo/nota-periodo.component';
import { TableNotaPeriodoComponent } from './nota-periodo/table-nota-periodo/table-nota-periodo.component';
import { ContratoComponent } from './contrato/contrato.component';
import { FormContratoComponent } from './contrato/form-contrato/form-contrato.component';
import { TableContratoComponent } from './contrato/table-contrato/table-contrato.component';
import { FormUsuarioAdminComponent } from './login/usuario/form-usuario-admin/form-usuario-admin.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormUsuarioActualizarComponent } from './login/usuario/form-usuario-actualizar/form-usuario-actualizar.component';
import { MensajesModule } from './mensajes/mensajes.module';
import { ActividadComponent } from './actividad/actividad.component';
import { TableActividadComponent } from './actividad/table-actividad/table-actividad.component';
import { MateriaDocenteComponent } from './docente/materia-docente/materia-docente.component';
import { DialogoActividadComponent } from './actividad/dialogo-actividad/dialogo-actividad.component';

@NgModule({
  declarations: [
    AppComponent,
    AlertComponent,
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
    TablePrematriculaComponent,
    FormPreMatriculaComponent,
    MatriculaComponent,
    TableMatriculaComponent,
    CursoComponent,
    FormCursoComponent,
    TableCursoComponent,
    DocenteComponent,
    PeriodoComponent,
    FormPeriodoComponent,
    TablePeriodoComponent,
    ListDocenteComponent,
    NotaComponent,
    FormNotaComponent,
    TableNotaComponent,
    MateriaComponent,
    FormMateriaComponent,
    ListMateriaComponent,
    ConsultarNotaComponent,
    EstudiantePrematriculaComponent,
    FormUsuarioDocenteComponent,
    ListUsuarioComponent,
    FormNotaPeriodoComponent,
    NotaPeriodoComponent,
    TableNotaPeriodoComponent,
    ContratoComponent,
    FormContratoComponent,
    TableContratoComponent,
    FormUsuarioAdminComponent,
    FormUsuarioActualizarComponent,
    ActividadComponent,
    TableActividadComponent,
    MateriaDocenteComponent,
    DialogoActividadComponent

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
      { path: 'login', component: LoginComponent, canActivate: [CheckLoginGuard] },
      { path: 'registrar-usuario', component: FormUsuarioComponent, canActivate: [CheckLoginGuard] },
      { path: 'prematricula', component: PreMatriculaComponent, canActivate: [CheckNotloginGuard] },
      { path: 'registrar-prematricula', component: FormPreMatriculaComponent, canActivate: [CheckNotloginGuard] },
      { path: 'editar-prematricula/:id', component: FormPreMatriculaComponent, canActivate: [CheckNotloginGuard] },
      { path: 'matricula', component: MatriculaComponent, canActivate: [CheckNotloginGuard] },

      { path: 'registrar-mensualidad/:id', component: FormMensualidadComponent, canActivate: [CheckNotloginGuard] },
      { path: 'editar-mensualidad/:idMensualidad', component: FormMensualidadComponent, canActivate: [CheckNotloginGuard] },
      { path: 'consultar-mensualidad/:id', component: MensualidadComponent, canActivate: [CheckNotloginGuard] },

      { path: 'cursos', component: CursoComponent, canActivate: [CheckNotloginGuard] },
      { path: 'registrar-curso', component: FormCursoComponent, canActivate: [CheckNotloginGuard]  },
      { path: 'editar-curso/:idCurso', component: FormCursoComponent, canActivate: [CheckNotloginGuard]  },
      { path: 'cursos', component: CursoComponent, canActivate: [CheckNotloginGuard] },
      { path: 'registrar-curso', component: FormCursoComponent, canActivate: [CheckNotloginGuard] },
      
      { path: 'materias', component: ListMateriaComponent, canActivate: [CheckNotloginGuard] },
      { path: 'registrar-materia', component: FormMateriaComponent, canActivate: [CheckNotloginGuard] },
      { path: 'editar-materia/:id', component: FormMateriaComponent, canActivate: [CheckNotloginGuard] },

      { path: 'periodos', component: TablePeriodoComponent, canActivate: [CheckNotloginGuard] },
      { path: 'registrar-periodo', component: FormPeriodoComponent, canActivate: [CheckNotloginGuard] },
      { path: 'editar-periodo/:id', component: FormPeriodoComponent, canActivate: [CheckNotloginGuard] },

      { path: 'Docente', component: DocenteComponent, canActivate: [CheckNotloginGuard] },
      { path: 'lista-docente', component: ListDocenteComponent, canActivate: [CheckNotloginGuard] },
      { path: 'editar-docente/:idDocente', component: FormDocenteComponent, canActivate: [CheckNotloginGuard] },
      { path: 'registrar-docente', component: FormDocenteComponent, canActivate: [CheckNotloginGuard]},

      { path: 'listar-notas', component: TableNotaComponent, canActivate: [CheckNotloginGuard] },
      { path: 'registrar-nota', component: FormNotaComponent, canActivate: [CheckNotloginGuard] },
      { path: 'editar-nota/:id', component: FormNotaComponent, canActivate: [CheckNotloginGuard] },
      { path: 'consultar-nota/:id', component: ConsultarNotaComponent, canActivate: [CheckNotloginGuard] },

      { path: 'registrousuarioDocente', component: FormUsuarioDocenteComponent, canActivate: [CheckNotloginGuard] },
      { path: 'lista-usuario', component: UsuarioComponent, canActivate: [CheckNotloginGuard] },
      { path: 'registrousuarioAdmin', component: FormUsuarioAdminComponent, canActivate: [CheckNotloginGuard] },

      { path: 'registrar-notaPeriodo', component: FormNotaPeriodoComponent, canActivate: [CheckNotloginGuard]  },
      { path: 'nota-periodo', component: NotaPeriodoComponent, canActivate: [CheckNotloginGuard] },
      { path: 'lista-nota-periodo', component: TableNotaPeriodoComponent, canActivate: [CheckNotloginGuard] },
      { path: 'editar-nota-Periodo/:id', component: FormNotaPeriodoComponent, canActivate: [CheckNotloginGuard] },

      { path: 'contrato', component: ContratoComponent, canActivate: [CheckNotloginGuard] },
      { path: 'registrar-contrato', component: FormContratoComponent, canActivate: [CheckNotloginGuard] },
      { path: 'editar-contrato/:idDocente', component: FormContratoComponent, canActivate: [CheckNotloginGuard] },
      { path: 'editar-Usuario/:idUsuario', component: FormUsuarioActualizarComponent, canActivate: [CheckNotloginGuard] },

      { path: 'actividad/:idPeriodo/:idMateria', component: ActividadComponent, canActivate: [CheckNotloginGuard] },
      
], { relativeLinkResolution: 'legacy' }),
    BrowserAnimationsModule,
    MensajesModule
  ],
  //Aquí en providers se agregan todos los services de angular
  providers: [UsuarioService, PreMatriculaService, CdkColumnDef, MateriaService, AlertService, DocenteService, CursoService,
    MensualidadService, MatriculaService, NotaService, PeriodoService],
  bootstrap: [AppComponent],
  entryComponents: [DialogoActividadComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }

