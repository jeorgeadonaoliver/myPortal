
export interface AuthUser {
  uid?: string;
  accessToken?: string | null;
  refreshToken?: string | null;
  expirationTime?: string | null;
}
