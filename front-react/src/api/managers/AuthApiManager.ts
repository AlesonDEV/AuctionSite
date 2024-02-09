import {axiosAuthConfig} from '@/api/axiosConfig';

export interface IRegisterParams {
    firstName: string
    lastName: string
    region: string
    settlement: string
    email: string
    password: string
    confirmPassword: string
}

export interface ILoginParams {
    email: string
    password: string
}


export default class AuthApiManager {
    static async login({email, password}: ILoginParams) {
        return await axiosAuthConfig.post(`/api/User/login/`, {
            email,
            password,
        });
    }

    static async register(
        {
            firstName,
            lastName,
            region,
            settlement,
            email,
            password,
            confirmPassword,
        }: IRegisterParams) {
        return await axiosAuthConfig.post(`/api/User/register/`, {
          firstName,
          lastName,
          region,
          settlement,
          email,
          password,
          confirmPassword,
        });
    }

    // static async refresh({ refreshToken }: { refreshToken: string }) {
    //   return await axiosAuthConfig.post(`/api/User/refresh_token/`, {
    //     refresh_token: refreshToken,
    //   });
    // }
    static async getUserMe({refreshToken}: { refreshToken: string }) {
        return await axiosAuthConfig.post(
            '/api/auth/user/me',
            {
                refresh_token: refreshToken
            }
        )
    }
}
