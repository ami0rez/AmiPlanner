import { Injectable } from '@angular/core';
import { AuthenticationService } from 'src/common/services/authentication.service';
import { TokenService } from '../../login/services/token.service';
import { RefreshTokenQuery } from '../models/refresh-token-query';

@Injectable({
  providedIn: 'root',
})
/**
 *  @description Manage user tokens
 */
export class TokenManagerService {
  constructor(
    private tokenService: TokenService,
    private authenticationService: AuthenticationService
  ) {}

  /**
   *  @description Refresh user token
   */
  async tryRefreshingTokens(): Promise<boolean> {
    const authSettings = this.authenticationService.authenticationSettings;
    const query: RefreshTokenQuery = {
      accessToken: authSettings.accessToken,
      refreshToken: authSettings.refreshToken,
    };
    const refreshTokenResponse = await this.tokenService
      .refresh(query)
      .toPromise();
    this.authenticationService.completeSilentRenew(refreshTokenResponse);
    return true;
  }
}
