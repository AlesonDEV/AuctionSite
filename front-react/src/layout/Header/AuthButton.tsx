'use client';

import React from 'react';
import Button from "@mui/joy/Button";
import {Link} from "@mui/joy";
import Cookies from "js-cookie";
import {COOKIES} from "@/api/apiConsts";

const AuthButton = () => {
    const isAuthed: boolean = !!Cookies.get(COOKIES.ACCESS);

    return (
        <Link href={isAuthed ? '/account' : '/login'}>

            <Button
                variant={'solid'}
                color={'success'}
            >
                {
                    isAuthed ?
                        "Account"
                        :
                        "Authorization"
                }
            </Button>
        </Link>
    );
};

export default AuthButton;
