export type Roles = 'Admin'|'Responsable'|'Docente';

export interface User {
  correo: string;
  password: string;
}
export interface UserResponse {
  id: number;
  message: string;
  token: string;
  tipoUsuario: Roles;
}
