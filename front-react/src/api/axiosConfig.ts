import Cookies from 'js-cookie';
import {COOKIES, URL} from '@/api/apiConsts';
import axios from 'axios';

export const axiosAuthConfig = axios.create({
    baseURL: URL.SERVICE,
    headers: {
        'Content-Type': 'application/json',
        accept: 'application/json',
    },
});
export const axiosServiceConfig = axios.create({
    baseURL: URL.SERVICE,
    headers: {
        'Content-Type': 'application/json',
        accept: 'application/json',
    },
});
// export const axiosGenerateConfig = axios.create({
//     baseURL: URL.SERVICE,
//     headers: {
//         'Content-Type': 'application/pdf',
//         accept: 'application/pdf',
//     }
// })
// axiosGenerateConfig.interceptors.request.use(
//     (config) => {
//         let accessToken = Cookies.get(COOKIES.ACCESS);
//         if (accessToken) {
//             config.headers['Access-Control-Allow-Origin'] = '*';
//             // config.headers['access-token'] = accessToken;
//         }
//
//         return config;
//     },
//     (error) => {
//         Promise.reject(error);
//     }
// )
axiosServiceConfig.interceptors.request.use(
    (config) => {
        let accessToken = Cookies.get(COOKIES.ACCESS);
        if (accessToken) {
            config.headers['access-token'] = accessToken;
        }

        return config;
    },
    (error) => {
        Promise.reject(error);
    }
);
axiosAuthConfig.interceptors.request.use(
    (config) => {
        let accessToken = Cookies.get(COOKIES.ACCESS);
        if (accessToken) {
            config.headers['access-token'] = accessToken;
        }

        return config;
    },
    (error) => {
        Promise.reject(error);
    }
);

