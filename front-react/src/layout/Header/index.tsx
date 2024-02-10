import * as React from 'react';
import Box from "@mui/joy/Box";
import Stack from "@mui/joy/Stack";
import {Avatar, Link, List, ListItem} from "@mui/joy";
import Button from "@mui/joy/Button";
// import AuthButton from "@/layout/Header/AuthButton";

import dynamic from 'next/dynamic'

const AuthButton = dynamic(() => import('@/layout/Header/AuthButton'), { ssr: false })

export function Header() {
    // if (typeof window === 'undefined') return <header></header>
    return (
        <header
            style={{
                maxWidth: '1000px',
                width: '100%',
                minWidth: '100%',
                flex: '1 0 1',
            }}
        >
            <div
                style={{
                    padding: '1rem',
                    display: 'flex',
                    flexDirection: 'row',
                    justifyContent: 'space-between',
                    width: '1',
                    backgroundColor: 'rgb(227, 251, 227)',
                    alignItems: 'center',
                    // borderBottomRightRadius: '8px',
                    // borderBottomLeftRadius: '8px',
                }}>
                <Link
                    color={'success'}
                    // variant={'soft'}
                    sx={{
                        fontSize: '1.5rem',
                        fontWeight: '700'
                    }}
                    href={'/'}
                >
                    Turbinance
                </Link>


                <nav>
                    <Stack
                        direction={'row'}
                        spacing={'1rem'}
                    >
                        <Link
                            color={'success'}
                            href={'/'}
                        >Home</Link>

                        <Link
                            href={'/auctions'}
                            color={'success'}

                        >Auction Bids</Link>

                        <AuthButton />
                    </Stack>
                </nav>
            </div>

        </header>
    );
};