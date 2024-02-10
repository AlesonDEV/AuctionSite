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
import {Card, FormHelperText, Snackbar} from '@mui/joy';
import {AxiosError} from 'axios';
import {useRouter} from 'next/navigation';
import type {IRegisterParams} from "@/api/managers/AuthApiManager";
import RegisterLogo from '@/../public/images/register_logo.png'
import {Link} from '@mui/joy';
import {useState} from "react";


// export const USER_CREDS = 'user_creds';

export default function RegisterPage() {
    // const [creds, setCreds] = React.useState<IRegisterParams>();
    const [open, setOpen] = React.useState(false);
    const [errorMessage, setErrorMessage] = useState<string>('')
    const router = useRouter();
    const {
        register,
        handleSubmit,
        watch,
        setError,
        formState: {errors},
    } = useForm<IRegisterParams>({
        defaultValues: {
            firstName: '',
            lastName: '',
            region: '',
            settlement: '',
            email: '',
            password: '',
            confirmPassword: '',
        } as IRegisterParams
    });

    const registerRequest = usePostRequest({
        mutationFn: AuthApiManager.register,

        onSuccess: (data, variables, context) => {
            console.log(data)

            Cookies.set(COOKIES.ACCESS, data.data['token']);
            // Cookies.set(COOKIES.REFRESH, data.data['refresh_token']);
            // router.push('/');
            router.push('/');
            // localStorage.setItem(USER_CREDS, JSON.stringify(creds));
        },
        onError: (error: AxiosError, variables, context) => {
            console.log(error)
            if (!!error.response) {
                if (

                    !!error.response.data &&
                    !!(error.response.data as any).errors
                ) {
                    setErrorMessage((error.response.data as any).errors.ConfirmPassword[0])
                } else {
                    setErrorMessage(error.response.data as string)
                }
            }

            setOpen(true)
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

    function onSubmit(data: IRegisterParams) {
        registerRequest.mutate(data);
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

            <Snackbar
                autoHideDuration={2000}
                open={open}
                variant={'outlined'}
                color={'danger'}
                anchorOrigin={{vertical: 'top', horizontal: 'center'}}
                onClose={(event, reason) => {
                    if (reason === 'clickaway') {
                        return;
                    }
                    setOpen(false);
                }}
            >
                {errorMessage}
            </Snackbar>


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
                    padding: '2rem',
                    display: 'flex',
                    justifyContent: 'space-between',
                    flexDirection: 'row',
                }}>
                    {/*<img src={RegisterLogo.src} alt=""/>*/}
                    <Box>
                        <Box sx={{
                            backgroundImage: ''
                        }}/>
                        <Stack gap={1}>
                            <Typography level="h3">Register</Typography>
                        </Stack>

                        <form onSubmit={handleSubmit(onSubmit)}>

                            <Stack direction={'row'} spacing={2}>
                                <FormControl error={errors.firstName != null}>
                                    <FormLabel>First Name</FormLabel>
                                    <Input
                                        {...register('firstName', {required: true})}
                                        type="text"
                                    />
                                    {errors.firstName?.message && (
                                        <FormHelperText>{errors.firstName?.message}</FormHelperText>
                                    )}
                                </FormControl>

                                <FormControl error={errors.lastName != null}>
                                    <FormLabel>Last name</FormLabel>
                                    <Input
                                        {...register('lastName', {required: true})}
                                        type="text"
                                    />
                                    {errors.lastName?.message && (
                                        <FormHelperText>{errors.lastName?.message}</FormHelperText>
                                    )}
                                </FormControl>
                            </Stack>

                            <Stack direction={'row'} spacing={2}>
                                <FormControl error={errors.region != null}>
                                    <FormLabel>Region</FormLabel>
                                    <Input
                                        {...register('region', {required: true})}
                                        type="text"
                                    />
                                    {errors.region?.message && (
                                        <FormHelperText>{errors.region?.message}</FormHelperText>
                                    )}
                                </FormControl>

                                <FormControl error={errors.settlement != null}>
                                    <FormLabel>Settlement</FormLabel>
                                    <Input
                                        {...register('settlement', {required: true})}
                                        type="text"
                                    />
                                    {errors.settlement?.message && (
                                        <FormHelperText>{errors.settlement?.message}</FormHelperText>
                                    )}
                                </FormControl>
                            </Stack>

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

                            <FormControl error={errors.confirmPassword != null}>
                                <FormLabel>Confirm Password</FormLabel>
                                <Input
                                    type="password"
                                    {...register('confirmPassword', {required: true})}
                                />
                                {errors.confirmPassword?.message && (
                                    <FormHelperText>{errors.confirmPassword?.message}</FormHelperText>
                                )}
                            </FormControl>

                            <Stack gap={2} sx={{mt: 2}} alignItems={'center'}>
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
                                >Have an account?
                                </Link>
                            </Stack>
                        </form>
                    </Box>
                </Card>

            </Stack>
        </Box>
    );
}
