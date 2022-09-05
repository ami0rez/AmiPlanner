import { UserProfile } from "src/common/services/models/user-profile";

export class AuthenticationResponse {
  profile: UserProfile;
  accessToken: string;
  accessTokenType: string;
  refreshToken: string;
}
