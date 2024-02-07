'use client';

import * as React from 'react';
import Box from "@mui/joy/Box";
import Stack from "@mui/joy/Stack";
import {Avatar, Link, List, ListItem} from "@mui/joy";
import Button from "@mui/joy/Button";

export function Header() {
    return (
        <header
            style={{
                padding: '1rem',
                display: 'flex',
                flexDirection: 'row',
                justifyContent: 'space-between',
                width: '100%',
                maxWidth: '1000px'

            }}
        >
            <Link>
                Turbinance
            </Link>


            <nav>
                <Stack
                    direction={'row'}
                    spacing={'1rem'}
                >
                    <Link href={'/'}>Home</Link>

                    <Link href={'/auctions'}>Auction Bids</Link>

                    <Link href={'/login'}>
                        <Button
                            variant={'solid'}
                        >
                            Login
                        </Button>
                    </Link>
                </Stack>
            </nav>

        </header>
    );
};