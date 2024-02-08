import { axiosAuthConfig } from '@/api/axiosConfig';

export default class AuthApiManager {
  static async logIn({ email, password }: { email: string; password: string }) {
    return await axiosAuthConfig.post(`/api/auth/user/login/`, {
      email,
      password,
    });
  }
  static async refresh({ refreshToken }: { refreshToken: string }) {
    return await axiosAuthConfig.post(`/api/auth/user/refresh_token/`, {
      refresh_token: refreshToken,
    });
  }
  static async getUserMe({ refreshToken }: { refreshToken: string }) {
    return await axiosAuthConfig.post(
      '/api/auth/user/me',
      {
        refresh_token: refreshToken
      }
    )
  }
}
