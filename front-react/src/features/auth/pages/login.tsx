'use client';
import * as React from 'react';
import GlobalStyles from '@mui/joy/GlobalStyles';
import Box from '@mui/joy/Box';
import Button from '@mui/joy/Button';
import Cookies from 'js-cookie';
import FormControl from '@mui/joy/FormControl';
import FormLabel, {formLabelClasses} from '@mui/joy/FormLabel';
import Input from '@mui/joy/Input';
import Typography from '@mui/joy/Typography';
import Stack from '@mui/joy/Stack';

import {useForm} from 'react-hook-form';
import {usePostRequest} from '@/hooks/usePostRequest';
import AuthApiManager from '@/api/managers/AuthApiManager';
import {COOKIES} from '@/api/apiConsts';
import {Card, FormHelperText} from '@mui/joy';
import type {AxiosError} from 'axios';
import {useRouter} from 'next/navigation';


import {Link} from '@mui/joy';


export type Inputs = {
    email: string;
    password: string;
};

export const USER_CREDS = 'user_creds';

export default function LoginPage() {
    const [creds, setCreds] = React.useState<Inputs>();

    const router = useRouter();
    const {
        register,
        handleSubmit,
        watch,
        setError,
        formState: {errors},
    } = useForm<Inputs>();

    const logInRequest = usePostRequest({
        mutationFn: (params: Inputs) => {
            setCreds(params);
            return AuthApiManager.login(params);
        },
        onSuccess: (data, variables, context) => {
            Cookies.set(COOKIES.ACCESS, data.data['access_token']);
            // Cookies.set(COOKIES.REFRESH, data.data['refresh_token']);
            // router.push('/');
            router.push('/');
            // localStorage.setItem(USER_CREDS, JSON.stringify(creds));
        },
        onError: (error: AxiosError, variables, context) => {
            switch (error.response?.status) {
                case 401:
                    //wrong password
                    setError('password', {type: 'custom', message: 'wrong password'});
                    break;
                case 404:
                    //wrong password
                    setError('email', {type: 'custom', message: 'no such user'});
                    break;
            }
            Cookies.remove(COOKIES.ACCESS);
            Cookies.remove(COOKIES.REFRESH);
        },
    });

    function onSubmit(data: Inputs) {
        logInRequest.mutate(data);
    }

    return (
        <Box
            sx={{
                flex: '1',
                width: '100%',
            }}
        >
            <GlobalStyles
                styles={{
                    ':root': {
                        '--Collapsed-breakpoint': '769px', // form will stretch when viewport is below `769px`
                        '--Cover-width': '50vw', // must be `vw` only
                        '--Form-maxWidth': '800px',
                        '--Transition-duration': '0.4s', // set to `none` to disable transition
                    },
                }}
            />

            <Stack
                gap={4}
                sx={{
                    mb: 2,
                    width: '100vw',
                    height: '100dvh',
                    maxWidth: '1000px',
                }}
                alignItems={'center'}
                justifyContent={'center'}
            >
                <Card sx={{
                    padding: '2rem'
                }}>
                    <Stack gap={1}>
                        <Typography level="h3">Sign in</Typography>
                    </Stack>

                    <form onSubmit={handleSubmit(onSubmit)}>
                        <FormControl error={errors.email != null}>
                            <FormLabel>Email</FormLabel>
                            <Input
                                {...register('email', {required: true})}
                                type="email"
                            />
                            {errors.email?.message && (
                                <FormHelperText>{errors.email?.message}</FormHelperText>
                            )}
                        </FormControl>
                        <FormControl error={errors.password != null}>
                            <FormLabel>Password</FormLabel>
                            <Input
                                type="password"
                                {...register('password', {required: true})}
                            />
                            {errors.password?.message && (
                                <FormHelperText>{errors.password?.message}</FormHelperText>
                            )}
                        </FormControl>
                        <Stack
                            gap={1}
                            sx={{mt: 2}}
                            alignItems={'center'}

                        >
                            <Button
                                type="submit"
                                color={'success'}
                                fullWidth
                            >
                                Sign in
                            </Button>
                            <Link
                                color={'success'}
                                href={'/register'}
                            >Want to register?
                            </Link>
                        </Stack>
                    </form>
                </Card>
            </Stack>
        </Box>
    );
}
