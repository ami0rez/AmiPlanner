import { FieldObjectDisplaySelect } from "involys-common/common";
import { LoginData } from "./login-data";

export class LoginPage{
  data: LoginData = new LoginData();
  login : FieldObjectDisplaySelect = new FieldObjectDisplaySelect();
  password: FieldObjectDisplaySelect = new FieldObjectDisplaySelect();
}