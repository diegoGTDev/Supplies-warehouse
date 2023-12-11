import { IConcept } from "./IConcept";
import { Iitem } from "./Iitem";
import { Status } from "./Status";
export interface IRequirement {
    user : string;
    description: String;
    status: Status;
    concepts: IConcept[];

}
