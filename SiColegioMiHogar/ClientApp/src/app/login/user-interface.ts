export type Roles = 'Admin'|'Responsable'|'Profesor';

export interface User {
  correo: string;
  password: string;
}
export interface UserResponse {
  message: string;
  token: string;
  tipoUsuario: Roles;
}
