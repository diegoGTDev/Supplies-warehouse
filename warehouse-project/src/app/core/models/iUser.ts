import { Role } from './Role';
import { Department } from './Department';
export interface iUser{
    userName: string;
    role: Role;
    department: string;
    token: string;
}
