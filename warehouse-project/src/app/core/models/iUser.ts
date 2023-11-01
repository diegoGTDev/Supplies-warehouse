import { Role } from './Role';
import { Department } from './Department';
export interface iUser{
    name: string;
    role: Role;
    department: Department;
    token: string;
}
