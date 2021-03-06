import {BeepEnvironment} from './beep-environment';

export interface User {
  id: number;
  displayName: string;
  username: string;
  email: string;
  environments: BeepEnvironment[];
}
